using MVC_architecture_35.Language;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVVM_architecture_35.View
{
    public partial class SignUpGUI : Form
    {
        public SignUpGUI()
        {
            InitializeComponent();
            InitializeComponentLang();
        }

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

        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.langComboBox.SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.langComboBox.SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.langComboBox.SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            Debug.WriteLine(this.langComboBox.SelectedIndex);
            InitializeComponentLang();
        }
    }
}
