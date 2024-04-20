using MVC_architecture_35.Language;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MVVM_architecture_35.View
{
    public partial class HomeGUI : Form
    {
        public HomeGUI()
        {
            InitializeComponent();
            InitializeComponentLang();
        }

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
