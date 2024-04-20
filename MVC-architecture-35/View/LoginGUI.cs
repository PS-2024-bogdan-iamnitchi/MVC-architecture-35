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
            InitializeComponentLang();

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

        // Events ------------------------------------------------------------------------------------------------------------------------------
        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.langComboBox.SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.langComboBox.SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.langComboBox.SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            InitializeComponentLang();
        }

        // GUI only ----------------------------------------------------------------------------------------------------------------------------
        private void InitializeComponentLang()
        {
            this.loginTitle.Text = LangHelper.GetString("loginTitle");
            this.emailLabel.Text = LangHelper.GetString("emailLabel");
            this.passwordLabel.Text = LangHelper.GetString("passwordLabel");
            this.clearButton.Text = LangHelper.GetString("clearBtn");
            this.loginButton.Text = LangHelper.GetString("loginBtn");
            this.loginText1.Text = LangHelper.GetString("loginText1");
            this.signUpLinkLabel.Text = LangHelper.GetString("createAccountTxt");
            this.loginText2.Text = LangHelper.GetString("loginText2");
            this.playGameLinkedLabel.Text = LangHelper.GetString("playGameTxt");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
