using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Mega_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }

        public Dictionary<string, Tuple<double, string>> dictionary_Pi = new Dictionary<string, Tuple<double, string>>();
        public Dictionary<string, Tuple<double, string>> dictionary_e = new Dictionary<string, Tuple<double, string>>();
        public Dictionary<string, List<int>> dictionary_Fibonachi = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> dictionary_PrimeFactor = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> dictionary_PrimeNumber = new Dictionary<string, List<int>>();

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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int value = findPiTrackBar.Value;
            Tuple<double, string> result = null;
            string key = "Pi" + value.ToString();
            string common = "";
            double countedPi;
            try
            {
                dictionary_Pi.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                countedPi = Numbers.CountingPi(value);
                common = Numbers.CommonPrefix(new[] { countedPi.ToString(), Numbers.Pi.ToString() });
                dictionary_Pi.Add(key, new Tuple<double, string>(countedPi, common));
                dictionary_Pi.TryGetValue(key, out result);

            }
            countedPi = result.Item1;
            common = result.Item2;
            findPiEtalonPiLabel.Text = "Etalon : Pi =" + Numbers.Pi.ToString();
            findPiResultLabel.Text = "Result : Pi =" + countedPi.ToString();
            findPiCommonPartWithEtalonLabel.Text = "Common :   " + common;
            sw.Stop();
            debugRichTextBox.Text = sw.Elapsed.ToString();
        }
        private void fineEGenerateButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int value = findETrackBar.Value;
            Tuple<double, string> result = null;
            string key = "E" + value.ToString();
            string common = "";
            double countedE;
            try
            {
                dictionary_e.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                countedE = Numbers.CountingE(value);
                common = Numbers.CommonPrefix(new[] { countedE.ToString(), Numbers.e.ToString() });
                dictionary_e.Add(key, new Tuple<double, string>(countedE, common));
                dictionary_e.TryGetValue(key, out result);
            }
            countedE = result.Item1;
            common = result.Item2;
            findEEtalonELabel.Text = "Etalon : E =" + Numbers.e.ToString();
            findEResultLabel.Text = "Result : E =" + countedE.ToString();
            findECommonPartWithEtalonLabel.Text = "Common :   " + common;
            sw.Stop();
            debugRichTextBox.Text = sw.Elapsed.ToString();
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
                dictionary_Fibonachi.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                dictionary_Fibonachi.Add(key, Numbers.Fibonachi(value));
                dictionary_Fibonachi.TryGetValue(key, out result);
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
                dictionary_PrimeFactor.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                dictionary_PrimeFactor.Add(key, Numbers.PrimeFactor(value));
                dictionary_PrimeFactor.TryGetValue(key, out result);
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
        private void findPrimeNumberGenerateButton_Click(object sender, EventArgs e)
        {
            List<int> result = new List<int>();
            int value = findPrimeNumberTrackBar.Value;
            string key = "PrimeNumber" + value.ToString();
            try
            {
                dictionary_PrimeNumber.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                dictionary_PrimeNumber.Add(key, Numbers.PrimeNumbers(start: 0, count: value));
                dictionary_PrimeNumber.TryGetValue(key, out result);
            }
            findPrimeNumberResultLabel.Text = String.Format("Result : Prime numbers ({0})", value) + string.Join(";", result);
        }
        private void findPrimeNumberTrackBar_Scroll(object sender, EventArgs e)
        {
            findPrimeNumberValueLabel.Text = "Value : " + findPrimeNumberTrackBar.Value.ToString();
            if (findPrimeNumberAutogenerateCheckBox.Checked)
            {
                findPrimeNumberGenerateButton_Click(sender, e);
            }
        }

        Graphics g1;
        Graphics g2;
        ArrayList array1;
        ArrayList array2;
        Bitmap bmpsave1;
        Thread thread1;
        static Random rand = new Random();

        private void cmdSort_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
                thread1.Join();
            }

            PrepareForSort();

            int speed = 1;
            for (int i = 0; i < tbSpeed.Value; i++)
            {
                speed *= 2;
            }
            string alg1 = "";
            Sorting srt = new Sorting(array1, pnlSort1,speed);
            ThreadStart ts = delegate () { srt.BubbleSort(array1); srt.draw.finishDrawing();


                if (!isSorted(array1))
                    MessageBox.Show("#1 Sort Failed!");
            };
            thread1 = new Thread(ts);
            thread1.Start();
        }

        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rand.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private bool isSorted(IList checkThis)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }

        private void PrepareForSort()
        {
            bmpsave1 = new Bitmap(pnlSort1.Width, pnlSort1.Height);
            g1 = Graphics.FromImage(bmpsave1);

            pnlSort1.Image = bmpsave1;

            array1 = new ArrayList(tbSamples.Value);
            array2 = new ArrayList(tbSamples.Value);
            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / array1.Capacity * pnlSort1.Height);
                array1.Add(y);
            }
            Randomize(array1);

            array2 = (ArrayList)array1.Clone();
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            cboAlg1.SelectedIndex = cboAlg1.Items.IndexOf("Bubble Sort");
            tbSamples.Value = 100;
            ddTypeOfData.SelectedIndex = ddTypeOfData.Items.IndexOf("Random");
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
