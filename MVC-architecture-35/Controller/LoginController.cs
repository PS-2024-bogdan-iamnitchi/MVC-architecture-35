using MVC_architecture_35.Language;
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

            this.initializeComponentLang();

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
            this.loginGUI.GetLangComboBox().SelectedIndexChanged += new EventHandler(selectIndexCallback);

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
                        this.loginGUI.SetMessage(LangHelper.GetString("failure"), LangHelper.GetString("loginFailure"));

                }
            }
            catch (Exception ex)
            {
                this.loginGUI.SetMessage(LangHelper.GetString("exception"), ex.ToString());
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

        private void selectIndexCallback(object sender, EventArgs e)
        {
            if (this.loginGUI.GetLangComboBox().SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.loginGUI.GetLangComboBox().SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.loginGUI.GetLangComboBox().SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            initializeComponentLang();
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
        private bool validInformation(string email, string password)
        {
            if (email == null || email.Length == 0)
            {
                this.loginGUI.SetMessage(LangHelper.GetString("incompleteInfo"), LangHelper.GetString("validinfoEmail"));
                return false;
            }

            if (password == null || password.Length == 0)
            {
                this.loginGUI.SetMessage(LangHelper.GetString("incompleteInfo"), LangHelper.GetString("validinfoPassword"));
                return false;
            }
            return true;
        }

        private void initializeComponentLang()
        {
            this.loginGUI.GetLoginTitleLabel().Text = LangHelper.GetString("loginTitle");
            this.loginGUI.GetEmailLabel().Text = LangHelper.GetString("emailLabel");
            this.loginGUI.GetPasswordLabel().Text = LangHelper.GetString("passwordLabel");
            this.loginGUI.GetClearButton().Text = LangHelper.GetString("clearBtn");
            this.loginGUI.GetLoginButton().Text = LangHelper.GetString("loginBtn");
            this.loginGUI.GetLoginText1TextBox().Text = LangHelper.GetString("loginText1");
            this.loginGUI.GetSignUpLinkLabel().Text = LangHelper.GetString("createAccountTxt");
            this.loginGUI.GetLoginText2TextBox().Text = LangHelper.GetString("loginText2");
            this.loginGUI.GetGameLinkLabel().Text = LangHelper.GetString("playGameTxt");
        }
    }
}
