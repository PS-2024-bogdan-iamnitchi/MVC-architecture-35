using MVC_architecture_35.Language;
using MVC_architecture_35.View;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public partial class SignUpGUI : Form, IGUI
    {
        public SignUpGUI(int index)
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

        public TextBox GetFullNameTextBox()
        {
            return this.fullNameTextBox;
        }

        public TextBox GetEmailTextBox()
        {
            return this.emailTextBox;
        }

        public NumericUpDown GetAgeNUD()
        {
            return this.ageNumUpDown;
        }

        public TextBox GetPasswordTextBox()
        {
            return this.passwordTextBox;
        }

        public Button GetSignUpButton()
        {
            return this.signUpButton;
        }

        public Button GetClearButton()
        {
            return this.clearButton;
        }

        public LinkLabel GetLoginLinkLabel()
        {
            return this.loginLinkedLabel;
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
            this.signUpTitle.Text = LangHelper.GetString("signUpTitle");
            this.fullNameLabel.Text = LangHelper.GetString("fullNameLabel");
            this.emailLabel.Text = LangHelper.GetString("emailLabel");
            this.ageLabel.Text = LangHelper.GetString("ageLabel");
            this.passwordLabel.Text = LangHelper.GetString("passwordLabel");
            this.clearButton.Text = LangHelper.GetString("clearBtn");
            this.signUpButton.Text = LangHelper.GetString("signUpBtn");
            this.signUpText.Text = LangHelper.GetString("signUpText");
            this.loginLinkedLabel.Text = LangHelper.GetString("loginTxt");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
