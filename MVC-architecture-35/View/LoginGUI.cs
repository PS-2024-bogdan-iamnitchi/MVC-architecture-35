using MVC_architecture_35.Language;
using MVC_architecture_35.View;
using System;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public partial class LoginGUI : Form, IGUI
    {
        public LoginGUI(int index)
        {
            InitializeComponent();

            this.langComboBox.SelectedIndex = index;
        }

        // Get / Set ---------------------------------------------------------------------------------------------------------------------------
        public void SetMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        public void HideForm()
        {
            this.Hide();
        }

        public ComboBox GetLangComboBox()
        {
            return this.langComboBox;
        }

        public TextBox GetEmailTextBox()
        {
            return this.emailTextBox;
        }

        public TextBox GetPasswordTextBox()
        {
            return this.passwordTextBox;
        }

        public Button GetLoginButton()
        {
            return this.loginButton;
        }

        public Button GetClearButton()
        {
            return this.clearButton;
        }

        public LinkLabel GetSignUpLinkLabel()
        {
            return this.signUpLinkLabel;
        }

        public LinkLabel GetGameLinkLabel()
        {
            return this.playGameLinkedLabel;
        }

        //Labels
        public Label GetLoginTitleLabel()
        {
            return this.loginTitle;
        }

        public Label GetEmailLabel()
        {
            return this.emailLabel;
        }

        public Label GetPasswordLabel()
        {
            return this.passwordLabel;
        }

        public Label GetLoginText1TextBox()
        {
            return this.loginText1;
        }

        public Label GetLoginText2TextBox()
        {
            return this.loginText2;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
