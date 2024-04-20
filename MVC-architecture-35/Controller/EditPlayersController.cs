using MVC_architecture_35.Model;
using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_architecture_35.Controller
{
    public class EditPlayersController
    {
        private EditPlayersGUI editPlayersGUI;
        private PlayerRepository playerRepository;
        private Player loggedInPlayer;

        public EditPlayersController(string loggedInPlayerEmail, int index)
        {
            this.editPlayersGUI = new EditPlayersGUI(index);
            this.playerRepository = new PlayerRepository();
            this.loggedInPlayer = getLoggedInPlayer(loggedInPlayerEmail);

            //handle events
            this.eventsManagement();
        }

        // View and Events -------------------------------------------------------------------------------------------------------------------
        public EditPlayersGUI GetView()
        {
            return this.editPlayersGUI;
        }

        private void eventsManagement()
        {
            this.editPlayersGUI.GetPlayersTable().RowStateChanged += rowStateChanged;

            this.editPlayersGUI.GetLoadButton().Click += new EventHandler(loadPlayers);
            this.editPlayersGUI.GetAddButton().Click += new EventHandler(addPlayer);
            this.editPlayersGUI.GetUpdateButton().Click += new EventHandler(updatePlayer);
            this.editPlayersGUI.GetDeleteButton().Click += new EventHandler(deletePlayer);
            this.editPlayersGUI.GetSearchButton().Click += new EventHandler(searchPlayers);
            this.editPlayersGUI.GetBackButton().Click += new EventHandler(toHomeView);

            this.loadPlayers(null, null);
        }

        //Events --------------------------------------------------------------------------------------------------------------------------
        private void rowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (this.editPlayersGUI.GetPlayersTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.editPlayersGUI.GetPlayersTable().SelectedRows[0];
                    uint playerID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.editPlayersGUI.GetIdNUD().Value = playerID;
                    string fullName = drvr.Cells[1].Value.ToString();
                    this.editPlayersGUI.GetFullNameTextBox().Text = fullName;
                    string email = drvr.Cells[2].Value.ToString();
                    this.editPlayersGUI.GetEmailTextBox().Text = email;
                    uint age = Convert.ToUInt32(drvr.Cells[3].Value);
                    this.editPlayersGUI.GetAgeNUD().Value = age;
                    string password = drvr.Cells[4].Value.ToString();
                    this.editPlayersGUI.GetPasswordTextBox().Text = password;
                    uint score = Convert.ToUInt32(drvr.Cells[5].Value);
                    this.editPlayersGUI.GetScoreNUD().Value = score;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error at row selection!");
            }
        }

        private void loadPlayers(object sender, EventArgs e)
        {
            this.editPlayersGUI.GetPlayersTable().Rows.Clear();
            try
            {
                List<Player> list = this.playerRepository.GetPlayersList();
                if (list != null)
                    this.playersListToDataGridView(list);
                else
                    this.editPlayersGUI.SetMessage("Empty", "The list of players is empty!");
            }
            catch (Exception exception)
            {
                this.editPlayersGUI.SetMessage("Exception - GetPlayersList", exception.ToString());
            }
        }

        private void addPlayer(object sender, EventArgs e)
        {
            try
            {
                Player player = this.validInformation();
                if (player != null)
                {
                    bool result = this.playerRepository.AddPlayer(player);
                    if (result)
                    {
                        this.editPlayersGUI.SetMessage("Success!", "Adding was completed successfully!");
                        this.resetPlayerFields();
                        this.editPlayersGUI.GetPlayersTable().Rows.Clear();
                        this.loadPlayers(null, null);
                    }
                    else
                        this.editPlayersGUI.SetMessage("Failure!", "Adding was ended with failure!");
                }
            }
            catch (Exception exception)
            {
                this.editPlayersGUI.SetMessage("Exception - Add", exception.ToString());
            }
        }

        private void updatePlayer(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.editPlayersGUI.GetPlayersTable().SelectedRows.Count))
                {
                    uint selectedID = Convert.ToUInt32((string)this.editPlayersGUI.GetPlayersTable().SelectedRows[0].Cells[0].Value);
                    Player player = this.validInformation();
                    if (player != null)
                    {
                        bool result = this.playerRepository.UpdatePlayer(selectedID, player);
                        if (result)
                        {
                            this.editPlayersGUI.SetMessage("Success!", "Updating was completed successfully!");
                            this.resetPlayerFields();
                            this.editPlayersGUI.GetPlayersTable().Rows.Clear();
                            this.loadPlayers(null, null);
                        }
                        else
                            this.editPlayersGUI.SetMessage("Failure!", "Updating was ended with failure!");
                    }
                }
                else
                    this.editPlayersGUI.SetMessage("Failure!", "No player has been selected to be updated!");
            }
            catch (Exception exception)
            {
                this.editPlayersGUI.SetMessage("Exception - Update", exception.ToString());
            }
        }

        private void deletePlayer(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.editPlayersGUI.GetPlayersTable().SelectedRows.Count))
                {
                    uint selectedID = Convert.ToUInt32((string)this.editPlayersGUI.GetPlayersTable().SelectedRows[0].Cells[0].Value);
                    bool result = this.playerRepository.DeletePlayer(selectedID);
                    if (result)
                    {
                        this.editPlayersGUI.SetMessage("Success!", "Deletion was completed successfully!");
                        this.resetPlayerFields();
                        this.editPlayersGUI.GetPlayersTable().Rows.Clear();
                        this.loadPlayers(null, null);
                    }
                    else
                        this.editPlayersGUI.SetMessage("Failure!", "Deletion was ended with failure!");
                }
                else
                    this.editPlayersGUI.SetMessage("Failure!", "No player has been selected to be deleted!");
            }
            catch (Exception exception)
            {
                this.editPlayersGUI.SetMessage("Exception - Delete", exception.ToString());
            }
        }

        private void searchPlayers(object sender, EventArgs e)
        {
            try
            {
                this.editPlayersGUI.GetPlayersTable().Rows.Clear();
                string searchedInfo = this.editPlayersGUI.GetSearchTextBox().Text;
                if (searchedInfo != null && searchedInfo.Length > 0)
                {
                    List<Player> list = new List<Player>();

                    if (uint.TryParse(searchedInfo, out uint result))
                    {
                        Player player = this.playerRepository.SearchPlayerByID(searchedInfo);
                        if (player != null)
                        {
                            list.Add(player);
                            this.playersListToDataGridView(list);
                        }
                        else
                            this.editPlayersGUI.SetMessage("Empty", "There is no player according to searched information!");
                    }
                    else
                    {
                        list = this.playerRepository.SearchPlayerByName(searchedInfo);
                        if (list != null && list.Count > 0)
                            this.playersListToDataGridView(list);
                        else
                            this.editPlayersGUI.SetMessage("Empty", "There is no player according to searched information!");
                    }
                }
                else
                {
                    this.loadPlayers(null, null);
                    this.editPlayersGUI.SetMessage("Empty", "The searched information is empty!");
                }
            }
            catch (Exception exception)
            {
                this.editPlayersGUI.SetMessage("Exception - Player Search", exception.ToString());
            }
        }

        private void toHomeView(object sender, EventArgs e)
        {
            HomeController homeController = new HomeController(this.loggedInPlayer.Email, this.editPlayersGUI.GetLangComboBox().SelectedIndex);
            homeController.GetView().Show();
            this.editPlayersGUI.HideForm();
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
        private Player validInformation()
        {
            uint playerID = (uint)this.editPlayersGUI.GetIdNUD().Value;
            if (playerID == 0)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Player ID must be non-zero natural number!");
                return null;
            }
            string fullName = this.editPlayersGUI.GetFullNameTextBox().Text;
            if (fullName == null || fullName.Length == 0)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Player name is empty!");
                return null;
            }
            string email = this.editPlayersGUI.GetEmailTextBox().Text;
            if (email == null || email.Length == 0)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Email field is empty!");
                return null;
            }
            uint age = (uint)this.editPlayersGUI.GetAgeNUD().Value;
            if (age <= 10)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Player age must be greater or equal with 10!");
                return null;
            }
            string password = this.editPlayersGUI.GetPasswordTextBox().Text;
            if (password == null || password.Length == 0)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Password field is empty!");
                return null;
            }
            uint score = (uint)this.editPlayersGUI.GetScoreNUD().Value;
            if (score < 0)
            {
                this.editPlayersGUI.SetMessage("Incomplete information!", "Player score must be greater or equal with 0!");
                return null;
            }
            return new Player(playerID, string.Empty, fullName, email, age, password, score);
        }

        private void resetPlayerFields()
        {
            this.editPlayersGUI.GetIdNUD().Value = 0;
            this.editPlayersGUI.GetFullNameTextBox().Text = string.Empty;
            this.editPlayersGUI.GetEmailTextBox().Text = string.Empty;
            this.editPlayersGUI.GetAgeNUD().Value = 0;
            this.editPlayersGUI.GetPasswordTextBox().Text = string.Empty;
            this.editPlayersGUI.GetScoreNUD().Value = 0;
        }

        private void playersListToDataGridView(List<Player> list)
        {
            foreach (Player player in list)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.PlayerID.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.FullName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Email });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Age.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Password.ToString() });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = player.Score });
                this.editPlayersGUI.GetPlayersTable().Rows.Add(row);
            }
        }

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
                this.editPlayersGUI.SetMessage("Exeption - GetLoggedInPlayer", ex.ToString());
            }
            return player;
        }
    }
}
