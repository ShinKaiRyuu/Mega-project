using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Project
{
    public partial class VisualiseForm : Form
    {
        Graphics g1;
        Graphics g2;
        ArrayList array1;
        ArrayList array2;
        Bitmap bmpsave1;
        Bitmap bmpsave2;

        int middleSpacer;
        int leftSpacer;
        int rightSpacer;
        int bottomSpacer;
        int topSpacer;

        static Random rand = new Random();

        Thread thread1;
        Thread thread2;

        public VisualiseForm()
        {
            InitializeComponent();
        }

        private void VisualiseForm_Load(object sender, EventArgs e)
        {
            cboAlg1.SelectedIndex = cboAlg1.Items.IndexOf("Quicksort");
            cboAlg2.SelectedIndex = cboAlg2.Items.IndexOf("Shell Sort");
            tbSamples.Value = 100;
            middleSpacer = pnlSort2.Left - (pnlSort1.Left + pnlSort1.Width);
            leftSpacer = pnlSort1.Left;
            rightSpacer = this.Width - (pnlSort2.Left + pnlSort2.Width);
            bottomSpacer = this.Height - (pnlSort1.Top + pnlSort1.Height);
            topSpacer = pnlSort1.Top;
            ddTypeOfData.SelectedIndex = ddTypeOfData.Items.IndexOf("Random");
        }

        private void PrepareForSort()
        {
            resizeGraphics();

            bmpsave1 = new Bitmap(pnlSort1.Width, pnlSort1.Height);
            g1 = Graphics.FromImage(bmpsave1);

            bmpsave2 = new Bitmap(pnlSort2.Width, pnlSort2.Height);
            g2 = Graphics.FromImage(bmpsave2);

            pnlSort1.Image = bmpsave1;
            pnlSort2.Image = bmpsave2;

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

        //private void cmdSort_Click(object sender, EventArgs e)
        //{
        //    if (thread1 != null)
        //    {
        //        thread1.Abort();
        //        thread1.Join();
        //    }
        //    if (thread2 != null)
        //    {
        //        thread2.Abort();
        //        thread2.Join();
        //    }

        //    PrepareForSort();

        //    if (ddTypeOfData.SelectedItem.ToString() == "Random")
        //    {
        //        // ready to go
        //    }
        //    else if (ddTypeOfData.SelectedItem.ToString() == "Sorted")
        //    {
        //        array1.Sort();
        //        array2 = (ArrayList)array1.Clone();
        //    }
        //    else if (ddTypeOfData.SelectedItem.ToString() == "Nearly Sorted")
        //    {
        //        array1.Sort();

        //        int maxValue = array1.Count / 10;

        //        // move anywhere from 2 items to 20% of the items
        //        int itemsToMove = rand.Next(1, maxValue);
        //        for (int i = 0; i < itemsToMove; i++)
        //        {
        //            int a = rand.Next(0, array1.Count);
        //            int b = rand.Next(0, array1.Count);

        //            while (a == b)
        //            {
        //                a = rand.Next(0, array1.Count);
        //                b = rand.Next(0, array1.Count);
        //            }

        //            object temp = array1[a];
        //            array1[a] = array1[b];
        //            array1[b] = temp;
        //        }

        //        array2 = (ArrayList)array1.Clone();
        //    }
        //    else if (ddTypeOfData.SelectedItem.ToString() == "Reversed")
        //    {
        //        array1.Sort();
        //        array1.Reverse();

        //        array2 = (ArrayList)array1.Clone();
        //    }
        //    else if (ddTypeOfData.SelectedItem.ToString() == "Few Unique")
        //    {
        //        int maxValue = 10;

        //        if (array1.Count < 100)
        //            maxValue = 6;

        //        // choose a random amount of unique values
        //        maxValue = rand.Next(2, maxValue);

        //        ArrayList temp = new ArrayList();
        //        for (int i = 0; i < maxValue; i++)
        //        {
        //            int y = (int)((double)(i + 1) / maxValue * pnlSort1.Height);
        //            temp.Add(y);
        //        }

        //        for (int i = 0; i < array1.Count; i++)
        //        {
        //            array1[i] = temp[rand.Next(0, maxValue)];
        //        }

        //        array2 = (ArrayList)array1.Clone();
        //    }

        //    resizeGraphics();

        //    int speed = 1;
        //    for (int i = 0; i < tbSpeed.Value; i++)
        //    {
        //        speed *= 2;
        //    }

        //    string alg1 = "";
        //    string alg2 = "";

        //    if (cboAlg1.SelectedItem != null)
        //        alg1 = cboAlg1.SelectedItem.ToString();

        //    if (cboAlg2.SelectedItem != null)
        //        alg2 = cboAlg2.SelectedItem.ToString();

        //    Visualise sa = new Visualise(array1, pnlSort1, chkAnimation.Checked, txtOutputFolder.Text, speed, alg1);
        //    Visualise sa2 = new Visualise(array2, pnlSort2, chkAnimation.Checked, txtOutputFolder.Text, speed, alg2);

        //    ThreadStart ts = delegate ()
        //    {
        //        switch (alg1)
        //        {
                    
        //            case "Bubble Sort":
        //                sa.BubbleSort(array1);
        //                break;
                    
        //        }

        //        sa.finishDrawing();

        //        //if (sa.savePicture)
        //        //    sa.CreateAnimation();

        //        if (!isSorted(array1))
        //            MessageBox.Show("#1 Sort Failed!");
        //    };

        //    ThreadStart ts2 = delegate ()
        //    {
        //        switch (alg2)
        //        {

        //            case "Bubble Sort":
        //                sa2.BubbleSort(array2);
        //                break;
                   
        //        }

        //        sa2.finishDrawing();

        //        //if (sa2.savePicture)
        //        //    sa2.CreateAnimation();

        //        if (!isSorted(array2))
        //            MessageBox.Show("#2 Sort Failed!");
        //    };

        //    if (alg1 != "")
        //    {
        //        thread1 = new Thread(ts);
        //        thread1.Start();
        //    }
        //    if (alg2 != "")
        //    {
        //        thread2 = new Thread(ts2);
        //        thread2.Start();
        //    }
        //}

        private bool isSorted(IList checkThis)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }

        public void resizeGraphics()
        {
            // change the graphics to the right sizes

            pnlSort1.Height = this.Height - topSpacer - bottomSpacer;
            pnlSort2.Height = pnlSort1.Height;

            if (cboAlg2.SelectedItem == null || cboAlg2.SelectedItem.ToString().Trim() == "")
            {
                pnlSort2.Left = this.Width + 1;
                pnlSort1.Width = (this.Width - leftSpacer - rightSpacer);
                pnlSort2.Width = pnlSort1.Width;
            }
            else if (cboAlg1.SelectedItem == null || cboAlg1.SelectedItem.ToString().Trim() == "")
            {
                pnlSort1.Left = this.Width + 1;
                pnlSort1.Width = (this.Width - leftSpacer - rightSpacer);
                pnlSort2.Width = pnlSort1.Width;
                pnlSort2.Left = leftSpacer;
            }
            else
            {
                pnlSort1.Width = (this.Width - leftSpacer - rightSpacer - middleSpacer) / 2;
                pnlSort2.Width = pnlSort1.Width;

                pnlSort1.Left = leftSpacer;
                pnlSort2.Left = pnlSort1.Left + pnlSort1.Width + middleSpacer;
            }
        }

        private void tbSamples_Scroll(object sender, EventArgs e)
        {
            lblSamples.Text = "Number of samples: " + tbSamples.Value.ToString("n0");
        }

        private void VisualiseForm_Resize(object sender, EventArgs e)
        {
            resizeGraphics();
        }
    }
}

