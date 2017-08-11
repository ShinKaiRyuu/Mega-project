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

            if (ddTypeOfData.SelectedItem.ToString() == "Random")
            {
                // ready to go
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Sorted")
            {
                array1.Sort();
                array2 = (ArrayList)array1.Clone();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Nearly Sorted")
            {
                array1.Sort();

                int maxValue = array1.Count / 10;

                // move anywhere from 2 items to 20% of the items
                int itemsToMove = rand.Next(1, maxValue);
                for (int i = 0; i < itemsToMove; i++)
                {
                    int a = rand.Next(0, array1.Count);
                    int b = rand.Next(0, array1.Count);

                    while (a == b)
                    {
                        a = rand.Next(0, array1.Count);
                        b = rand.Next(0, array1.Count);
                    }

                    object temp = array1[a];
                    array1[a] = array1[b];
                    array1[b] = temp;
                }

                array2 = (ArrayList)array1.Clone();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Reversed")
            {
                array1.Sort();
                array1.Reverse();

                array2 = (ArrayList)array1.Clone();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Few Unique")
            {
                int maxValue = 10;

                if (array1.Count < 100)
                    maxValue = 6;

                // choose a random amount of unique values
                maxValue = rand.Next(2, maxValue);

                ArrayList temp = new ArrayList();
                for (int i = 0; i < maxValue; i++)
                {
                    int y = (int)((double)(i + 1) / maxValue * pnlSort1.Height);
                    temp.Add(y);
                }

                for (int i = 0; i < array1.Count; i++)
                {
                    array1[i] = temp[rand.Next(0, maxValue)];
                }

                array2 = (ArrayList)array1.Clone();
            }

            int speed = 1;
            for (int i = 0; i < tbSpeed.Value; i++)
            {
                speed *= 2;
            }
            string alg1 = "";
            if (cboAlg1.SelectedItem != null)
                alg1 = cboAlg1.SelectedItem.ToString();
            Sorting srt = null;
            srt = new Sorting(array1, pnlSort1, speed);
            
            ThreadStart ts = delegate ()
            {
                switch (alg1)
                {
                    case "BiDirectional Bubble Sort":
                        srt.BiDirectionalBubbleSort(array1);
                        break;
                    case "Bubble Sort":
                        srt.BubbleSort(array1);
                        break;
                    case "Comb Sort":
                        srt.CombSort(array1);
                        break;
                    case "Counting Sort":
                        srt.CountingSort(array1);
                        break;
                    case "Cycle Sort":
                        srt.CycleSort(array1);
                        break;
                    case "Gnome Sort":
                        srt.GnomeSort(array1);
                        break;
                    case "Heap Sort":
                        srt.HeapSort(array1);
                        break;
                    case "Insertion Sort":
                        srt.InsertionSort(array1);
                        break;
                    case "Merge Sort (In Place)":
                        srt.MergeSortInPlace(array1, 0, array1.Count - 1);
                        break;
                    case "Merge Sort (Double Storage)":
                        srt.MergeSortDoubleStorage(array1, 0, array1.Count - 1);
                        break;
                    case "Odd-Even Sort":
                        srt.OddEvenSort(array1);
                        break;
                    case "Pigeonhole Sort":
                        srt.PigeonholeSort(array1);
                        break;
                    case "Quicksort":
                        srt.Quicksort(array1, 0, array1.Count - 1);
                        break;
                    case "Quicksort with Insertion Sort":
                        srt.QuicksortWithInsertionSort(array1, 0, array1.Count - 1);
                        break;
                    case "Radix Sort":
                        srt.RadixSort(array1);
                        break;
                    case "Selection Sort":
                        srt.SelectionSort(array1);
                        break;
                    case "Shell Sort":
                        srt.ShellSort(array1);
                        break;
                    case "Smoothsort":
                        srt.Smoothsort(array1);
                        break;
                    case "Timsort":
                        srt.Timsort(array1, 0, array1.Count);
                        break;
                }

                srt.draw.finishDrawing();

                SetText("compare:" + srt.operations_compare.ToString() + " swap:" + srt.operations_swap.ToString());
                
                if (!isSorted(array1))
                    MessageBox.Show("#1 Sort Failed!");
            };
            
            if (alg1 != "")
            {
                thread1 = new Thread(ts);
                thread1.Start();
            }
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
            resize_controls();
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.debugRichTextBox.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.debugRichTextBox.Text = text;
            }
        }

        private void resize_controls()
        {
            projectTabControl.Width = this.Width - 40;
            projectTabControl.Height = this.Height - 199;

            numbersSubprojectTabControl.Width = this.Width - 60;
            numbersSubprojectTabControl.Height = this.Height - 237;

            visualisingSubProjectTabControl.Width = this.Width - 60;
            visualisingSubProjectTabControl.Height = this.Height - 237;

            debugLabel.Left = 16;
            debugLabel.Top = this.Height - 180;

            debugRichTextBox.Left = 16;
            debugRichTextBox.Top = this.Height - 161;

            pnlSort1.Height = this.Height - 276;
            pnlSort1.Width = this.Width - 470;
        }

        private void cmdSuspend_Click(object sender, EventArgs e)
        {
            thread1.Suspend();
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
            thread1.Resume();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
