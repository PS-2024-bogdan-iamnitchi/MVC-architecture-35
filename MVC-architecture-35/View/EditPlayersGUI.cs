using MVC_architecture_35.Language;
using MVC_architecture_35.View;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public partial class EditPlayersGUI : Form, IGUI
    {
        public EditPlayersGUI(int index)
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

        public NumericUpDown GetIdNUD()
        {
            return this.nudPlayerID;
        }

        public TextBox GetFullNameTextBox()
        {
            return this.fullNameTextBox;
        }

        public NumericUpDown GetAgeNUD()
        {
            return this.nudAge;
        }

        public TextBox GetEmailTextBox()
        {
            return this.emailTextBox;
        }

        public NumericUpDown GetScoreNUD()
        {
            return this.nudScore;
        }

        public TextBox GetPasswordTextBox()
        {
            return this.passwordTextBox;
        }

        public TextBox GetSearchTextBox()
        {
            return this.searchTextBox;
        }

        public Button GetLoadButton()
        {
            return this.loadButton;
        }

        public Button GetAddButton()
        {
            return this.addButton;
        }

        public Button GetUpdateButton()
        {
            return this.updateButton;
        }

        public Button GetDeleteButton()
        {
            return this.deleteButton;
        }

        public Button GetSearchButton()
        {
            return this.searchButton;
        }

        public Button GetBackButton()
        {
            return this.backButton;
        }

        public DataGridView GetPlayersTable()
        {
            return this.playersDataGridView;
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
            this.editPlayersTitle.Text = LangHelper.GetString("editPlayerTitle");
            this.playerIDLabel.Text = LangHelper.GetString("playerdIDLabel");
            this.fullNameLabel.Text = LangHelper.GetString("fullNameLabel");
            this.ageLabel.Text = LangHelper.GetString("ageLabel");
            this.emailLabel.Text = LangHelper.GetString("emailLabel");
            this.scoreLabel.Text = LangHelper.GetString("scoreLabel");
            this.passwordLabel.Text = LangHelper.GetString("passwordLabel");
            this.backButton.Text = LangHelper.GetString("backBtn");
            this.searchButton.Text = LangHelper.GetString("searchBtn");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
