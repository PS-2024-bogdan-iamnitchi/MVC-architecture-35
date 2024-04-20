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
    }
}
