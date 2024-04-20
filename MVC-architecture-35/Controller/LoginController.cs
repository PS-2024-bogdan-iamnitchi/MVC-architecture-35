using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC_architecture_35.Controller
{
    public class LoginController
    {
        private LoginGUI loginGUI;
        private PlayerRepository playerRepository;

        public LoginController() 
        {
            this.loginGUI = new LoginGUI(0);
            this.playerRepository = new PlayerRepository();

            //handle events
            this.eventsManagement();
        }

        public LoginController(int index)
        {
            this.loginGUI = new LoginGUI(index);
            this.playerRepository = new PlayerRepository();

            //handle events
            this.eventsManagement();
        }

        // View and Events -------------------------------------------------------------------------------------------------------------------
        public LoginGUI GetView()
        {
            return this.loginGUI;
        }

        private void eventsManagement()
        {
            this.loginGUI.GetLoginButton().Click += new EventHandler(loginPlayer);
            this.loginGUI.GetClearButton().Click += new EventHandler(clearFields);
            this.loginGUI.GetSignUpLinkLabel().Click += new EventHandler(toSignUpView);
            this.loginGUI.GetGameLinkLabel().Click += new EventHandler(toGameView);
        }

        //Events --------------------------------------------------------------------------------------------------------------------------
        private void loginPlayer(object sender, EventArgs e)
        {
            try
            {
                string email = this.loginGUI.GetEmailTextBox().Text;
                string password = this.loginGUI.GetPasswordTextBox().Text;

                Debug.WriteLine(email + " " + password);

                if (this.validInformation(email, password))
                {
                    bool result = this.playerRepository.LoginPlayer(email, password);
                    if (result)
                    {
                        HomeController homeController = new HomeController(this.loginGUI.GetEmailTextBox().Text, this.loginGUI.GetLangComboBox().SelectedIndex);
                        homeController.GetView().Show();
                        this.loginGUI.HideForm();
                    }
                    else
                        this.loginGUI.SetMessage("Failure!", "Login was ended with failure!");

                }
            }
            catch (Exception ex)
            {
                this.loginGUI.SetMessage("Exeption - Login", ex.ToString());
            }
        }

        private void clearFields(object sender, EventArgs e)
        {
            this.loginGUI.GetEmailTextBox().Text = string.Empty;
            this.loginGUI.GetPasswordTextBox().Text = string.Empty;
        }

        private void toSignUpView(object sender, EventArgs e)
        {
            SignUpController signUpController = new SignUpController(this.loginGUI.GetLangComboBox().SelectedIndex);
            signUpController.GetView().Show();
            this.loginGUI.HideForm();
        }

        private void toGameView(object sender, EventArgs e)
        {
            GameController gameController = new GameController(string.Empty, this.loginGUI.GetLangComboBox().SelectedIndex);
            gameController.GetView().Show();
            this.loginGUI.HideForm();
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
        private bool validInformation(string email, string password)
        {
            if (email == null || email.Length == 0)
            {
                this.loginGUI.SetMessage("Incomplete information!", "Email field is empty!");
                return false;
            }

            if (password == null || password.Length == 0)
            {
                this.loginGUI.SetMessage("Incomplete information!", "Password field is empty!");
                return false;
            }
            return true;
        }
    }
}
