using MVC_architecture_35.Language;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVVM_architecture_35.View
{
    public partial class EditPlayersGUI : Form
    {
        public EditPlayersGUI()
        {
            InitializeComponent();
            InitializeComponentLang();
        }

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
