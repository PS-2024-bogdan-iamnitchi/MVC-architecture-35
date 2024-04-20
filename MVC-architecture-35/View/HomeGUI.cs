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

        //Labels
        public Label GetHomeTitleLabel()
        {
            return this.homeTitle;
        }

        public Label GetHomeText11Label()
        {
            return this.homeText11;
        }

        public Label GetHomeText12Label()
        {
            return this.homeText12;
        }

        public Label GetHomeText21Label()
        {
            return this.homeText21;
        }

        public Label GetHomeText22Label()
        {
            return this.homeText22;
        }

        public Label GetHomeText31Label()
        {
            return this.homeText31;
        }

        public Label GetHomeText32Label()
        {
            return this.homeText32;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
