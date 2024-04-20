using MVC_architecture_35.Language;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MVVM_architecture_35.View
{
    public partial class GameGUI : Form
    {
        public GameGUI()
        {
            InitializeComponent();
            InitializeComponentLang();
        }

        private void InitializeComponentLang()
        {
            this.gameTitle.Text = LangHelper.GetString("gameTitle");
            this.loggedInPlayerScoreLabel.Text = LangHelper.GetString("savedScoreLabel");
            this.levelLabel.Text = LangHelper.GetString("levelLabel");
            this.oponentLabel.Text = LangHelper.GetString("opoMovesLabel");
            this.playerLabel.Text = LangHelper.GetString("plyMovesLabel");
            this.opoScoreLabel.Text = LangHelper.GetString("opoScoreLabel");
            this.plyScoreLabel.Text = LangHelper.GetString("plyScoreLabel");
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
