using MVC_architecture_35.Language;
using MVC_architecture_35.Model;
using MVC_architecture_35.View;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public partial class GameGUI : Form, IGUI, Observable
    {
        private Button[,] buttonsGrid;
        public GameGUI(int index)
        {
            InitializeComponent();

            this.langComboBox.SelectedIndex = index;
        }

        // Get / Set ---------------------------------------------------------------------------------------------------------------------------
        public void SetMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        public DialogResult ChooseOptionMessage(string title, string message)
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNoCancel);
        }

        public void HideForm()
        {
            this.Hide();
        }

        public ComboBox GetLangComboBox()
        {
            return this.langComboBox;
        }

        public Label GetScoreLabel()
        {
            return this.loggedInPlayerScoreLabel;
        }

        public NumericUpDown GetScoreNUD()
        {
            return this.nudLoggedInPlayerScore;
        }

        public NumericUpDown GetLevelNUD() 
        {
            return this.nudLevel;
        }

        public Label GetOponentLabel()
        {
            return this.oponentLabel;
        }

        public Label GetPlayerLabel()
        {
            return this.playerLabel;
        }

        public PictureBox GetPlayerPictureBox()
        {
            return this.playerMovesPictureBox;
        }

        public PictureBox GetOponentPictureBox()
        {
            return this.oponentMovesPictureBox;
        }

        public NumericUpDown GetPlayerScoreNUD()
        {
            return this.nudPlayerScore;
        }

        public NumericUpDown GetOponentScoreNUD()
        {
            return this.nudOponentScore;
        }

        public Button GetPlayPauseButton()
        {
            return this.playPauseButton;
        }

        public Button GetRestartButton()
        {
            return this.restartGameButton;
        }

        public Button GetExitButton()
        {
            return this.leaveGameButton;
        }

        public FlowLayoutPanel GetButtonsFlowPanel()
        {
            return this.buttonsTableLayout;
        }

        public Timer GetCpuTimer()
        {
            return this.timerCPU;
        }

        public Label GetGameTitleLabel()
        {
            return this.gameTitle;
        }

        public Label GetLoggedInPlayerScoreLabel()
        {
            return this.loggedInPlayerScoreLabel;
        }

        public Label GetLevelLabel()
        {
            return this.levelLabel;
        }

        public Label GetOpoScoreLabel()
        {
            return this.opoScoreLabel;
        }

        public Label GetPlyScoreLabel()
        {
            return this.plyScoreLabel;
        }

        public Button[,] GetButtonsGrid()
        {
            return this.buttonsGrid;
        }

        // Update ------------------------------------------------------------------------------------------------------------------------------
        public void Update(Subject obs)
        {
            GameModel gameModel = (GameModel) obs;
            int gridSize = gameModel.BoardSize;
            this.buttonsGrid = new Button[gridSize, gridSize];
        }

        // GUI only ----------------------------------------------------------------------------------------------------------------------------
        public Button GetButtonWithStyle(int row, int col, int buttonSize, int spacing)
        {
            int locGridX = 55;
            int locGridY = 200;

            Button button = new Button();
            button.Size = new System.Drawing.Size(buttonSize, buttonSize);
            button.Location = new System.Drawing.Point(col * (buttonSize + spacing) + locGridX, row * (buttonSize + spacing) + locGridY);
            button.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            button.Cursor = Cursors.Hand;

            return button;
        }

        public Form CreateSelectArrowMessageBox(string title, string message)
        {
            Form messageForm = new Form();
            messageForm.Text = title;
            messageForm.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            messageForm.ClientSize = new Size(330, 330);
            messageForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            messageForm.StartPosition = FormStartPosition.CenterParent;
            messageForm.BackColor = System.Drawing.Color.FromArgb(44, 44, 44);
            //messageForm.Location = new Point(this.Right / 2 + 55, this.Top + 200);

            Label label = new Label();
            label.Text = message;
            label.Font = new Font("Arial Rounded MT Bold", 14, FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);
            label.AutoSize = true;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(40, 20);

            messageForm.Controls.Add(label);
            return messageForm;
        }

        public TableLayoutPanel CreateChooseDirectionTable()
        {
            TableLayoutPanel buttonsPanel = new TableLayoutPanel();
            buttonsPanel.RowCount = 3;
            buttonsPanel.ColumnCount = 3;
            buttonsPanel.Size = new Size(210, 210);
            buttonsPanel.Location = new Point(50, 60);

            buttonsPanel.AutoSize = true;
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            buttonsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            buttonsPanel.RowStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            buttonsPanel.RowStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            buttonsPanel.RowStyles.Add(new ColumnStyle(SizeType.Absolute, 80));

            return buttonsPanel;
        }

        public Button CreateDirectionButton(string imageName)
        {
            Button button = new Button();
            button.BackgroundImage = Properties.Resources.ResourceManager.GetObject(imageName) as System.Drawing.Image;
            button.BackgroundImageLayout = ImageLayout.Stretch;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;

            button.Font = new Font("Arial Rounded MT Bold", 10, FontStyle.Bold);
            button.ForeColor = System.Drawing.Color.FromArgb(210, 210, 210);

            button.Dock = DockStyle.Fill;
            return button;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }

        
    }
}
