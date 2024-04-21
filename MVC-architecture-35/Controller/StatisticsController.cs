using MVC_architecture_35.Language;
using MVC_architecture_35.Model.Repository;
using MVC_architecture_35.Model;
using MVC_architecture_35.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace MVC_architecture_35.Controller
{
    public class StatisticsController
    {
        private StatisticGUI statisticGUI;
        private PlayerRepository playerRepository;
        private PlayerStatistics playerStatistics;
        private Player loggedInPlayer;

        public StatisticsController(string loggedInPlayerEmail, int index)
        {
            this.statisticGUI = new StatisticGUI(index);
            this.playerRepository = new PlayerRepository();
            this.playerStatistics = new PlayerStatistics(playerRepository.GetPlayersTable());
            this.loggedInPlayer = getLoggedInPlayer(loggedInPlayerEmail);

            this.statisticGUI.GetCriterionComboBox().SelectedIndex = 0;
            this.graphicRepresentation(null, null);
            this.initializeComponentLang();

            //handle events
            this.eventsManagement();
        }

        // View and Events ----------------------------------------------------------------------------------------------------------------------
        public StatisticGUI GetView()
        {
            return this.statisticGUI;
        }

        private void eventsManagement()
        {
            this.statisticGUI.GetLangComboBox().SelectedIndexChanged += new EventHandler(selectIndexCallback);

            this.statisticGUI.GetCriterionComboBox().SelectedIndexChanged += new EventHandler(graphicRepresentation);
            this.statisticGUI.GetBackButton().Click += new EventHandler(toHomeView);
            this.statisticGUI.GetExitButton().Click += new EventHandler(exitApplication);
        }

        private void selectIndexCallback(object sender, EventArgs e)
        {
            if (this.statisticGUI.GetLangComboBox().SelectedIndex == 0)
                LangHelper.ChangeLanguage("en");
            else if (this.statisticGUI.GetLangComboBox().SelectedIndex == 1)
                LangHelper.ChangeLanguage("fr");
            else if (this.statisticGUI.GetLangComboBox().SelectedIndex == 2)
                LangHelper.ChangeLanguage("de");
            initializeComponentLang();
        }

        //Events ---------------------------------------------------------------------------------------------------------------------------------
        private void graphicRepresentation(object sender, EventArgs e)
        {
            string criterion = this.statisticGUI.GetCriterionComboBox().SelectedItem.ToString();
            this.playerStatistics.Criterion = criterion;
            Dictionary<string, uint> dictionary = this.playerStatistics.Result;

            if (criterion == "Score")
                columnChart(dictionary, criterion);
            else
                pieChart(dictionary, criterion);
        }

        public void columnChart(Dictionary<string, uint> dictionary, string criterion)
        {
            if (dictionary != null)
            {
                this.statisticGUI.GetChart().Series.Clear();
                this.statisticGUI.GetChart().Legends.Clear();
                this.statisticGUI.GetChart().Legends.Add(criterion);
                this.statisticGUI.GetChart().Legends[0].LegendStyle = LegendStyle.Table;
                this.statisticGUI.GetChart().Legends[0].Docking = Docking.Bottom;
                this.statisticGUI.GetChart().Legends[0].Alignment = StringAlignment.Center;
                this.statisticGUI.GetChart().Legends[0].Title = criterion;
                this.statisticGUI.GetChart().Legends[0].BorderColor = System.Drawing.Color.Black;
                this.statisticGUI.GetChart().Series.Add(criterion);
                this.statisticGUI.GetChart().Series[criterion].ChartType = SeriesChartType.Column;
                foreach (KeyValuePair<string, uint> pair in dictionary)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueXY(pair.Key, pair.Value);
                    if (loggedInPlayer.FullName.Equals(pair.Key, StringComparison.OrdinalIgnoreCase))
                        point.Color = System.Drawing.Color.Purple;
                    this.statisticGUI.GetChart().Series[criterion].Points.Add(point);
                }

                List<uint> values = dictionary.Values.ToList();
                double sum = 0.0;
                foreach(uint value in values)
                    sum += value;
                
                StripLine stripline = new StripLine();
                stripline.Interval = 0;
                stripline.IntervalOffset = sum / values.Count;
                stripline.StripWidth = 0.0;
                stripline.BorderColor = System.Drawing.Color.Red;
                stripline.BorderDashStyle = ChartDashStyle.Dash;
                stripline.BorderWidth = 4;
                string name = this.statisticGUI.GetChart().ChartAreas[0].Name;
                this.statisticGUI.GetChart().ChartAreas[name].AxisY.StripLines.Add(stripline);

                foreach (DataPoint p in this.statisticGUI.GetChart().Series[criterion].Points)
                    p.Label = "#PERCENT";
            }
            else
                this.statisticGUI.SetMessage(LangHelper.GetString("empty"), LangHelper.GetString("playerListEmpty"));
        }

        public void pieChart(Dictionary<string, uint> dictionary, string criterion)
        {
            if (dictionary != null)
            {
                this.statisticGUI.GetChart().Series.Clear();
                this.statisticGUI.GetChart().Legends.Clear();
                this.statisticGUI.GetChart().Legends.Add(criterion);
                this.statisticGUI.GetChart().Legends[0].LegendStyle = LegendStyle.Table;
                this.statisticGUI.GetChart().Legends[0].Docking = Docking.Bottom;
                this.statisticGUI.GetChart().Legends[0].Alignment = StringAlignment.Center;
                this.statisticGUI.GetChart().Legends[0].Title = criterion;
                this.statisticGUI.GetChart().Legends[0].BorderColor = System.Drawing.Color.Black;
                this.statisticGUI.GetChart().Series.Add(criterion);
                this.statisticGUI.GetChart().Series[criterion].ChartType = SeriesChartType.Pie;
                foreach (KeyValuePair<string, uint> pair in dictionary)
                    this.statisticGUI.GetChart().Series[criterion].Points.AddXY(pair.Key, pair.Value);
                foreach (DataPoint p in this.statisticGUI.GetChart().Series[criterion].Points)
                    p.Label = "#PERCENT";
                this.statisticGUI.GetChart().Series[criterion].LegendText = "#VALX";
            }
            else
                this.statisticGUI.SetMessage(LangHelper.GetString("empty"), LangHelper.GetString("playerListEmpty"));
        }

        private void toHomeView(object sender, EventArgs e)
        {
            HomeController homeController = new HomeController(this.loggedInPlayer.Email, this.statisticGUI.GetLangComboBox().SelectedIndex);
            homeController.GetView().Show();
            this.statisticGUI.HideForm();
        }

        private void exitApplication(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //Controller specific methods -------------------------------------------------------------------------------------------------------------
        private Player getLoggedInPlayer(string email)
        {
            Player player = null;

            try
            {
                if (email != null && email.Length != 0)
                {
                    player = this.playerRepository.GetPlayerByEmail(email);
                }
            }
            catch (Exception ex)
            {
                this.statisticGUI.SetMessage(LangHelper.GetString("exception"), ex.ToString());
            }
            return player;
        }

        private void initializeComponentLang()
        {
            this.statisticGUI.GetStatistcsTitleLabel().Text = LangHelper.GetString("statistics");
            this.statisticGUI.GetCriterionLabel().Text = LangHelper.GetString("criterion");
            this.statisticGUI.GetBackButton().Text = LangHelper.GetString("backBtn");
            this.statisticGUI.GetExitButton().Text = LangHelper.GetString("exitBtn");
        }
    }
}
