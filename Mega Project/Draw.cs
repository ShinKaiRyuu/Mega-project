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
        private double _multiplyHeight;
        private Pen _blackPen;
        private SolidBrush _blackBrush;
        private Pen _redPen;
        private SolidBrush _redBrush;
        private int _width;
        private List<int> _swaps;

        public Draw(ArrayList list, PictureBox pic, int s)
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

        private void Resize()
        {
            _multiplyHeight = 1;
            if (_bmpsave.Width != _pnlSamples.Width || _bmpsave.Height != _pnlSamples.Height)
            {
                _bmpsave = new Bitmap(_pnlSamples.Width, _pnlSamples.Height);
                _g = Graphics.FromImage(_bmpsave);
                _pnlSamples.Image = _bmpsave;
            }

            if (_pnlSamples.Height != _originalPanelHeight)
            {
                _multiplyHeight = _pnlSamples.Height / (double)(_originalPanelHeight);
            }
        }

        private void InitializeDrawParameters()
        {
            _g.Clear(Color.White);

            // use black sometimes
            _blackPen = new Pen(Color.Black);
            _blackBrush = new SolidBrush(Color.Black);

            // use red sometimes
            _redPen = new Pen(Color.Red);
            _redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            _width = (_pnlSamples.Width / _arrayToSort.Count) - 1;
            _swaps = new List<int>();
        }

        private void DrawSamples()
        {
            Resize();
            InitializeDrawParameters();

            // start with white background


            for (var i = 0; i < _arrayToSort.Count; i++)
            {
                var x = (int)(((double)_pnlSamples.Width / _arrayToSort.Count) * i);

                var itemHeight = (int)Math.Round(Convert.ToDouble(_arrayToSort[i]) * _multiplyHeight);

                // draw highlighed versions
                if (HighlightedIndexes.ContainsKey(i))
                {
                    DrawRed(x, itemHeight, i);
                }

                else // draw normal versions
                {
                    DrawBlack(x, itemHeight);
                }

            }
            if (_swaps.Count > 1)
            {
                DrawSwaps();
            }


        }

        private void DrawSwaps()
        {
            string text;
            if (_swaps[0] > _swaps[1])
            {
                text = "SWAPING " + _swaps[0] + " / " + _swaps[1];
                _g.DrawString(text, new Font("Arial", 10), _redBrush, new Point(0, 5));
            }
            else
            {
                text = "NO SWAPING";
                _g.DrawString(text, new Font("Arial", 10), _redBrush, new Point(0, 5));
            }
        }

        private void DrawBlack(int x, int itemHeight)
        {
            if (_width <= 1)
            {
                _g.DrawLine(_blackPen, new Point(x, _pnlSamples.Height), new Point(x, _pnlSamples.Height - itemHeight));
            }
            else
            {
                _g.FillRectangle(_blackBrush, x, _pnlSamples.Height - itemHeight, _width, _pnlSamples.Height);
            }
        }

        private void DrawRed(int x, int itemHeight, int i)
        {
            if (_width <= 1)
            {
                _g.DrawLine(_redPen, new Point(x, _pnlSamples.Height), new Point(x, _pnlSamples.Height - itemHeight));
                _swaps.Add((int)_arrayToSort[i]);
            }

            else
            {
                _g.FillRectangle(_redBrush, x, _pnlSamples.Height - itemHeight, _width, _pnlSamples.Height);
                _swaps.Add((int)_arrayToSort[i]);
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
