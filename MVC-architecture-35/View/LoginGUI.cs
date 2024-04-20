using MVC_architecture_35.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MVVM_architecture_35.View
{
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
            InitializeComponentLang();
        }

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

        private void langComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.langComboBox.SelectedIndex == 0) 
                LangHelper.ChangeLanguage("en");
            else if (this.langComboBox.SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if(this.langComboBox.SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            Debug.WriteLine(this.langComboBox.SelectedIndex);
            InitializeComponentLang();
        }
    }
}
