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

        public Label GetEditPlayersTitleLabel()
        {
            return this.editPlayersTitle;
        }

        public Label GetPlayerIDLabel()
        {
            return this.playerIDLabel;
        }

        public Label GetFullNameLabel()
        {
            return this.fullNameLabel;
        }

        public Label GetAgeLabel()
        {
            return this.ageLabel;
        }

        public Label GetEmailLabel()
        {
            return this.emailLabel;
        }

        public Label GetScoreLabel()
        {
            return this.scoreLabel;
        }

        public Label GetPasswordLabel()
        {
            return this.passwordLabel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
