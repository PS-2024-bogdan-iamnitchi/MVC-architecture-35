using MVC_architecture_35.Language;
using MVC_architecture_35.Model;
using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_architecture_35.Controller
{
    public class GameController
    {
        private GameGUI gameGUI;
        private GameModel gameModel;
        private PlayerRepository playerRepository;
        private Player loggedInPlayer;
        private Button[,] buttonsGrid;

        public GameController(string loggedInPlayerEmail, int index)
        {
            this.gameGUI = new GameGUI(index);
            this.playerRepository = new PlayerRepository();
            this.loggedInPlayer = getLoggedInPlayer(loggedInPlayerEmail);

            this.initializeComponentLang();
            this.gameModel = new GameModel();
            this.resetGame();

            //handle events
            this.eventsManagement();
        }

        // View and Events ----------------------------------------------------------------------------------------------------------------------
        public GameGUI GetView()
        {
            return this.gameGUI;
        }

        private void eventsManagement()
        {
            this.gameGUI.GetLangComboBox().SelectedIndexChanged += new EventHandler(selectIndexCallback);

            this.gameGUI.GetPlayPauseButton().Click += new EventHandler(playPause);
            this.gameGUI.GetRestartButton().Click += new EventHandler(restart);
            this.gameGUI.GetExitButton().Click += new EventHandler(exit);
            this.gameGUI.GetLevelNUD().ValueChanged += new EventHandler(levelChanged);
            this.gameGUI.GetCpuTimer().Tick += new EventHandler(CPUTimmerCallBack);
        }

        //Events --------------------------------------------------------------------------------------------------------------------------------
        private void levelChanged(object sender, EventArgs e)
        {
            this.gameModel.Level = (int)this.gameGUI.GetLevelNUD().Value;
            this.resetGame();
        }

        private void playPause(object sender, EventArgs e)
        {
            if (this.gameModel.GameState == GameState.Init || this.gameModel.GameState == GameState.Paused)
            {
                this.gameModel.GameState = GameState.Started;
                this.gameGUI.GetPlayPauseButton().BackgroundImage = Properties.Resources.pause;
                this.gameGUI.SetMessage("PLAY!", "Game started!");

                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(40, 196, 36); //green
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            }
            else
            {
                this.gameModel.GameState = GameState.Paused;
                this.gameGUI.GetPlayPauseButton().BackgroundImage = Properties.Resources.start;
                this.gameGUI.SetMessage("PAUSE!", "Game is paused!");
            }
        }

        private void restart(object sender, EventArgs e)
        {
            this.gameGUI.GetOponentScoreNUD().Value = 0;
            this.gameGUI.GetPlayerScoreNUD().Value = 0;
            this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            this.resetGame();
        }

        private void exit(object sender, EventArgs e)
        {
            if (loggedInPlayer == null)
            {
                LoginController loginController = new LoginController(this.gameGUI.GetLangComboBox().SelectedIndex);
                loginController.GetView().Show();
                this.gameGUI.HideForm();
                return;
            }

            DialogResult result = this.gameGUI.ChooseOptionMessage("Leave Game", "Do you want to save your results?");
            switch (result)
            {
                case DialogResult.Yes:
                    savePlayerScoreToDB();
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    return; //stay in GameGUI
            }
            HomeController homeController = new HomeController(this.loggedInPlayer.Email, this.gameGUI.GetLangComboBox().SelectedIndex);
            homeController.GetView().Show();
            this.gameGUI.HideForm();
        }

        public void CPUTimmerCallBack(object sender, EventArgs e)
        {
            if (this.gameModel.Turn == 1)
            {
                this.checkGameEnded(this.gameModel.Turn);
                this.cpuMoves();
                this.gameModel.Turn = 1 - this.gameModel.Turn;

                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(40, 196, 36); //green
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.gameGUI.GetCpuTimer().Stop();
            }
            if (this.gameModel.GameState != GameState.Ended)
            {
                this.checkGameEnded(this.gameModel.Turn);
            }
        }

        private void selectIndexCallback(object sender, EventArgs e)
        {
            if (this.gameGUI.GetLangComboBox().SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.gameGUI.GetLangComboBox().SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.gameGUI.GetLangComboBox().SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            initializeComponentLang();
        }

        //Controller specific methods -----------------------------------------------------------------------------------------------------------
        private void resetGame()
        {
            if (loggedInPlayer == null)
            {
                this.gameGUI.GetScoreLabel().Visible = false;
                this.gameGUI.GetScoreNUD().Visible = false;
            }
            else
            {
                this.gameGUI.GetScoreNUD().Value = (int)loggedInPlayer.Score;
            }

            this.createButtonsGrid();

            this.gameGUI.GetPlayPauseButton().BackgroundImage = Properties.Resources.start;
            this.gameGUI.GetPlayerPictureBox().Image = Properties.Resources.ResourceManager.GetObject("green_level" + this.gameModel.Level) as System.Drawing.Image;
            this.gameGUI.GetOponentPictureBox().Image = Properties.Resources.ResourceManager.GetObject("red_level" + this.gameModel.Level) as System.Drawing.Image;

            this.gameModel.Board = this.gameModel.GetNewBoard();
            this.gameModel.GameState = GameState.Init;
            this.gameModel.GameOutcome = GameOutcome.None;
        }

        // GUI stuff -------------------------------------------------------------------------------------------------------------------------
        private void createButtonsGrid()
        {
            int gridSize = this.gameModel.BoardSize;
            this.buttonsGrid = new Button[gridSize, gridSize];
            this.gameGUI.GetButtonsFlowPanel().Controls.Clear();
            for (int row = 0; row < this.gameModel.BoardSize; row++)
            {
                for (int col = 0; col < this.gameModel.BoardSize; col++)
                {
                    Button button;
                    if (this.gameModel.Level == 1)
                    {
                        button = this.gameGUI.GetButtonWithStyle(row, col, 90, 15);
                    }
                    else
                    {
                        button = this.gameGUI.GetButtonWithStyle(row, col, 45, 10);
                    }

                    button.Click += (sender, e) =>
                    {
                        this.gridButtonEvent(sender, e);
                    };
                    this.buttonsGrid[row, col] = button;
                    this.gameGUI.GetButtonsFlowPanel().Controls.Add(button);
                }
            }
        }

        private void gridButtonEvent(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null)
            {
                return;
            }

            for (int row = 0; row < this.gameModel.BoardSize; row++)
            {
                for (int col = 0; col < this.gameModel.BoardSize; col++)
                {
                    if (this.buttonsGrid[row, col] == clickedButton)
                    {
                        this.GridButtonPressed(row, col);
                        return;
                    }
                }
            }
        }

        public void GridButtonPressed(int row, int col)
        {
            if (this.gameModel.GameState != GameState.Started)
            {
                this.gameGUI.SetMessage("Failure!", "Please start the game first!");
                return;
            }
            if (this.gameModel.Turn != 0)
            {
                this.gameGUI.SetMessage("Failure!", "Not your turn!");
                return;
            }

            Model.Color color = this.gameModel.Board[row, col].Color = Model.Color.Green;
            Form messageBox = this.gameGUI.CreateSelectArrowMessageBox("Game notification", "Please select your move:");
            TableLayoutPanel dirButtonsTable = this.gameGUI.CreateChooseDirectionTable();

            List<Direction> allowedDir = this.gameModel.Board[row, col].AllowedDirections;
            foreach (Direction dir in allowedDir)
            {
                string imageName = $"{color.ToString().ToLower()}_{dir.ToString().ToLower()}";
                Button dirButton = this.gameGUI.CreateDirectionButton(imageName);
                dirButton.Click += (sender, e) =>
                {
                    this.playerMove(dir, color, row, col);
                    messageBox.Close();
                };
                (int t_row, int t_col) = Arrow.DirectionToIndex(dir);
                dirButtonsTable.Controls.Add(dirButton, t_col, t_row);
            }
            messageBox.Controls.Add(dirButtonsTable);
            messageBox.ShowDialog();
        }

        private void playerMove(Direction dir, Model.Color color, int row, int col)
        {
            if (this.gameModel.Turn == 0)
            {
                this.checkGameEnded(this.gameModel.Turn);
                this.applyMove(dir, color, row, col);
                this.updateGridView(dir, color, row, col);
                this.gameModel.Turn = 1 - this.gameModel.Turn;

                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.Red;
                this.gameGUI.GetCpuTimer().Start();
            }
        }

        private void cpuMoves()
        {
            int bestScore = int.MaxValue;
            (Direction, int, int) bestMove = (Direction.None, 0, 0);
            Model.Color color = Model.Color.Red;

            for (int i = 0; i < this.gameModel.BoardSize; i++)
            {
                for (int j = 0; j < this.gameModel.BoardSize; j++)
                {
                    if (this.gameModel.MoveAvailable(i, j))
                    {
                        List<Direction> allowedDir = cloneListDir(this.gameModel.Board[i, j].AllowedDirections);
                        foreach (Direction dir in allowedDir)
                        {
                            var modifiedPosition = applyMove(dir, color, i, j);
                            int score = minimax(0, 0);
                            resetMove(dir, i, j, modifiedPosition);

                            if (score < bestScore)
                            {
                                bestScore = score;
                                bestMove = (dir, i, j);
                            }
                        }
                        gameModel.Board[i, j].AllowedDirections = allowedDir;
                    }
                }
            }
            (Direction bestDir, int row, int col) = bestMove;
            if (this.gameModel.GameState == GameState.Started)
            {
                applyMove(bestDir, color, row, col);
                updateGridView(bestDir, color, row, col);
            }
        }

        private int minimax(int depth, int turn)
        {
            var result = this.gameModel.CheckGameOutcome(turn);
            if (result != GameOutcome.None || depth == 1)
            {
                return evaluateGameModel(result);
            }

            if (turn == 0)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < this.gameModel.BoardSize; i++)
                {
                    for (int j = 0; j < this.gameModel.BoardSize; j++)
                    {
                        if (this.gameModel.MoveAvailable(i, j))
                        {
                            List<Direction> allowedDir = cloneListDir(this.gameModel.Board[i, j].AllowedDirections);
                            foreach (Direction dir in allowedDir)
                            {
                                var modifiedPosition = applyMove(dir, Model.Color.Green, i, j);
                                int score = minimax(depth + 1, 1);
                                resetMove(dir, i, j, modifiedPosition);

                                bestScore = Math.Max(score, bestScore);
                            }
                            gameModel.Board[i, j].AllowedDirections = allowedDir;
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < this.gameModel.BoardSize; i++)
                {
                    for (int j = 0; j < this.gameModel.BoardSize; j++)
                    {
                        if (this.gameModel.MoveAvailable(i, j))
                        {
                            List<Direction> allowedDir = cloneListDir(this.gameModel.Board[i, j].AllowedDirections);
                            foreach (Direction dir in allowedDir)
                            {
                                var modifiedPosition = applyMove(dir, Model.Color.Red, i, j);
                                int score = minimax(depth + 1, 0);
                                resetMove(dir, i, j, modifiedPosition);

                                bestScore = Math.Min(score, bestScore);
                            }
                            gameModel.Board[i, j].AllowedDirections = allowedDir;
                        }
                    }
                }
                return bestScore;
            }
        }

        private int evaluateGameModel(GameOutcome result)
        {
            int score = 0;
            if (result != GameOutcome.None)
            {
                score += this.gameModel.mapGameOutcomeToValue(result);
            }
            for (int i = 0; i < this.gameModel.BoardSize; i++)
            {
                for (int j = 0; j < this.gameModel.BoardSize; j++)
                {
                    score += this.gameModel.Board[i, j].AllowedDirections.Count;
                }
            }
            return score;
        }

        private List<Direction> cloneListDir(List<Direction> list)
        {
            List<Direction> newList = new List<Direction>();
            foreach (Direction dir in list)
            {
                newList.Add(dir);
            }
            return newList;
        }

        private List<(int, int)> applyMove(Direction dir, Model.Color color, int row, int col)
        {
            this.gameModel.Board[row, col].Direction = dir;
            this.gameModel.Board[row, col].Color = color;
            return removeAllowedDirection(dir, row, col);
        }

        private void resetMove(Direction dir, int row, int col, List<(int, int)> modifiedPosition)
        {
            this.gameModel.Board[row, col].Direction = Direction.None;
            this.gameModel.Board[row, col].Color = Model.Color.None;
            addAllowedDirection(modifiedPosition, dir);
        }

        private void addAllowedDirection(List<(int, int)> modifiedPosition, Direction dir)
        {
            foreach ((int i, int j) in modifiedPosition)
            {
                this.gameModel.Board[i, j].AddAllowedDirection(dir);
            }
        }

        private List<(int, int)> removeAllowedDirection(Direction dir, int row, int col)
        {
            List<(int, int)> modifiedPosition = new List<(int, int)>();
            if (this.gameModel.Level >= 1)
            {
                for (int j = 0; j < this.gameModel.BoardSize; j++)
                {
                    if (this.gameModel.Board[row, j].AllowedDirections.Contains(dir))
                    {
                        this.gameModel.Board[row, j].RemoveAllowedDirection(dir);
                        modifiedPosition.Add((row, j));
                    }
                }
                for (int i = 0; i < this.gameModel.BoardSize; i++)
                {
                    if (this.gameModel.Board[i, col].AllowedDirections.Contains(dir))
                    {
                        this.gameModel.Board[i, col].RemoveAllowedDirection(dir);
                        modifiedPosition.Add((i, col));
                    }
                }
            }
            if (this.gameModel.Level >= 2)
            {
                for (int i = 0; i < this.gameModel.BoardSize; i++)
                {
                    for (int j = 0; j < this.gameModel.BoardSize; j++)
                    {
                        if (Math.Abs(row - i) == Math.Abs(col - j))
                        {
                            if (this.gameModel.Board[i, j].AllowedDirections.Contains(dir))
                            {
                                this.gameModel.Board[i, j].RemoveAllowedDirection(dir);
                                modifiedPosition.Add((i, j));
                            }
                        }
                    }
                }
            }
            for (int i = this.gameModel.Board[row, col].AllowedDirections.Count - 1; i >= 0; i--)
            {
                this.gameModel.Board[row, col].AllowedDirections.RemoveAt(i);
                modifiedPosition.Add((row, col));
            }
            return modifiedPosition;
        }

        private void updateGridView(Direction dir, Model.Color color, int row, int col)
        {
            string dirStr = dir.ToString().ToLower();
            string colorStr = color.ToString().ToLower();
            string imageName = $"{colorStr}_{dirStr}";
            this.buttonsGrid[row, col].BackgroundImageLayout = ImageLayout.Stretch;
            this.buttonsGrid[row, col].BackgroundImage = Properties.Resources.ResourceManager.GetObject(imageName) as System.Drawing.Image;
            this.buttonsGrid[row, col].Enabled = false;
        }

        private void checkGameEnded(int turn)
        {
            var gameOutcome = this.gameModel.CheckGameOutcome(turn);
            if (gameOutcome == GameOutcome.Lose)
            {
                this.gameGUI.GetCpuTimer().Stop();
                this.gameGUI.SetMessage("Game Over!", "You have lost the game!");

                this.gameGUI.GetOponentScoreNUD().Value = this.gameGUI.GetOponentScoreNUD().Value + 1;
                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.resetGame();
                return;
            }
            if (gameOutcome == GameOutcome.Draw)
            {
                this.gameGUI.GetCpuTimer().Stop();
                this.gameGUI.SetMessage("Draw!", "Not Good not bad");

                this.gameGUI.GetPlayerScoreNUD().Value = this.gameGUI.GetPlayerScoreNUD().Value + 1;
                this.gameGUI.GetOponentScoreNUD().Value = this.gameGUI.GetOponentScoreNUD().Value + 1;
                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.resetGame();
                return;
            }
            if (gameOutcome == GameOutcome.Win)
            {
                this.gameGUI.GetCpuTimer().Stop();
                this.gameGUI.SetMessage("Congratulation!", "You have win the game!");

                this.gameGUI.GetPlayerScoreNUD().Value = this.gameGUI.GetPlayerScoreNUD().Value + 1;
                this.gameGUI.GetPlayerLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.gameGUI.GetOponentLabel().ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
                this.resetGame();
                return;
            }
        }


        //DB stuff ---------------------------------------------------------------------------------------------------------------------------
        private Player getLoggedInPlayer(string email)
        {
            Player player = null;

            try
            {
                if (email != null && email.Length != 0)
                {
                    player = this.playerRepository.GetPlayerByEmail(email);
                }
            }
            catch (Exception ex)
            {
                this.gameGUI.SetMessage("Exeption - GetLoggedInPlayer", ex.ToString());
            }
            return player;
        }

        public void savePlayerScoreToDB()
        {
            try
            {
                uint selectedID = this.loggedInPlayer.PlayerID;
                this.loggedInPlayer.Score += (uint)this.gameGUI.GetPlayerScoreNUD().Value;
                Player player = this.loggedInPlayer;
                if (player != null)
                {
                    bool result = this.playerRepository.UpdatePlayer(selectedID, player);
                    if (result)
                    {
                        this.gameGUI.SetMessage("Success!", "Saving the score was completed successfully!");
                    }
                    else
                        this.gameGUI.SetMessage("Failure!", "Updating was ended with failure!");
                }
            }
            catch (Exception exception)
            {
                this.gameGUI.SetMessage("Exception - Update Score", exception.ToString());
            }
        }

        private void initializeComponentLang()
        {
            this.gameGUI.GetGameTitleLabel().Text = LangHelper.GetString("gameTitle");
            this.gameGUI.GetScoreLabel().Text = LangHelper.GetString("savedScoreLabel");
            this.gameGUI.GetLevelLabel().Text = LangHelper.GetString("levelLabel");
            this.gameGUI.GetOponentLabel().Text = LangHelper.GetString("opoMovesLabel");
            this.gameGUI.GetPlayerLabel().Text = LangHelper.GetString("plyMovesLabel");
            this.gameGUI.GetOpoScoreLabel().Text = LangHelper.GetString("opoScoreLabel");
            this.gameGUI.GetPlyScoreLabel().Text = LangHelper.GetString("plyScoreLabel");
        }
    }
}
