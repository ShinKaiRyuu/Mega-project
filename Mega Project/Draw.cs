using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Mega_Project
{
    public class Draw
    {
        private readonly ArrayList _arrayToSort;
        private Graphics _g;
        public int OperationCount;
        private readonly int _operationsPerFrame;
        private DateTime _nextFrameTime;
        public readonly Dictionary<int, bool> HighlightedIndexes = new Dictionary<int, bool>();
        private Bitmap _bmpsave;
        private readonly PictureBox _pnlSamples;
        private readonly int _originalPanelHeight;
        private readonly int _frameMs;

        public Draw(ArrayList list, PictureBox pic,  int s)
        {
            _arrayToSort = list;
            _pnlSamples = pic;

            OperationCount = 0;
            _operationsPerFrame = s;
            _frameMs = 1000; // so now operationsPerFrame is operations per second

            // reduce the frame wait for better visuals (increased frame rate)
            while (_frameMs >= 40 && _operationsPerFrame > 1)
            {
                _operationsPerFrame = _operationsPerFrame / 2;
                _frameMs = _frameMs / 2;
            }

            _bmpsave = new Bitmap(_pnlSamples.Width, _pnlSamples.Height);
            _g = Graphics.FromImage(_bmpsave);
            _originalPanelHeight = _pnlSamples.Height;
            _pnlSamples.Image = _bmpsave;
            _nextFrameTime = DateTime.UtcNow;

            CheckForFrame();
        }
        public void CheckForFrame()
        {
            if (OperationCount < _operationsPerFrame && _nextFrameTime > DateTime.UtcNow) return;
            // time to draw a new frame and wait
            DrawSamples();
            RefreshPanel(_pnlSamples);
                
            // prepare for next frame
            HighlightedIndexes.Clear();
            OperationCount -= _operationsPerFrame; // if there were more operations than needed, don't just forget those

            if (DateTime.UtcNow < _nextFrameTime)
            {
                Thread.Sleep((int)((_nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
            }
            _nextFrameTime = _nextFrameTime.AddMilliseconds(_frameMs);
        }

        private delegate void SetControlValueCallback(Control pnlSort);

        private static void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                var d = new SetControlValueCallback(RefreshPanel);
                pnlSort.Invoke(d, pnlSort);
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        private void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size

            if (_bmpsave.Width != _pnlSamples.Width || _bmpsave.Height != _pnlSamples.Height)
            {
                _bmpsave = new Bitmap(_pnlSamples.Width, _pnlSamples.Height);
                _g = Graphics.FromImage(_bmpsave);
                _pnlSamples.Image = _bmpsave;
            }

            if (_pnlSamples.Height != _originalPanelHeight)
            {
                multiplyHeight = _pnlSamples.Height / (double)(_originalPanelHeight);
            }

            // start with white background
            _g.Clear(Color.White);

            // use black sometimes
            var pen = new Pen(Color.Black);
            var b = new SolidBrush(Color.Black);

            // use red sometimes
            var redPen = new Pen(Color.Red);
            var redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            var w = (_pnlSamples.Width / _arrayToSort.Count) - 1;
            var a = new List<int>();
            
            for (var i = 0; i < _arrayToSort.Count; i++)
            {
                var x = (int)(((double)_pnlSamples.Width / _arrayToSort.Count) * i);

                var itemHeight = (int)Math.Round(Convert.ToDouble(_arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (HighlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        _g.DrawLine(redPen, new Point(x, _pnlSamples.Height), new Point(x, _pnlSamples.Height - itemHeight));
                        a.Add((int)_arrayToSort[i]);
                    }

                    else
                    {
                        _g.FillRectangle(redBrush, x, _pnlSamples.Height - itemHeight, w, _pnlSamples.Height);
                        a.Add((int)_arrayToSort[i]);
                    }
                }
                
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        _g.DrawLine(pen, new Point(x, _pnlSamples.Height), new Point(x, _pnlSamples.Height - itemHeight));
                    }
                    else
                    {
                        _g.FillRectangle(b, x, _pnlSamples.Height - itemHeight, w, _pnlSamples.Height);
                    }
                }
                
            }
            if (a.Count>1)
            {
                string text;
                if (a[0] > a[1])
                {
                    text = "SWAPING "+a[0]+" / "+a[1];
                    _g.DrawString(text, new Font("Arial", 10), redBrush, new Point(0, 5));
                }
                else
                {
                    text = "NO SWAPING";
                    _g.DrawString(text, new Font("Arial", 10), redBrush, new Point(0, 5));
                }
            }
           
            
        }
        public void FinishDrawing()
        {
            if (HighlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                _nextFrameTime = DateTime.UtcNow;
                CheckForFrame();
            }

            // draw the last frame
            _nextFrameTime = DateTime.UtcNow;
            CheckForFrame();
        }
    }
}
