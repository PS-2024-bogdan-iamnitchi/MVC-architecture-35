using MVC_architecture_35.Language;
using MVC_architecture_35.View;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MVC_architecture_35.View
{
    public partial class StatisticGUI : Form, IGUI
    {
        public StatisticGUI(int index)
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
        public ComboBox GetCriterionComboBox()
        {
            return this.criterionComboBox;
        }

        public Button GetBackButton()
        {
            return this.backButton;
        }
        public Button GetExitButton()
        {
            return this.exitButton;
        }
        
        public Chart GetChart()
        {
            return this.statisticsChart;
        }

        //Labels
        public Label GetStatistcsTitleLabel()
        {
            return this.statisticsTitle;
        }

        public Label GetCriterionLabel()
        {
            return this.criterionLabel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }
    }
}
