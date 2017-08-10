using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Project
{
    public class Array
    {
        ArrayList arrayToSort;
        Draw draw = new Draw();
         // highlight all of these indexes in the frame
        Random rand = new Random();

        public ArrayList PrepareForSort(int capacity,PictureBox pnlSort1)
        {

            arrayToSort = new ArrayList(capacity);
            for (int i = 0; i < arrayToSort.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / arrayToSort.Capacity * pnlSort1.Height);
                arrayToSort.Add(y);
            }
            Randomize(arrayToSort);
            return arrayToSort;
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

        public ArrayList BubbleSort(ArrayList arrayToSort, Dictionary<int, bool> highlightedIndexes, PictureBox pnl, Bitmap bitmap)
        {
            bool swapMade = true;
            int n = arrayToSort.Count - 1;
            for (int i = 0; i < n && swapMade; i++)
            {
                swapMade = false;

                for (int j = n; j > i; j--)
                {
                    if (draw.CompareItems(arrayToSort, j - 1, j,highlightedIndexes,pnl,bitmap) > 0)
                    {
                        draw.SwapItems(arrayToSort, j - 1, j, highlightedIndexes, pnl,bitmap );
                        swapMade = true;
                    }
                }
            }

            return arrayToSort;
        }

        public bool isSorted(IList checkThis)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }


    }
}
