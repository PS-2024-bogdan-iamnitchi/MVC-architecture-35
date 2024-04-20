using MVC_architecture_35.Language;
using MVC_architecture_35.Model;
using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_architecture_35.Controller
{
    public class SignUpController
    {
        private SignUpGUI signUpGUI;
        private PlayerRepository playerRepository;

        public SignUpController(int index)
        {
            this.signUpGUI = new SignUpGUI(index);
            this.playerRepository = new PlayerRepository();

            this.initializeComponentLang();

            //handle events
            this.eventsManagement();
        }

        // View and Events -------------------------------------------------------------------------------------------------------------------
        public SignUpGUI GetView()
        {
            return this.signUpGUI;
        }

        private void eventsManagement()
        {
            this.signUpGUI.GetLangComboBox().SelectedIndexChanged += new EventHandler(selectIndexCallback);

            this.signUpGUI.GetSignUpButton().Click += new EventHandler(signUpPlayer);
            this.signUpGUI.GetClearButton().Click += new EventHandler(clearFields);
            this.signUpGUI.GetLoginLinkLabel().Click += new EventHandler(clearFields);
        }

        //Events --------------------------------------------------------------------------------------------------------------------------
        private void signUpPlayer(object sender, EventArgs e)
        {
            try
            {
                Player player = this.validInformation();
                if (player != null)
                {
                    bool result = this.playerRepository.SignUpPlayer(player);
                    if (result)
                    {
                        this.signUpGUI.SetMessage("Success!", "New account was created successfully!");
                        LoginController loginController = new LoginController(this.signUpGUI.GetLangComboBox().SelectedIndex);
                        loginController.GetView().Show();
                        this.signUpGUI.HideForm();
                    }
                    else
                        this.signUpGUI.SetMessage("Failure!", "Adding was ended with failure!");

                }
            }
            catch (Exception ex)
            {
                this.signUpGUI.SetMessage("Exeption - SignUp", ex.ToString());
            }
        }

        private void clearFields(object sender, EventArgs e)
        {
            this.signUpGUI.GetFullNameTextBox().Text = string.Empty;
            this.signUpGUI.GetEmailTextBox().Text = string.Empty;
            this.signUpGUI.GetAgeNUD().Value = 0;
            this.signUpGUI.GetPasswordTextBox().Text = string.Empty;
        }

        private void toLoginView(object sender, EventArgs e)
        {
            LoginController loginController = new LoginController(this.signUpGUI.GetLangComboBox().SelectedIndex);
            loginController.GetView().Show();
            this.signUpGUI.HideForm();
        }

        private void selectIndexCallback(object sender, EventArgs e)
        {
            if (this.signUpGUI.GetLangComboBox().SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.signUpGUI.GetLangComboBox().SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.signUpGUI.GetLangComboBox().SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            initializeComponentLang();
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
        private Player validInformation()
        {
            string fullName = this.signUpGUI.GetFullNameTextBox().Text;
            if (fullName == null || fullName.Length == 0)
            {
                this.signUpGUI.SetMessage("Incomplete information!", "Player name is empty!");
                return null;
            }
            string email = this.signUpGUI.GetEmailTextBox().Text;
            if (email == null || email.Length == 0)
            {
                this.signUpGUI.SetMessage("Incomplete information!", "Email field is empty!");
                return null;
            }
            uint age = (uint)this.signUpGUI.GetAgeNUD().Value;
            if (age <= 10)
            {
                this.signUpGUI.SetMessage("Incomplete information!", "Player age must be greater or equal with 10!");
                return null;
            }
            string password = this.signUpGUI.GetPasswordTextBox().Text;
            if (password == null || password.Length == 0)
            {
                this.signUpGUI.SetMessage("Incomplete information!", "Password field is empty!");
                return null;
            }
            //string encryptPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return new Player(fullName, email, age, password);
        }

        private void initializeComponentLang()
        {
            this.signUpGUI.GetSignUpTitleLabel().Text = LangHelper.GetString("signUpTitle");
            this.signUpGUI.GetFullNameLabel().Text = LangHelper.GetString("fullNameLabel");
            this.signUpGUI.GetEmailLabel().Text = LangHelper.GetString("emailLabel");
            this.signUpGUI.GetAgeLabel().Text = LangHelper.GetString("ageLabel");
            this.signUpGUI.GetPasswordLabel().Text = LangHelper.GetString("passwordLabel");
            this.signUpGUI.GetClearButton().Text = LangHelper.GetString("clearBtn");
            this.signUpGUI.GetSignUpButton().Text = LangHelper.GetString("signUpBtn");
            this.signUpGUI.GetSignUpLabel().Text = LangHelper.GetString("signUpText");
            this.signUpGUI.GetLoginLinkLabel().Text = LangHelper.GetString("loginTxt");
        }
    }
}
