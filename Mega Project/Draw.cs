using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Project
{
    public class Draw
    {
        public int operationsPerFrame; // operations per frame
        public int frameMS; // time between frames (aim for 40 ms = 25 fps)
        public int operationCount;
        DateTime nextFrameTime;
        Graphics g;
        Bitmap bmpsave;


        public void DrawSamples(PictureBox pnlSamples, ArrayList arrayToSort, Dictionary<int, bool> highlightedIndexes, Bitmap bitmap)
        {
            bmpsave = bitmap;
            g = Graphics.FromImage(bmpsave);
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // start with white background
            g.Clear(Color.White);

            // use black sometimes
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // use red sometimes
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            int w = (pnlSamples.Width / arrayToSort.Count) - 1;
            
            for (int i = 0; i < arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (highlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
            }
            pnlSamples.Image = bmpsave;
            
        }

        public void checkForFrame(PictureBox pnlSamples, ArrayList arrayToSort, Dictionary<int, bool> highlightedIndexes, Bitmap bitmap)
        {
            if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
            {
                // time to draw a new frame and wait
                DrawSamples(pnlSamples,arrayToSort,highlightedIndexes,bitmap);
                RefreshPanel(pnlSamples);

                // prepare for next frame
                highlightedIndexes.Clear();
                operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

                if (DateTime.UtcNow < nextFrameTime)
                {
                    Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
                }
                nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
            }
        }

        delegate void SetControlValueCallback(Control pnlSort);

        public void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                pnlSort.Invoke(d, new object[] { pnlSort });
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void SwapItems(ArrayList arrayToSort, int index1, int index2, Dictionary<int, bool> highlightedIndexes,PictureBox pnl, Bitmap bitmap)
        {
            object temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount += 2;
            checkForFrame(pnl,arrayToSort,highlightedIndexes,bitmap);
        }

        public int CompareItems(ArrayList arrayToSort, int index1, int index2, Dictionary<int, bool> highlightedIndexes, PictureBox pnl, Bitmap bitmap)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount++;
            checkForFrame(pnl, arrayToSort, highlightedIndexes, bitmap);

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }

        public void finishDrawing(PictureBox pnlSamples, ArrayList arrayToSort, Dictionary<int, bool> highlightedIndexes,Bitmap bitmap)
        {
            if (highlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                nextFrameTime = DateTime.UtcNow;
                checkForFrame(pnlSamples, arrayToSort, highlightedIndexes, bitmap);
            }

            // draw the last frame
            nextFrameTime = DateTime.UtcNow;
            checkForFrame( pnlSamples,  arrayToSort, highlightedIndexes, bitmap);
        }
    }
}
