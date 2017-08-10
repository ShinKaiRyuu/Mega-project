using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Project
{
    public class Visualise
    {
        ArrayList arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        public bool savePicture;
        string outputFolder;
        string outputFile;
        int imgCount;

        int operationsPerFrame; // operations per frame
        int frameMS; // time between frames (aim for 40 ms = 25 fps)
        int operationCount;
        Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>(); // highlight all of these indexes in the frame
        DateTime nextFrameTime;
        int originalPanelHeight;
        public Draw draw = new Draw();
        Random rand = new Random();

        public Visualise(ArrayList list, PictureBox pic, bool sp, string of, int s, string outFile, Dictionary<int, bool> highlightedIndexes2,Bitmap bitmap)
        {
            imgCount = 0;
            arrayToSort = list;
            pnlSamples = pic;
            savePicture = sp;
            outputFolder = of;
            outputFile = outFile;
            highlightedIndexes = highlightedIndexes2;
            draw.operationCount = 0;
            draw.operationsPerFrame = s;
            draw.frameMS = 1000; // so now operationsPerFrame is operations per second

            // reduce the frame wait for better visuals (increased frame rate)
            while (draw.frameMS >= 40 && draw.operationsPerFrame > 1)
            {
                draw.operationsPerFrame = draw.operationsPerFrame / 2;
                draw.frameMS = frameMS / 2;
            }

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;
            nextFrameTime = DateTime.UtcNow;

            draw.checkForFrame(pnlSamples,arrayToSort,highlightedIndexes,bitmap);
        }

        //private void checkForFrame()
        //{
        //    if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
        //    {
        //        // time to draw a new frame and wait
        //        draw.DrawSamples(pnlSamples, arrayToSort, highlightedIndexes);
        //        RefreshPanel(pnlSamples);
        //        if (savePicture)
        //            SavePicture();

        //        // prepare for next frame
        //        highlightedIndexes.Clear();
        //        operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

        //        if (DateTime.UtcNow < nextFrameTime)
        //        {
        //            Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
        //        }
        //        nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
        //    }
        //}

        //private ImageCodecInfo getEncoderInfo(string mimeType)
        //{
        //    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
        //    for (int i = 0; i < codecs.Length; i++)
        //        if (codecs[i].MimeType == mimeType)
        //            return codecs[i];
        //    return null;
        //}

        //public void finishDrawing()
        //{
        //    if (highlightedIndexes.Count > 0)
        //    {
        //        // put one last frame in before the end
        //        nextFrameTime = DateTime.UtcNow;
        //        checkForFrame();
        //    }

        //    // draw the last frame
        //    nextFrameTime = DateTime.UtcNow;
        //    checkForFrame();
        //}

        //private void SavePicture()
        //{
        //    ImageCodecInfo myImageCodecInfo = this.getEncoderInfo("image/gif");
        //    EncoderParameter myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
        //    EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 0L);
        //    EncoderParameters myEncoderParameters = new EncoderParameters(1);

        //    EncoderParameters encoderParams = new EncoderParameters(2);
        //    encoderParams.Param[0] = qualityParam;
        //    encoderParams.Param[1] = myEncoderParameter;

        //    if (!System.IO.Directory.Exists(outputFolder))
        //    {
        //        System.IO.Directory.CreateDirectory(outputFolder);
        //    }

        //    string destPath = System.IO.Path.Combine(outputFolder, outputFile + imgCount + ".gif");
        //    //bmpsave.Save(destPath, myImageCodecInfo, encoderParams);
        //    bmpsave.Save(destPath, ImageFormat.Gif);
        //    imgCount++;
        //}

        //delegate void SetControlValueCallback(Control pnlSort);

        //private void RefreshPanel(Control pnlSort)
        //{
        //    if (pnlSort.InvokeRequired)
        //    {
        //        SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
        //        pnlSort.Invoke(d, new object[] { pnlSort });
        //    }
        //    else
        //    {
        //        pnlSort.Refresh();
        //    }
        //}

        //public void DrawSamples()
        //{
        //    // might need to grow or shrink if size is different from original (can't change array!)
        //    double multiplyHeight = 1;

        //    // check if need to change size
        //    if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
        //    {
        //        bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
        //        g = Graphics.FromImage(bmpsave);
        //        pnlSamples.Image = bmpsave;
        //    }

        //    if (pnlSamples.Height != originalPanelHeight)
        //    {
        //        multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
        //    }

        //    // start with white background
        //    g.Clear(Color.White);

        //    // use black sometimes
        //    Pen pen = new Pen(Color.Black);
        //    SolidBrush b = new SolidBrush(Color.Black);

        //    // use red sometimes
        //    Pen redPen = new Pen(Color.Red);
        //    SolidBrush redBrush = new SolidBrush(Color.Red);

        //    // draw a nice width based on number of elements
        //    int w = (pnlSamples.Width / arrayToSort.Count) - 1;

        //    for (int i = 0; i < this.arrayToSort.Count; i++)
        //    {
        //        int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

        //        int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

        //        // draw highlighed versions
        //        if (highlightedIndexes.ContainsKey(i))
        //        {
        //            if (w <= 1)
        //            {
        //                g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
        //            }
        //            else
        //            {
        //                g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
        //            }
        //        }
        //        else // draw normal versions
        //        {
        //            if (w <= 1)
        //            {
        //                g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
        //            }
        //            else
        //            {
        //                g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
        //            }
        //        }
        //    }

        //}

        //// simple to program, but really terrible in performance
        //public IList BubbleSort(IList arrayToSort)
        //{
        //    bool swapMade = true;
        //    int n = arrayToSort.Count - 1;
        //    for (int i = 0; i < n && swapMade; i++)
        //    {
        //        swapMade = false;

        //        for (int j = n; j > i; j--)
        //        {
        //            if (CompareItems(arrayToSort, j - 1, j) > 0)
        //            {
        //                SwapItems(arrayToSort, j - 1, j);
        //                swapMade = true;
        //            }
        //        }
        //    }

        //    return arrayToSort;
        //}

        //private void SwapItems(IList arrayToSort, int index1, int index2)
        //{
        //    object temp = arrayToSort[index1];
        //    arrayToSort[index1] = arrayToSort[index2];
        //    arrayToSort[index2] = temp;

        //    if (!highlightedIndexes.ContainsKey(index1))
        //        highlightedIndexes.Add(index1, false);
        //    if (!highlightedIndexes.ContainsKey(index2))
        //        highlightedIndexes.Add(index2, false);

        //    operationCount += 2;
        //    checkForFrame();
        //}

        //private int CompareItems(IList arrayToSort, int index1, int index2)
        //{
        //    if (!highlightedIndexes.ContainsKey(index1))
        //        highlightedIndexes.Add(index1, false);
        //    if (!highlightedIndexes.ContainsKey(index2))
        //        highlightedIndexes.Add(index2, false);

        //    operationCount++;
        //    checkForFrame();

        //    return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        //}
    }
}
