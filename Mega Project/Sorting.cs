using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mega_Project
{
    public class Sorting
    {
        public Draw draw;
        ArrayList list;
        PictureBox pic;
        int s;

        public Sorting(ArrayList list, PictureBox pic, int s)
        {
            draw = new Draw(list, pic, s);
        }

        public IList BubbleSort(IList arrayToSort)
        {
            bool swapMade = true;
            int n = arrayToSort.Count - 1;
            for (int i = 0; i < n && swapMade; i++)
            {
                swapMade = false;

                for (int j = n; j > i; j--)
                {
                    if (CompareItems(arrayToSort, j - 1, j) > 0)
                    {
                        SwapItems(arrayToSort, j - 1, j);
                        swapMade = true;
                    }
                }
            }

            return arrayToSort;
        }

        private int CompareItems(IList arrayToSort, int index1, int index2)
        {
            if (!draw.highlightedIndexes.ContainsKey(index1))
                draw.highlightedIndexes.Add(index1, false);
            if (!draw.highlightedIndexes.ContainsKey(index2))
                draw.highlightedIndexes.Add(index2, false);

            draw.operationCount++;
            draw.checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }

        private void SwapItems(IList arrayToSort, int index1, int index2)
        {
            object temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!draw.highlightedIndexes.ContainsKey(index1))
                draw.highlightedIndexes.Add(index1, false);
            if (!draw.highlightedIndexes.ContainsKey(index2))
                draw.highlightedIndexes.Add(index2, false);

            draw.operationCount += 2;
            draw.checkForFrame();
        }



    }
}
