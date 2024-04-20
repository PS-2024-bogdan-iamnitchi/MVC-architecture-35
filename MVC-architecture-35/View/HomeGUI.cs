using MVC_architecture_35.Language;
using MVC_architecture_35.View;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public partial class HomeGUI : Form, IGUI
    {
        public HomeGUI(int index)
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

        public Button GetPlayGameButton()
        {
            return this.playGameButton;
        }

        public Button GetAdminButton()
        {
            return this.adminButton;
        }

        public Button GetSignOutButton()
        {
            return this.signOutButton;
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
            this.homeTitle.Text = LangHelper.GetString("homeTitle");
            this.homeText11.Text = LangHelper.GetString("homeText11");
            this.homeText12.Text = LangHelper.GetString("homeText12");
            this.homeText21.Text = LangHelper.GetString("homeText21");
            this.homeText22.Text = LangHelper.GetString("homeText22");
            this.homeText31.Text = LangHelper.GetString("homeText31");
            this.homeText32.Text = LangHelper.GetString("hometext32");
            this.signOutButton.Text = LangHelper.GetString("signOutBtn");
            this.adminButton.Text = LangHelper.GetString("adminBtn");
            this.playGameButton.Text = LangHelper.GetString("playGameBtn");
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
