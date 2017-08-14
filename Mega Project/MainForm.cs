using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Mega_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private void benchmarkMD5_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate ()
            {
                SetProgressbarStyle(ProgressBarStyle.Marquee);
                var summ = BenchmarkRunner.Run<BenchmarkMD5>();
                string columns = "";
                string[] selectedColumns = { "Method", "Mean", "StdDev", "Allocated" };
                List<string> report = new List<string>();
                List<int> indexes = new List<int>();
                foreach (BenchmarkDotNet.Reports.SummaryTable.SummaryTableColumn str in summ.Table.Columns)
                {
                    foreach (string str2 in selectedColumns)
                    {
                        if (str.Header == str2)
                        {
                            indexes.Add(str.Index);
                            columns += str.Header + " ";
                            SetDataGridColumns(str.Header, str.Header);
                        }
                    }
                }
                foreach (int index in indexes)
                {
                    report.Add(summ.Table.FullContent[0][index]);
                }
                AddDataGridRow(report.ToArray());
                SetProgressbarStyle(ProgressBarStyle.Continuous);
                SetProgressbarValue(100);
            };
            Thread thread1 = new Thread(ts);
            thread1.Start();
        }


        delegate void SetProgCallback(int newVal);
        private void SetProgressbarValue(int newVal)
        {
            if (benchmarkMD5ProgressBar.InvokeRequired)
            {
                SetProgCallback d = SetProgressbarValue;
                Invoke(d, new object[] { newVal });
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
                Invoke(d, new object[] { newVal });
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
                Invoke(d, new object[] { newVal });
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
                Invoke(d, new object[] { newVal });
            }
            else
            {
                benchmarkSha256ProgressBar.Style = newVal;
            }
        }

        delegate void SetDGCCallback(string columnName, string headerText);
        private void SetDataGridColumns(string columnName, string headerText)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                SetDGCCallback d = SetDataGridColumns;
                Invoke(d, new object[] { columnName, headerText });
            }
            else
            {
                benchmarkMD5DataGridView.Columns.Add(columnName, headerText);
            }
        }

        delegate void AddDGRCallback(string[] Row);
        private void AddDataGridRow(string[] Row)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                AddDGRCallback d = AddDataGridRow;
                Invoke(d, new object[] { Row });
            }
            else
            {
                benchmarkMD5DataGridView.Rows.Add(Row);
            }
        }

        private void SetDataGrid2Columns(string columnName, string headerText)
        {
            if (benchmarkMD5DataGridView.InvokeRequired)
            {
                SetDGCCallback d = SetDataGrid2Columns;
                Invoke(d, new object[] { columnName, headerText });
            }
            else
            {
                benchmarkSha256DataGridView.Columns.Add(columnName, headerText);
            }
        }

        private void AddDataGrid2Row(string[] Row)
        {
            if (benchmarkSha256DataGridView.InvokeRequired)
            {
                AddDGRCallback d = AddDataGrid2Row;
                Invoke(d, new object[] { Row });
            }
            else
            {
                benchmarkSha256DataGridView.Rows.Add(Row);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = delegate ()
            {
                SetProgressbar2Style(ProgressBarStyle.Marquee);
                var summ = BenchmarkRunner.Run<BenchmarkSha256>();
                string columns = "";
                string[] selectedColumns = { "Method", "Mean", "StdDev", "Allocated" };
                List<string> report = new List<string>();
                List<int> indexes = new List<int>();
                foreach (BenchmarkDotNet.Reports.SummaryTable.SummaryTableColumn str in summ.Table.Columns)
                {
                    foreach (string str2 in selectedColumns)
                    {
                        if (str.Header == str2)
                        {
                            indexes.Add(str.Index);
                            columns += str.Header + " ";
                            SetDataGrid2Columns(str.Header, str.Header);
                        }
                    }
                }
                foreach (int index in indexes)
                {
                    report.Add(summ.Table.FullContent[0][index]);
                }
                AddDataGrid2Row(report.ToArray());
                SetProgressbar2Style(ProgressBarStyle.Continuous);
                SetProgressbar2Value(100);
            };
            Thread thread1 = new Thread(ts);
            thread1.Start();
        }


    }
}
