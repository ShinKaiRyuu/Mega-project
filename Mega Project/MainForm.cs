using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mega_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Dictionary<string, double> dictionary_Pi_e = new Dictionary<string, double>();
        public Dictionary<string, List<int>> dictionary_Fibonachi_PrimeFactor = new Dictionary<string, List<int>>();


        private void findPiTrackBar_Scroll(object sender, EventArgs e)
        {
            findPiValueLabel.Text = "Value : " + findPiTrackBar.Value.ToString();
            if (findPiAutogenerateCheckbox.Checked)
            {
                findPiGenerateButton_Click(sender, e);
            }
        }

        private void findPiGenerateButton_Click(object sender, EventArgs e)
        {
            double result=0;
            int value = findPiTrackBar.Value;
            string key = "Pi" + value.ToString();
            try
                {
                    dictionary_Pi_e.TryGetValue(key, out result);
                }
            catch(Exception ex)
                {
                   
                }
            if (result == 0)
            {
                dictionary_Pi_e.Add(key, Math.Round(Numbers.Pi, value));
                dictionary_Pi_e.TryGetValue(key, out result);
            }
            findPiResultLabel.Text ="Result: Pi=" + result.ToString();
        }


        private void fineEGenerateButton_Click(object sender, EventArgs e)
        {
            double result = 0;
            int value = findETrackBar.Value;
            string key = "E" + value.ToString();
            try
            {
                dictionary_Pi_e.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {

            }
            if (result == 0)
            {
                dictionary_Pi_e.Add(key, Math.Round(Numbers.e, value));
                dictionary_Pi_e.TryGetValue(key, out result);
            }
            fineEResultLabel.Text = "Result: e=" + result.ToString();
        }


        private void findETrackBar_Scroll(object sender, EventArgs e)
        {
            findEValueLabel.Text = "Value : " + findETrackBar.Value.ToString();
            if (findEAutoenerateCheckBox.Checked)
            {
                fineEGenerateButton_Click(sender, e);
            }
        }

        private void projectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            TabControl currentProjectTabControl = projectTabControl;
            TabPage currentProjectTabPage = currentProjectTabControl.SelectedTab;
            TabControl currentSubprojectTabControl = (TabControl)currentProjectTabPage.Controls[0];
            TabPage currentSubprojectTabPage = currentSubprojectTabControl.SelectedTab;
            string selectedSubprojectTabLabel = ((TabControl)projectTabControl.Controls[projectTabControl.SelectedIndex].Controls[0]).Text;
            this.Text = String.Format("\n Project: {0} Subroject: {1}", currentProjectTabPage.Text, currentSubprojectTabPage.Text);
        }


        private void numbersSubprojectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl currentProjectTabControl = projectTabControl;
            TabPage currentProjectTabPage = currentProjectTabControl.SelectedTab;
            TabControl currentSubprojectTabControl = (TabControl)currentProjectTabPage.Controls[0];
            TabPage currentSubprojectTabPage = currentSubprojectTabControl.SelectedTab;
            this.Text = String.Format("\n Project: {0} Subroject: {1}", currentProjectTabPage.Text, currentSubprojectTabPage.Text);
        }

        private void findFibonachiSequenceGenerateButton_Click(object sender, EventArgs e)
        {
            List<int> result = new List<int>();
            int value = findFibonachiSequenceTrackBar.Value;
            string key = "Fibonachi" + value.ToString();
            try
            {
                dictionary_Fibonachi_PrimeFactor.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {

            }
            if (result == null)
            {
                dictionary_Fibonachi_PrimeFactor.Add(key, Numbers.Fibonachi(value));
                dictionary_Fibonachi_PrimeFactor.TryGetValue(key, out result);
            }
            findFibonachiSequenceResultlabel.Text = String.Format("Result : Fibonachi sequence({0})", value) + string.Join(";", result);
        }

        private void findFibonachiSequenceTrackBar_Scroll(object sender, EventArgs e)
        {
            findFibonachiSequenceValueLabel.Text = "Value : " + findFibonachiSequenceTrackBar.Value.ToString();
            if (findFibonachiSequenceAutogenerateCheckBox.Checked)
            {
                findFibonachiSequenceGenerateButton_Click(sender, e);
            }
        }

        private void findPrimeFactorGenerateButton_Click(object sender, EventArgs e)
        {
            List<int> result = new List<int>();
            int value = findPrimeFactorTrackBar.Value;
            string key = "PrimeFactor" + value.ToString();
            try
            {
                dictionary_Fibonachi_PrimeFactor.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {

            }
            if (result == null)
            {
                dictionary_Fibonachi_PrimeFactor.Add(key, Numbers.PrimeFactor(value));
                dictionary_Fibonachi_PrimeFactor.TryGetValue(key, out result);
            }
            findPrimeFactorResultLabel.Text = String.Format("Result : Prime factors for ({0})", value) + string.Join(";", result);
        }

        private void findPrimeFactorTrackBar_Scroll(object sender, EventArgs e)
        {
            findPrimeFactorValueLabel.Text = "Value : " + findPrimeFactorTrackBar.Value.ToString();
            if (findPrimeFactorAutogenerateCheckBox.Checked)
            {
                findPrimeFactorGenerateButton_Click(sender, e);
            }
        }
    }
}
