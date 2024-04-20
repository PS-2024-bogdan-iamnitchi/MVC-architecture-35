using MVC_architecture_35.Language;
using MVC_architecture_35.Model;
using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_architecture_35.Controller
{
    public class HomeController
    {
        private HomeGUI homeGUI;
        private PlayerRepository playerRepository;
        private Player loggedInPlayer;

        public HomeController(string loggedInPlayerEmail, int index)
        {
            this.homeGUI = new HomeGUI(index);
            this.playerRepository = new PlayerRepository();
            this.loggedInPlayer = getLoggedInPlayer(loggedInPlayerEmail);

            this.initializeComponentLang();

            //handle events
            this.eventsManagement();
        }

        // View and Events ----------------------------------------------------------------------------------------------------------------------
        public HomeGUI GetView()
        {
            return this.homeGUI;
        }

        private void eventsManagement()
        {
            this.homeGUI.GetLangComboBox().SelectedIndexChanged += new EventHandler(selectIndexCallback);

            this.homeGUI.GetPlayGameButton().Click += new EventHandler(toGameView);
            this.homeGUI.GetAdminButton().Click += new EventHandler(toAdminView);
            this.homeGUI.GetSignOutButton().Click += new EventHandler(signOut);
        }

        //Events ---------------------------------------------------------------------------------------------------------------------------------
        private void toGameView(object sender, EventArgs e)
        {
            GameController gameController = new GameController(this.loggedInPlayer.Email, this.homeGUI.GetLangComboBox().SelectedIndex);
            gameController.GetView().Show();
            this.homeGUI.HideForm();
        }

        private void toAdminView(object sender, EventArgs e)
        {
            if (loggedInPlayer.IsAdmin.Equals("Yes"))
            {
                EditPlayersController editPlayersController = new EditPlayersController(this.loggedInPlayer.Email, this.homeGUI.GetLangComboBox().SelectedIndex);
                editPlayersController.GetView().Show();
                this.homeGUI.HideForm();
            }
            else
                this.homeGUI.SetMessage("Not Allowed!", "You don't have rights to access this page!");
        }

        private void signOut(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController(this.homeGUI.GetLangComboBox().SelectedIndex);
            loginController.GetView().Show();
            this.homeGUI.HideForm();
        }

        private void selectIndexCallback(object sender, EventArgs e)
        {
            if (this.homeGUI.GetLangComboBox().SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.homeGUI.GetLangComboBox().SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.homeGUI.GetLangComboBox().SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            initializeComponentLang();
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
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
                this.homeGUI.SetMessage("Exeption - GetLoggedInPlayer", ex.ToString());
            }
            return player;
        }

        private void initializeComponentLang()
        {
            this.homeGUI.GetHomeTitleLabel().Text = LangHelper.GetString("homeTitle");
            this.homeGUI.GetHomeText11Label().Text = LangHelper.GetString("homeText11");
            this.homeGUI.GetHomeText12Label().Text = LangHelper.GetString("homeText12");
            this.homeGUI.GetHomeText21Label().Text = LangHelper.GetString("homeText21");
            this.homeGUI.GetHomeText22Label().Text = LangHelper.GetString("homeText22");
            this.homeGUI.GetHomeText31Label().Text = LangHelper.GetString("homeText31");
            this.homeGUI.GetHomeText32Label().Text = LangHelper.GetString("hometext32");
            this.homeGUI.GetSignOutButton().Text = LangHelper.GetString("signOutBtn");
            this.homeGUI.GetAdminButton().Text = LangHelper.GetString("adminBtn");
            this.homeGUI.GetPlayGameButton().Text = LangHelper.GetString("playGameBtn");
        }
    }
}
