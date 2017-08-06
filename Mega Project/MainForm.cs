using System;
using System.Windows.Forms;

namespace Mega_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


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
            findPiResultLabel.Text ="Result: Pi=" + Math.Round(Numbers.Pi, findPiTrackBar.Value).ToString();
        }


        private void fineEGenerateButton_Click(object sender, EventArgs e)
        {
            fineEResultLabel.Text = "Result: e=" + Math.Round(Numbers.e, findETrackBar.Value).ToString();
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
            findFibonachiSequenceResultlabel.Text = String.Format("Result : Fibonachi sequence({0})",findFibonachiSequenceTrackBar.Value) + string.Join(";",Numbers.Fibonachi(findFibonachiSequenceTrackBar.Value));
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
            findPrimeFactorResultLabel.Text = String.Format("Result : Prime factors for ({0})", findPrimeFactorTrackBar.Value) + string.Join(";", Numbers.PrimeFactor(findPrimeFactorTrackBar.Value));
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
