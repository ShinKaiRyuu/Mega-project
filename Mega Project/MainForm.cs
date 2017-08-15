using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ThreadState = System.Threading.ThreadState;

namespace Mega_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Update();
        }

        private readonly Dictionary<string, Tuple<double, string>> _dictionaryPi = new Dictionary<string, Tuple<double, string>>();
        private readonly Dictionary<string, Tuple<double, string>> _dictionaryE = new Dictionary<string, Tuple<double, string>>();
        private readonly Dictionary<string, List<int>> _dictionaryFibonachi = new Dictionary<string, List<int>>();
        private readonly Dictionary<string, List<int>> _dictionaryPrimeFactor = new Dictionary<string, List<int>>();
        private readonly Dictionary<string, List<int>> _dictionaryPrimeNumber = new Dictionary<string, List<int>>();

        private void findPiTrackBar_Scroll(object sender, EventArgs e)
        {
            findPiValueLabel.Text = @"Value : " + findPiTrackBar.Value;
            if (findPiAutogenerateCheckbox.Checked)
            {
                findPiGenerateButton_Click(sender, e);
            }
        }
        private void findPiGenerateButton_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            var value = findPiTrackBar.Value;
            Tuple<double, string> result = null;
            var key = "Pi" + value;
            string common;
            double countedPi;
            try
            {
                _dictionaryPi.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                countedPi = Numbers.CountingPi(value);
                common = Numbers.CommonPrefix(new[] { countedPi.ToString(CultureInfo.InvariantCulture), Numbers.Pi.ToString(CultureInfo.InvariantCulture) });
                _dictionaryPi.Add(key, new Tuple<double, string>(countedPi, common));
                _dictionaryPi.TryGetValue(key, out result);

            }
            if (result == null) return;
            countedPi = result.Item1;
            common = result.Item2;
            findPiEtalonPiLabel.Text = @"Etalon : Pi =" + Numbers.Pi;
            findPiResultLabel.Text = @"Result : Pi =" + countedPi;
            findPiCommonPartWithEtalonLabel.Text = @"Common :   " + common;
            sw.Stop();
            debugRichTextBox.Text = sw.Elapsed.ToString();
        }
        private void fineEGenerateButton_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            var value = findETrackBar.Value;
            Tuple<double, string> result = null;
            var key = "E" + value;
            string common;
            double countedE;
            try
            {
                _dictionaryE.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                countedE = Numbers.CountingE(value);
                common = Numbers.CommonPrefix(new[] { countedE.ToString(CultureInfo.InvariantCulture), Numbers.E.ToString(CultureInfo.InvariantCulture) });
                _dictionaryE.Add(key, new Tuple<double, string>(countedE, common));
                _dictionaryE.TryGetValue(key, out result);
            }
            if (result == null) return;
            countedE = result.Item1;
            common = result.Item2;
            findEEtalonELabel.Text = @"Etalon : E =" + Numbers.E;
            findEResultLabel.Text = @"Result : E =" + countedE;
            findECommonPartWithEtalonLabel.Text = @"Common :   " + common;
            sw.Stop();
            debugRichTextBox.Text = sw.Elapsed.ToString();
        }
        private void findETrackBar_Scroll(object sender, EventArgs e)
        {
            findEValueLabel.Text = @"Value : " + findETrackBar.Value;
            if (findEAutoenerateCheckBox.Checked)
            {
                fineEGenerateButton_Click(sender, e);
            }
        }
        private void projectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            var currentProjectTabControl = projectTabControl;
            var currentProjectTabPage = currentProjectTabControl.SelectedTab;
            var currentSubprojectTabControl = (TabControl)currentProjectTabPage.Controls[0];
            var currentSubprojectTabPage = currentSubprojectTabControl.SelectedTab;
            Text = $@"Project: {currentProjectTabPage.Text} Subroject: {currentSubprojectTabPage.Text}";
        }
        private void numbersSubprojectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentProjectTabControl = projectTabControl;
            var currentProjectTabPage = currentProjectTabControl.SelectedTab;
            var currentSubprojectTabControl = (TabControl)currentProjectTabPage.Controls[0];
            var currentSubprojectTabPage = currentSubprojectTabControl.SelectedTab;
            Text = $@" Project: {currentProjectTabPage.Text} Subroject: {currentSubprojectTabPage.Text}";
        }
        private void findFibonachiSequenceGenerateButton_Click(object sender, EventArgs e)
        {
            var result = new List<int>();
            var value = findFibonachiSequenceTrackBar.Value;
            var key = "Fibonachi" + value;
            try
            {
                _dictionaryFibonachi.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                _dictionaryFibonachi.Add(key, Numbers.Fibonachi(value));
                _dictionaryFibonachi.TryGetValue(key, out result);
            }
            if (result != null)
                findFibonachiSequenceResultlabel.Text = $@"Result : Fibonachi sequence({value})=" +
                                                        string.Join(";", result);
        }
        private void findFibonachiSequenceTrackBar_Scroll(object sender, EventArgs e)
        {
            findFibonachiSequenceValueLabel.Text = @"Value : " + findFibonachiSequenceTrackBar.Value;
            if (findFibonachiSequenceAutogenerateCheckBox.Checked)
            {
                findFibonachiSequenceGenerateButton_Click(sender, e);
            }
        }
        private void findPrimeFactorGenerateButton_Click(object sender, EventArgs e)
        {
            var result = new List<int>();
            var value = findPrimeFactorTrackBar.Value;
            var key = "PrimeFactor" + value;
            try
            {
                _dictionaryPrimeFactor.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                _dictionaryPrimeFactor.Add(key, Numbers.PrimeFactor(value));
                _dictionaryPrimeFactor.TryGetValue(key, out result);
            }
            if (result != null)
                findPrimeFactorResultLabel.Text = $@"Result : Prime factors for ({value})" + string.Join(";", result);
        }
        private void findPrimeFactorTrackBar_Scroll(object sender, EventArgs e)
        {
            findPrimeFactorValueLabel.Text = @"Value : " + findPrimeFactorTrackBar.Value;
            if (findPrimeFactorAutogenerateCheckBox.Checked)
            {
                findPrimeFactorGenerateButton_Click(sender, e);
            }
        }
        private void findPrimeNumberGenerateButton_Click(object sender, EventArgs e)
        {
            var result = new List<int>();
            var value = findPrimeNumberTrackBar.Value;
            var key = "PrimeNumber" + value;
            try
            {
                _dictionaryPrimeNumber.TryGetValue(key, out result);
            }
            catch (Exception ex)
            {
                debugRichTextBox.Text = ex.Message;
            }
            if (result == null)
            {
                _dictionaryPrimeNumber.Add(key, Numbers.PrimeNumbers(start: 0, count: value));
                _dictionaryPrimeNumber.TryGetValue(key, out result);
            }
            if (result != null)
                findPrimeNumberResultLabel.Text = $@"Result : Prime numbers ({value})" + string.Join(";", result);
        }
        private void findPrimeNumberTrackBar_Scroll(object sender, EventArgs e)
        {
            findPrimeNumberValueLabel.Text = @"Value : " + findPrimeNumberTrackBar.Value;
            if (findPrimeNumberAutogenerateCheckBox.Checked)
            {
                findPrimeNumberGenerateButton_Click(sender, e);
            }
        }

        private ArrayList _array1;
        private Bitmap _bmpsave1;
        private Thread _thread1;
        private static readonly Random Rand = new Random();
        private int _speed;
        private string _alg1;
        private Sorting _srt;
        private ThreadStart _ts;

        private void PrepareArrayRandom()
        {

        }

        private void PrepareArraySorted()
        {
            _array1.Sort();
        }

        private void PrepareArrayNearlySorted()
        {
            _array1.Sort();

            var maxValue = _array1.Count / 10;

            // move anywhere from 2 items to 20% of the items
            var itemsToMove = Rand.Next(1, maxValue);
            for (var i = 0; i < itemsToMove; i++)
            {
                var a = Rand.Next(0, _array1.Count);
                var b = Rand.Next(0, _array1.Count);

                while (a == b)
                {
                    a = Rand.Next(0, _array1.Count);
                    b = Rand.Next(0, _array1.Count);
                }

                var temp = _array1[a];
                _array1[a] = _array1[b];
                _array1[b] = temp;
            }
        }

        private void PrepareArrayReversed()
        {
            _array1.Sort();
            _array1.Reverse();
        }

        private void PrepareArrayFewUnique()
        {
            var maxValue = 10;

            if (_array1.Count < 100)
                maxValue = 6;

            // choose a random amount of unique values
            maxValue = Rand.Next(2, maxValue);

            var temp = new ArrayList();
            for (var i = 0; i < maxValue; i++)
            {
                var y = (int)((double)(i + 1) / maxValue * pnlSort1.Height);
                temp.Add(y);
            }

            for (var i = 0; i < _array1.Count; i++)
            {
                _array1[i] = temp[Rand.Next(0, maxValue)];
            }
        }

        private void PrepareArrayForSorting()
        {
            if (ddTypeOfData.SelectedItem.ToString() == "Random")
            {
                PrepareArrayRandom();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Sorted")
            {
                PrepareArraySorted();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Nearly Sorted")
            {
                PrepareArrayNearlySorted();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Reversed")
            {
                PrepareArrayReversed();
            }
            else if (ddTypeOfData.SelectedItem.ToString() == "Few Unique")
            {
                PrepareArrayFewUnique();
            }
        }

        private void InitializeVisualisationParameters(out int speed,out string alg1,out Sorting srt)
        {
            speed = 1;
            for (var i = 0; i < tbSpeed.Value; i++)
            {
                speed *= 2;
            }
            alg1 = "";
            if (cboAlg1.SelectedItem != null)
                alg1 = cboAlg1.SelectedItem.ToString();
            srt = new Sorting(_array1, pnlSort1, speed);
        }

        private void RerunThread()
        {
            if (_thread1 != null)
            {
                _thread1.Abort();
                _thread1.Join();
            }
        }

        private void RunThread()
        {
            if (_alg1 != "")
            {
                _thread1 = new Thread(_ts);
                _thread1.Start();
            }
        }

        private void SelectSortAlghoritm()
        {
            _ts = delegate
            {
                switch (_alg1)
                {
                    case "BiDirectional Bubble Sort":
                        _srt.BiDirectionalBubbleSort(_array1);
                        break;
                    case "Bubble Sort":
                        _srt.BubbleSort(_array1);
                        break;
                    case "Comb Sort":
                        _srt.CombSort(_array1);
                        break;
                    case "Counting Sort":
                        _srt.CountingSort(_array1);
                        break;
                    case "Cycle Sort":
                        _srt.CycleSort(_array1);
                        break;
                    case "Gnome Sort":
                        _srt.GnomeSort(_array1);
                        break;
                    case "Heap Sort":
                        _srt.HeapSort(_array1);
                        break;
                    case "Insertion Sort":
                        _srt.InsertionSort(_array1);
                        break;
                    case "Merge Sort (In Place)":
                        _srt.MergeSortInPlace(_array1, 0, _array1.Count - 1);
                        break;
                    case "Merge Sort (Double Storage)":
                        _srt.MergeSortDoubleStorage(_array1, 0, _array1.Count - 1);
                        break;
                    case "Odd-Even Sort":
                        _srt.OddEvenSort(_array1);
                        break;
                    case "Pigeonhole Sort":
                        _srt.PigeonholeSort(_array1);
                        break;
                    case "Quicksort":
                        _srt.Quicksort(_array1, 0, _array1.Count - 1);
                        break;
                    case "Quicksort with Insertion Sort":
                        _srt.QuicksortWithInsertionSort(_array1, 0, _array1.Count - 1);
                        break;
                    case "Radix Sort":
                        _srt.RadixSort(_array1);
                        break;
                    case "Selection Sort":
                        _srt.SelectionSort(_array1);
                        break;
                    case "Shell Sort":
                        _srt.ShellSort(_array1);
                        break;
                    case "Smoothsort":
                        _srt.Smoothsort(_array1);
                        break;
                    case "Timsort":
                        _srt.Timsort(_array1, 0, _array1.Count);
                        break;
                    default:
                        _srt.Quicksort(_array1, 0, _array1.Count - 1);
                        break;
                }
                _srt.Draw.FinishDrawing();
                SetText("compare:" + _srt.OperationsCompare + " swap:" + _srt.OperationsSwap);
            };
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            RerunThread();
            PrepareForSort();
            PrepareArrayForSorting();
            InitializeVisualisationParameters(out _speed,out _alg1,out _srt);
            SelectSortAlghoritm();
            RunThread();
        }

        private void Randomize(IList list)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                var swapIndex = Rand.Next(i + 1);
                if (swapIndex != i)
                {
                    var tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private bool IsSorted(IList checkThis)
        {
            for (var i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }

        private void PrepareForSort()
        {
            _bmpsave1 = new Bitmap(pnlSort1.Width, pnlSort1.Height);
            Graphics.FromImage(_bmpsave1);

            pnlSort1.Image = _bmpsave1;

            _array1 = new ArrayList(tbSamples.Value);
            for (var i = 0; i < _array1.Capacity; i++)
            {
                var y = (int)((double)(i + 1) / _array1.Capacity * pnlSort1.Height);
                _array1.Add(y);
            }
            Randomize(_array1);

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

        private delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (debugRichTextBox.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, text);
            }
            else
            {
                debugRichTextBox.Text = text;
            }
        }

        private void resize_controls()
        {
            projectTabControl.Width = Width - 40;
            projectTabControl.Height = Height - 199;

            numbersSubprojectTabControl.Width = Width - 60;
            numbersSubprojectTabControl.Height = Height - 237;

            visualisingSubProjectTabControl.Width = Width - 60;
            visualisingSubProjectTabControl.Height = Height - 237;

            benchmarkSubprojectTabControl.Width = Width - 60;
            benchmarkSubprojectTabControl.Height = Height - 237;

            debugLabel.Left = 16;
            debugLabel.Top = Height - 180;

            debugRichTextBox.Left = 16;
            debugRichTextBox.Top = Height - 161;

            pnlSort1.Height = Height - 276;
            pnlSort1.Width = Width - 470;
        }

        private void cmdSuspend_Click(object sender, EventArgs e)
        {
#pragma warning disable 618
            if (_thread1?.ThreadState == ThreadState.WaitSleepJoin)
            {
                debugRichTextBox.Text = _thread1.ThreadState.ToString();
                _thread1?.Suspend();
            }

#pragma warning restore 618
        }

        private void cmdResume_Click(object sender, EventArgs e)
        {
#pragma warning disable 618
            if (_thread1?.ThreadState == ThreadState.Suspended)
            {
                _thread1?.Resume();
            }
#pragma warning restore 618
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void findCostOfTileToCoverWxHFloorCalculateButton_Click(object sender, EventArgs e)
        {
            var cost = findCostOfTileToCoverWxHFloorCostTrackBar.Value;
            var width = findCostOfTileToCoverWxHFloorWidthTrackBar.Value;
            var height = findCostOfTileToCoverWxHFloorHeightTrackBar.Value;
            findCostOfTileToCoverWxHFloorResultLabel.Text = @"Total cost : " + (cost * width * height);
        }

        private void findCostOfTileToCoverWxHFloorCostTrackBar_Scroll(object sender, EventArgs e)
        {
            findCostOfTileToCoverWxHFloorCostValueLabel.Text = findCostOfTileToCoverWxHFloorCostTrackBar.Value.ToString();
            if (findCostOfTileToCoverWxHFloorAutocalculateCheckBox.Checked)
            {
                findCostOfTileToCoverWxHFloorCalculateButton_Click(sender, e);
            }
        }

        private void findCostOfTileToCoverWxHFloorWidthTrackBar_Scroll(object sender, EventArgs e)
        {
            findCostOfTileToCoverWxHFloorWidthValueLabel.Text = findCostOfTileToCoverWxHFloorWidthTrackBar.Value.ToString();
            if (findCostOfTileToCoverWxHFloorAutocalculateCheckBox.Checked)
            {
                findCostOfTileToCoverWxHFloorCalculateButton_Click(sender, e);
            }
        }

        private void findCostOfTileToCoverWxHFloorHeightTrackBar_Scroll(object sender, EventArgs e)
        {
            findCostOfTileToCoverWxHFloorHeightValueLabel.Text = findCostOfTileToCoverWxHFloorHeightTrackBar.Value.ToString();
            if (findCostOfTileToCoverWxHFloorAutocalculateCheckBox.Checked)
            {
                findCostOfTileToCoverWxHFloorCalculateButton_Click(sender, e);
            }
        }

        private void benchmarkMD5_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate
            {
                SetProgressbarStyle(ProgressBarStyle.Marquee);
                var summ = BenchmarkRunner.Run<BenchmarkMd5>();
                string[] selectedColumns = { "Method", "Mean", "StdDev", "Allocated" };
                var indexes = new List<int>();
                foreach (var str in summ.Table.Columns)
                {
                    foreach (var str2 in selectedColumns)
                    {
                        if (str.Header != str2) continue;
                        indexes.Add(str.Index);
                        SetDataGridColumns(str.Header, str.Header);
                    }
                }
                AddDataGridRow(indexes.Select(index => summ.Table.FullContent[0][index]).ToArray());
                SetProgressbarStyle(ProgressBarStyle.Continuous);
                SetProgressbarValue(100);
            };
            var thread1 = new Thread(ts);
            thread1.Start();
        }


        delegate void SetProgCallback(int newVal);
        private void SetProgressbarValue(int newVal)
        {
            if (benchmarkMD5ProgressBar.InvokeRequired)
            {
                SetProgCallback d = SetProgressbarValue;
                Invoke(d, newVal);
            }
            else
            {
                benchmarkMD5ProgressBar.Value = newVal;
            }
        }

        delegate void SetProgStyleCallback(ProgressBarStyle newVal);
        private void SetProgressbarStyle(ProgressBarStyle newVal)
        {
            if (benchmarkMD5ProgressBar.InvokeRequired)
            {
                SetProgStyleCallback d = SetProgressbarStyle;
                Invoke(d, newVal);
            }
            else
            {
                benchmarkMD5ProgressBar.Style = newVal;
            }
        }

        private void SetProgressbar2Value(int newVal)
        {
            if (benchmarkSha256ProgressBar.InvokeRequired)
            {
                SetProgCallback d = SetProgressbar2Value;
                Invoke(d, newVal);
            }
            else
            {
                benchmarkSha256ProgressBar.Value = newVal;
            }
        }

        private void SetProgressbar2Style(ProgressBarStyle newVal)
        {
            if (benchmarkSha256ProgressBar.InvokeRequired)
            {
                SetProgStyleCallback d = SetProgressbar2Style;
                Invoke(d, newVal);
            }
            else
            {
                benchmarkSha256ProgressBar.Style = newVal;
            }
        }

        delegate void SetDgcCallback(string columnName, string headerText);
        private void SetDataGridColumns(string columnName, string headerText)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                SetDgcCallback d = SetDataGridColumns;
                Invoke(d, columnName, headerText);
            }
            else
            {
                benchmarkMD5DataGridView.Columns.Add(columnName, headerText);
            }
        }

        private delegate void AddDgrCallback(string[] row);
        private void AddDataGridRow(string[] row)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                AddDgrCallback d = AddDataGridRow;
                Invoke(d, new object[] { row });
            }
            else
            {
                // ReSharper disable once CoVariantArrayConversion
                benchmarkMD5DataGridView.Rows.Add(row);
            }
        }

        private void SetDataGrid2Columns(string columnName, string headerText)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                SetDgcCallback d = SetDataGrid2Columns;
                Invoke(d, columnName, headerText);
            }
            else
            {
                benchmarkSha256DataGridView.Columns.Add(columnName, headerText);
            }
        }

        private void AddDataGrid2Row(string[] row)
        {
            if (benchmarkSha256DataGridView.InvokeRequired)
            {
                AddDgrCallback d = AddDataGrid2Row;
                Invoke(d, new object[] { row });
            }
            else
            {
                // ReSharper disable once CoVariantArrayConversion
                benchmarkSha256DataGridView.Rows.Add(row);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate
            {
                SetProgressbar2Style(ProgressBarStyle.Marquee);
                var summ = BenchmarkRunner.Run<BenchmarkSha256>();
                string[] selectedColumns = { "Method", "Mean", "StdDev", "Allocated" };
                var report = new List<string>();
                var indexes = new List<int>();
                foreach (var str in summ.Table.Columns)
                {
                    foreach (var str2 in selectedColumns)
                    {
                        if (str.Header == str2)
                        {
                            indexes.Add(str.Index);
                            SetDataGrid2Columns(str.Header, str.Header);
                        }
                    }
                }
                foreach (var index in indexes)
                {
                    report.Add(summ.Table.FullContent[0][index]);
                }
                AddDataGrid2Row(report.ToArray());
                SetProgressbar2Style(ProgressBarStyle.Continuous);
                SetProgressbar2Value(100);
            };
            var thread1 = new Thread(ts);
            thread1.Start();
        }

        private void cmdAbort_Click(object sender, EventArgs e)
        {
            if (_thread1?.ThreadState == ThreadState.Suspended)
            {
                _thread1.Resume();
                _thread1.Abort();
            }
            else
            {
                _thread1?.Abort();
            }
        }
    }
}
