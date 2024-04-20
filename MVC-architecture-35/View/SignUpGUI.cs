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

        //Labels
        public Label GetSignUpTitleLabel()
        {
            return this.signUpTitle;
        }

        public Label GetFullNameLabel()
        {
            return this.fullNameLabel;
        }

        public Label GetEmailLabel()
        {
            return this.emailLabel;
        }

        public Label GetAgeLabel()
        {
            return this.ageLabel;
        }

        public Label GetPasswordLabel()
        {
            return this.passwordLabel;
        }

        public Label GetSignUpLabel()
        {
            return this.signUpText;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
