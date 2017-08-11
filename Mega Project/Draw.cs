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
        ArrayList arrayToSort;
        Graphics g;
        public int operationCount;
        public int operationsPerFrame;
        DateTime nextFrameTime;
        public Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>();
        Bitmap bmpsave;
        PictureBox pnlSamples;
        int originalPanelHeight;
        int imgCount;
        int frameMS;

        public Draw(ArrayList list, PictureBox pic,  int s)
        {
            imgCount = 0;
            arrayToSort = list;
            pnlSamples = pic;

            operationCount = 0;
            operationsPerFrame = s;
            frameMS = 1000; // so now operationsPerFrame is operations per second

            // reduce the frame wait for better visuals (increased frame rate)
            while (frameMS >= 40 && operationsPerFrame > 1)
            {
                operationsPerFrame = operationsPerFrame / 2;
                frameMS = frameMS / 2;
            }

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;
            nextFrameTime = DateTime.UtcNow;

            checkForFrame();
        }
        public void checkForFrame()
        {
            if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
            {
                // time to draw a new frame and wait
                DrawSamples();
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

        private void RefreshPanel(Control pnlSort)
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

        public void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size

            if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
            {
                bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                g = Graphics.FromImage(bmpsave);
                pnlSamples.Image = bmpsave;
            }

            if (pnlSamples.Height != originalPanelHeight)
            {
                multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
            }

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

            for (int i = 0; i < this.arrayToSort.Count; i++)
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
        }
        public void finishDrawing()
        {
            if (highlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                nextFrameTime = DateTime.UtcNow;
                checkForFrame();
            }

            // draw the last frame
            nextFrameTime = DateTime.UtcNow;
            checkForFrame();
        }
    }
}
