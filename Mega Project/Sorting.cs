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
        Random rand = new Random();
        public int operations_compare;
        public int operations_swap;
        public Sorting(ArrayList list, PictureBox pic, int s)
        {
            draw = new Draw(list, pic, s);
        }
        // simple to program, but really terrible in performance
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

        // better than normal bubble sort, but still slow
        public IList BiDirectionalBubbleSort(IList arrayToSort)
        {
            int limit = arrayToSort.Count;
            int st = -1;
            bool swapped = false;
            do
            {
                swapped = false;
                st++;
                limit--;

                for (int j = st; j < limit; j++)
                {
                    if (CompareItems(arrayToSort, j, j + 1) > 0)
                    {
                        SwapItems(arrayToSort, j, j + 1);
                        swapped = true;
                    }
                }

                if (swapped) // if there was no swap in the first half, we're sorted!
                {
                    swapped = false; // stop after this if we make no swaps

                    for (int j = limit - 2; j >= st; j--) // subtract 2 since we already checked and fixed limit - 1
                    {
                        if (CompareItems(arrayToSort, j, j + 1) > 0)
                        {
                            SwapItems(arrayToSort, j, j + 1);
                            swapped = true;
                        }
                    }
                }

            } while (st < limit && swapped);

            return arrayToSort;
        }

        // similar concept as Shell Sort, but without trickle-down and with smaller gap shrinkage, so it's slightly slower
        public IList CombSort(IList arrayToSort)
        {
            int gap = arrayToSort.Count;
            int swaps = 0;

            do
            {
                gap = (int)(gap / 1.247330950103979);
                if (gap < 1)
                {
                    gap = 1;
                }
                int i = 0;
                swaps = 0;

                do
                {
                    if (CompareItems(arrayToSort, i, i + gap) > 0)
                    {
                        SwapItems(arrayToSort, i, i + gap);
                        swaps = 1;
                    }
                    i++;
                } while (!(i + gap >= arrayToSort.Count));

            } while (!(gap == 1 && swaps == 0));

            return arrayToSort;
        }

        // super-fast, but it requires the data to have a small amount of variation (ideally n or less)
        public IList CountingSort(IList arrayToSort)
        {
            object min = null;
            object max = null;

            SetItem(arrayToSort, ref min, 0);
            SetItem(arrayToSort, ref max, 0);

            // start at 1 because we're already considering 0
            for (int i = 1; i < arrayToSort.Count; i++)
            {
                if (CompareItems(arrayToSort, i, min) < 0)
                {
                    SetItem(arrayToSort, ref min, i);
                }
                else if (CompareItems(arrayToSort, i, max) > 0)
                {
                    SetItem(arrayToSort, ref max, i);
                }
            }

            int range = (int)max - (int)min + 1;

            // reserve space to store the array in a different form
            int[] count = new int[range];

            for (int i = 0; i < range; i++)
            {
                count[i] = 0;
            }

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                count[(int)GetItem(arrayToSort, i) - (int)min]++;
            }

            // now create the original array in sorted order
            int z = 0;
            for (int i = 0; i < count.Length; i++)
            {
                while (count[i] > 0)
                {
                    SetItem(arrayToSort, z, (object)(i + (int)min));
                    z++;
                    count[i]--;
                }
            }

            return arrayToSort;
        }

        // find the right place for each item by counting the number of items smaller than it, then put it in place and pick up the item that was in its place and find a new place for that
        // only useful if you don't mind waiting a long time and writing data damages the medium
        public IList CycleSort(IList arrayToSort)
        {
            int writes = 0;
            for (int cycleStart = 0; cycleStart < arrayToSort.Count; cycleStart++)
            {
                object item = null;
                SetItem(arrayToSort, ref item, cycleStart);

                int pos = cycleStart;

                do
                {
                    int to = 0;
                    for (int i = 0; i < arrayToSort.Count; i++)
                    {
                        if (i != cycleStart)
                        {
                            if (CompareItems(arrayToSort, i, item) < 0)
                            {
                                to++;
                            }
                        }
                    }
                    if (pos != to)
                    {
                        while (pos != to && CompareItems(arrayToSort, item, to) == 0)
                        {
                            to++;
                        }

                        object temp = null;
                        SetItem(arrayToSort, ref temp, to);
                        lock (this)
                        {
                            SetItem(arrayToSort, to, item);
                        }
                        item = temp;

                        writes++;

                        pos = to;
                    }

                } while (cycleStart != pos);
            }

            return arrayToSort;
        }

        // This is basically just a slower version of Insertion Sort, because it adds in unnecessary compares after moving an item into position.
        public IList GnomeSort(IList arrayToSort)
        {
            int pos = 1;
            while (pos < arrayToSort.Count)
            {
                if (CompareItems(arrayToSort, pos, pos - 1) >= 0)
                {
                    pos++;
                }
                else
                {
                    SwapItems(arrayToSort, pos, pos - 1);

                    if (pos > 1)
                    {
                        pos--;
                    }
                }
            }

            return arrayToSort;
        }

        // a fast sort O(n log n) with near-zero extra storage (not quite as fast as Quicksort and Merge Sort)
        public IList HeapSort(IList list)
        {
            for (int i = (list.Count - 1) / 2; i >= 0; i--)
            {
                AdjustHeap(list, i, list.Count - 1);
            }

            for (int i = list.Count - 1; i >= 1; i--)
            {
                SwapItems(list, 0, i);
                AdjustHeap(list, 0, i - 1);
            }

            return list;
        }
        private void AdjustHeap(IList list, int i, int m)
        {
            object Temp = null;
            SetItem(list, ref Temp, i);

            int j = i * 2 + 1;

            while (j <= m)
            {
                if (j < m)
                {
                    if (CompareItems(list, j, j + 1) < 0)
                    {
                        j = j + 1;
                    }
                }

                if (CompareItems(list, Temp, j) < 0)
                {
                    SetItem(list, i, j);

                    i = j;
                    j = 2 * i + 1;
                }
                else
                {
                    j = m + 1;
                }
            }

            SetItem(list, i, Temp);
        }

        // simple concept, but slow
        public IList InsertionSort(IList arrayToSort)
        {
            for (int i = 1; i < arrayToSort.Count; i++)
            {
                object val = null;
                SetItem(arrayToSort, ref val, i);
                int j = i - 1;
                bool done = false;

                do
                {
                    if (CompareItems(arrayToSort, j, val) > 0)
                    {
                        SetItem(arrayToSort, j + 1, j);
                        //arrayToSort[j] = val; // in practice, we do not assign here! wait until after the loop! (this is for visuals)

                        j--;
                        if (j < 0)
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }

                } while (!done);

                SetItem(arrayToSort, j + 1, val);
            }

            return arrayToSort;
        }

        // a fast sort with n extra storage
        public IList MergeSortDoubleStorage(IList a, int low, int high)
        {
            int l = low;
            int h = high;

            // sorted when down to one element
            IList r = new ArrayList();
            if (l == h)
            {
                r.Add(GetItem(a, low));
                return r;
            }
            else if (l > h)
            {
                return r; // empty
            }

            int mid = (l + h) / 2;
            IList firstList = MergeSortDoubleStorage(a, l, mid);
            IList secondList = MergeSortDoubleStorage(a, mid + 1, h);

            // combine the lists
            int startFirst = 0;
            int startSecond = 0;
            int i = l;

            // create a new array combining the smaller two
            while (startFirst < firstList.Count && startSecond < secondList.Count && i <= h)
            {
                // penalty for comparing two objects
                draw.operationCount++;

                if (((IComparable)firstList[startFirst]).CompareTo(secondList[startSecond]) < 0)
                {
                    r.Add(firstList[startFirst]);

                    // also overwrite the original array (for visuals - in practice, just replace the original array with the new sorted array)
                    SetItem(a, i, firstList[startFirst]);

                    startFirst++;
                    i++;
                }
                else
                {
                    r.Add(secondList[startSecond]);

                    // also overwrite the original array (for visuals - in practice, just replace the original array with the new sorted array)
                    SetItem(a, i, secondList[startSecond]);

                    startSecond++;
                    i++;
                }
            }

            // add the rest of the list (one is finished)
            while (startFirst < firstList.Count && i <= h)
            {
                r.Add(firstList[startFirst]);

                // also overwrite the original array (for visuals - in practice, just replace the original array with the new sorted array)
                SetItem(a, i, firstList[startFirst]);

                startFirst++;
                i++;
            }
            while (startSecond < secondList.Count && i <= h)
            {
                r.Add(secondList[startSecond]);

                // also overwrite the original array (for visuals - in practice, just replace the original array with the new sorted array)
                SetItem(a, i, secondList[startSecond]);

                startSecond++;
                i++;
            }

            return r;
        }

        // not fast because of how long the merging process takes
        public IList MergeSortInPlace(IList a, int low, int height)
        {
            int l = low;
            int h = height;

            if (l >= h)
            {
                return a;
            }

            int mid = (l + h) / 2;
            MergeSortInPlace(a, l, mid);
            MergeSortInPlace(a, mid + 1, h);

            int end_lo = mid;
            int start_hi = mid + 1;
            while ((l <= end_lo) && (start_hi <= h))
            {
                if (CompareItems(a, l, start_hi) < 0)
                {
                    l++;
                }
                else
                {
                    object temp = null;
                    SetItem(a, ref temp, start_hi);

                    for (int k = start_hi - 1; k >= l; k--)
                    {
                        SetItem(a, k + 1, k);
                    }
                    SetItem(a, l, temp);

                    l++;
                    end_lo++;
                    start_hi++;
                }
            }

            return a;
        }

        // like Bubble Sort, except we skip forward after each compare/swap and come back later and do the other compares/swaps we need (first i is odd, then even)
        public IList OddEvenSort(IList arrayToSort)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < arrayToSort.Count - 1; i += 2)
                {
                    if (CompareItems(arrayToSort, i, i + 1) > 0)
                    {
                        SwapItems(arrayToSort, i, i + 1);

                        sorted = false;
                    }
                }

                for (var i = 0; i < arrayToSort.Count - 1; i += 2)
                {
                    if (CompareItems(arrayToSort, i, i + 1) > 0)
                    {
                        SwapItems(arrayToSort, i, i + 1);

                        sorted = false;
                    }
                }
            }

            return arrayToSort;
        }

        // different from Counting sort only in that this sort moves/copies the items to a new list, then moves/copies them back
        // also requires the data to have small variability (can't make a billion-count array)
        public IList PigeonholeSort(IList arrayToSort)
        {
            if (arrayToSort == null || arrayToSort.Count == 0) return arrayToSort;

            object max = null;
            object min = null;
            SetItem(arrayToSort, ref max, 0);
            SetItem(arrayToSort, ref min, 0);

            // find min and max
            for (int i = 0; i < arrayToSort.Count; i++)
            {
                if (CompareItems(arrayToSort, i, max) > 0)
                {
                    SetItem(arrayToSort, ref max, i);
                }
                else if (((IComparable)arrayToSort[i]).CompareTo(min) < 0)
                {
                    SetItem(arrayToSort, ref min, i);
                }
            }

            // reserve space to store array in a different form
            ArrayList[] holder = new ArrayList[(int)max - (int)min + 1];

            for (int i = 0; i < holder.Length; i++)
            {
                holder[i] = new ArrayList();
            }

            for (int i = 0; i < arrayToSort.Count; i++)
            {
                holder[(int)GetItem(arrayToSort, i) - (int)min].Add(GetItem(arrayToSort, i));
            }

            int k = 0;

            for (int i = 0; i < holder.Length; i++)
            {
                if (holder[i].Count > 0)
                {
                    for (int j = 0; j < holder[i].Count; j++)
                    {
                        SetItem(arrayToSort, k, holder[i][j]);

                        k++;
                    }
                }
            }

            return arrayToSort;
        }

        // a fast sort with log2(n) extra storage
        public IList Quicksort(IList a, int left, int right)
        {
            int i = left;
            int j = right;

            object x = null;
            SetItem(a, ref x, rand.Next(left, right + 1));

            // find items to swap so smaller items are on the left side and larger items are on the right side
            while (i <= j) // when i=j, need to compare to know which way to move (left or right)
            {
                while (CompareItems(a, i, x) < 0)
                {
                    i++;
                }
                while (CompareItems(a, x, j) < 0)
                {
                    j--;
                }

                if (i < j)
                {
                    SwapItems(a, i, j);
                    i++;
                    j--;
                }
                else if (i == j) // no need to swap in this case
                {
                    i++;
                    j--;
                }
            }

            // now everything from left to j is less than or equal to the pivot
            // and everything from i to right is greater than or equal to the pivot
            // note that we don't need to push the pivot in between these partitions to be fast
            if (left < j)
            {
                Quicksort(a, left, j);
            }
            if (i < right)
            {
                Quicksort(a, i, right);
            }

            return a;
        }

        // I don't see much improvement by adding Insertion Sort (more useful if you're using Tri-Median method)
        public IList QuicksortWithInsertionSort(IList a, int left, int right)
        {
            int i = left;
            int j = right;

            if (right - left <= 4)
            {
                InsertionSortHelper(a, left, right);
                return a;
            }

            int pivotLocation = rand.Next(left, right + 1);
            object x = null;
            SetItem(a, ref x, pivotLocation);

            while (i <= j)
            {
                while (CompareItems(a, i, x) < 0)
                {
                    i++;
                }
                while (CompareItems(a, x, j) < 0)
                {
                    j--;
                }

                if (i < j)
                {
                    SwapItems(a, i, j);
                    i++;
                    j--;
                }
                else if (i == j) // no swap needed
                {
                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuicksortWithInsertionSort(a, left, j);
            }
            if (i < right)
            {
                QuicksortWithInsertionSort(a, i, right);
            }

            return a;
        }
        private IList InsertionSortHelper(IList arrayToSort, int left, int right)
        {
            for (int i = left + 1; i < right + 1; i++)
            {
                object val = null;
                SetItem(arrayToSort, ref val, i);

                int j = i - 1;
                bool done = false;

                do
                {
                    if (CompareItems(arrayToSort, j, val) > 0)
                    {
                        SetItem(arrayToSort, j + 1, j);

                        j--;
                        if (j < 0)
                        {
                            done = true;
                        }
                    }
                    else
                    {
                        done = true;
                    }

                } while (!done);

                SetItem(arrayToSort, j + 1, val);
            }

            return arrayToSort;
        }

        // requires all data to be positive integers (this version), but sorts in O(n) time (the 16-bit version sorts in 2 read passes and 2 write passes and finishes much faster than Quicksort)
        // in practice, 16-bit version doesn't do much better than 8-bit version (in visualization, it makes a HUGE difference)
        // this is comparable to Pigeonhole Sort, but without the variability restriction (this makes set number of buckets depending on which version - 8-bit version makes 256 buckets)
        public IList RadixSort(IList array)
        {
            // based on http://algorithmsandstuff.blogspot.com/2014/06/radix-sort-in-c-sharp.html and https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Radix_sort#C.23_least_significant_digit_.28LSD.29_radix_sort_implementation
            int shift = 0;
            int totalBits = 32; // 32 bits for int

            // decide how many bits to look at during each round (and how many buckets to use)
            //int maskLength = 16; // totalBits must be evenly divided by this
            //int mask = 65535; // 16 bits, all 1's; this many buckets may seem like overkill, but when you have 1 million items to sort, it makes much more sense

            int maskLength = 8; // totalBits must be evenly divided by this (don't use 6 or 10)
            int mask = 255; // 8 bits, all 1's

            //int maskLength = 1;
            //int mask = 1; // 1 bit at a time

            List<Queue<int>> buckets = new List<Queue<int>>();
            for (int i = 0; i <= mask; i++) // exponentially more buckets based on how many bits are being checked - so we can't just use 32 bits
            {
                Queue<int> q = new Queue<int>();
                buckets.Add(q);
            }

            // look at every bit of every item
            while (shift < totalBits)
            {
                int i;

                // put every item into a bucket based on its lowest bits, then the next lowest bits, and so on
                for (i = 0; i < array.Count; i++)
                {
                    int bucketNumber = ((int)GetItem(array, i) >> shift) & mask;

                    buckets[bucketNumber].Enqueue((int)GetItem(array, i));
                }

                i = 0;
                // put all items back into the array, lowest buckets first, first-in-first-out
                foreach (Queue<int> bucket in buckets)
                {
                    while (bucket.Count > 0)
                    {
                        SetItem(array, i, (object)bucket.Dequeue());
                        i++;
                    }
                }

                shift += maskLength;
            }

            return array;
        }

        // simple concept, but slow
        public IList SelectionSort(IList arrayToSort)
        {
            int min;
            for (int i = 0; i < arrayToSort.Count; i++)
            {
                min = i;

                for (int j = i + 1; j < arrayToSort.Count; j++)
                {
                    if (CompareItems(arrayToSort, j, min) < 0)
                    {
                        min = j;
                    }
                }

                if (i < min) // if i is still equal to min, no need to swap
                {
                    SwapItems(arrayToSort, i, min);
                }
            }

            return arrayToSort;
        }

        // surprisingly fast considering how simple it is to understand
        public IList ShellSort(IList arrayToSort)
        {
            int i, j, increment;
            object temp = null;

            // better sequence
            List<int> shellSequence = new List<int> { 0, 1, 4, 10, 23, 57, 132, 301, 701, 1750 };
            while (shellSequence[shellSequence.Count - 1] < arrayToSort.Count)
                shellSequence.Add(shellSequence[shellSequence.Count - 1] * 701 / 301);

            int sequenceIndex = shellSequence.Count - 1; // the end of the sequence is too large, so look at the next one down
            increment = shellSequence[sequenceIndex];
            while (increment >= arrayToSort.Count)
            {
                sequenceIndex--;
                increment = shellSequence[sequenceIndex];
            }

            while (increment > 0)
            {
                for (i = increment; i < arrayToSort.Count; i++)
                {
                    j = i;
                    SetItem(arrayToSort, ref temp, i);

                    bool changeMade = false;

                    while ((j >= increment) && CompareItems(arrayToSort, j - increment, temp) > 0)
                    {
                        SetItem(arrayToSort, j, j - increment);

                        changeMade = true;

                        j = j - increment;
                    }

                    if (changeMade)
                    {
                        SetItem(arrayToSort, j, temp);
                    }
                }

                sequenceIndex--;
                increment = shellSequence[sequenceIndex];
            }

            return arrayToSort;
        }



        // based on code from http://www.codeproject.com/Articles/26048/Fastest-In-Place-Stable-Sort
        // This sort actually loses to HeapSort, despite being an improvement on it
        public void Smoothsort(IList plngArray)
        {
            // 'SmoothSort is the main function that performs the smoothsort.
            // 'It has two main phases, the first is to build a heap.
            // 'The second phase is to remove the top element of the heap and
            // 'rebuild the heap.  This second phase is repeated until there
            // 'is nothing left in the heap and all of the data is sorted.

            // 'Initialise the variables.
            int lngOneBasedIndex = 1;
            int lngNodeIndex = 0;
            int lngLeftRightTreeAddress = 1;
            int lngSubTreeSize = 1;
            int lngLeftSubTreeSize = 1;

            // 'The first phase is to build the heap.  Loop through the data
            // 'one element at a time.
            // 'Each element is a node in the heap.
            while (lngOneBasedIndex != plngArray.Count)
            {
                // 'This element is at the top of a sub-heap (which may just be itself only).

                // 'If the current node is the right child of its parent
                // If lngLeftRightTreeAddress Mod 8 = 3 Then
                if (lngLeftRightTreeAddress % 8 == 3)
                {
                    // 'Push this element down the sub-heap that it sits on - just like heap sort
                    SmoothSift(plngArray, lngNodeIndex, lngSubTreeSize, lngLeftSubTreeSize);

                    // 'The next element to be processed will be the parent of this sub-heap.

                    // '1. Move up a right leg of the virtual left/right tree
                    lngLeftRightTreeAddress = (lngLeftRightTreeAddress + 1) / 4;

                    // '2. The SubTreeSizes of the parent of a right child is two steps back
                    // 'down the sequence of Leonardo numbers, Move up the sequence of leonardo
                    // 'numbers twice.
                    SmoothUp(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                    SmoothUp(ref lngSubTreeSize, ref lngLeftSubTreeSize);

                    // 'Dont worry about the parent of this element being off the scale.  It is
                    // 'always the next element and we do a Trinkle on the last element anyway.
                }
                else if (lngLeftRightTreeAddress % 4 == 1) // 'This is always true if it gets here
                {
                    // 'If the current node is the left child of its parent

                    // 'The parent of this node will be a distance away equal to the size of its
                    // 'own left child.  See if this is within the bounds of the data.
                    // If lngOneBasedIndex + lngLeftSubTreeSize < UBound(plngArray) + 1 Then
                    if (lngOneBasedIndex + lngLeftSubTreeSize < plngArray.Count)
                    {
                        // 'If the parent of this node is within the data, just push this value down
                        // 'its own sub heap.  Just like heap sort.
                        SmoothSift(plngArray, lngNodeIndex, lngSubTreeSize, lngLeftSubTreeSize);
                    }
                    else
                    {
                        // 'The parent of this node is beyond the end of the data.
                        // 'Give this node a third child which is the last element prior to the start
                        // 'of this sub-heap.  This element will be the sibling of this node or else
                        // 'it will be the sibling of one of the parents of this node.
                        SmoothTrinkle(plngArray, lngNodeIndex, lngLeftRightTreeAddress, lngSubTreeSize, lngLeftSubTreeSize);
                    }

                    // 'The next element to be processed will be the far left-left-left child of the right sibling
                    // 'of this node

                    // 'To get to the right sibling of this node, the formula is p * 2 + 1.  (See the info above on
                    // 'the virtual tree.
                    // 'Then each time we go down the left leg we then apply the p * 2 - 1 formula.

                    // 'As it turns out, the formula to go p * 2 + 1 and then to repeat p * 2 - 1 n times
                    // 'is:     p^(n-1)+1
                    // '
                    // 'Pretty tricky but it works
                    do
                    {
                        SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                        lngLeftRightTreeAddress = lngLeftRightTreeAddress * 2;
                    } while (lngSubTreeSize != 1); // 'Continue until we reach the bottom of the tree

                    lngLeftRightTreeAddress = lngLeftRightTreeAddress + 1;
                }

                lngOneBasedIndex = lngOneBasedIndex + 1;
                lngNodeIndex = lngNodeIndex + 1;
            }

            // 'SmoothTrinkle on the last element, will give the last element 3 children.  This will be needed
            // 'if the last element was a right child
            SmoothTrinkle(plngArray, lngNodeIndex, lngLeftRightTreeAddress, lngSubTreeSize, lngLeftSubTreeSize);

            // 'This loop is about reducing the size of the heap by 1 and reshuffling the
            // 'heap until the whole lot is sorted.  Just like heap sort except that the top
            // 'of the heap is where the heap gets smaller, meaning that we do not have to do
            // 'things in reverse and we do not have to pick an element from the bottom of the
            // 'heap and push it down from the top.
            // Do While lngOneBasedIndex <> 1
            while (lngOneBasedIndex != 1)
            {
                lngOneBasedIndex = lngOneBasedIndex - 1;

                if (lngSubTreeSize == 1)
                {
                    // 'This sub-tree only had one element

                    // 'Prepare to look at the previous element in the next loop
                    lngNodeIndex = lngNodeIndex - 1;

                    // 'Navigate in both trees to the next element.
                    // 'First you navigate up, as long as it is a left leg (which it may not be,
                    // 'it may already be a right leg, in which case you stay there).
                    // 'Then you go across to the left leg.
                    // 'Once again, another pretty tricky piece of maths but it works.
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress - 1;

                    while (lngLeftRightTreeAddress % 2 == 0)
                    {
                        lngLeftRightTreeAddress = lngLeftRightTreeAddress / 2;
                        SmoothUp(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                    }
                }
                else if (lngSubTreeSize >= 3) // 'It must fall in here, sub trees are either size 1,1,3,5,9,15 etc
                {
                    // 'This makes the lngLeftRightTreeAddress even and will cause the Trinkle
                    // 'function to navigate up to the right level.
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress - 1;

                    // 'This node has children, get the index of the left child
                    lngNodeIndex = lngNodeIndex + lngLeftSubTreeSize - lngSubTreeSize;
                    // 'The right child, being immediately behind this node will now be the new top

                    // 'If the node to be removed is the top top node then there are no nodes to the left of it.
                    // 'We do not need to call SmoothSemiTrinkle to join the left child up with previous heaps.
                    // 'If it is not the top top node then we need to call SmoothSemiTrinkle on the left child
                    // 'to link it up with the heaps to the left.
                    if (lngLeftRightTreeAddress != 0)
                    {
                        SmoothSemiTrinkle(plngArray, lngNodeIndex, lngLeftRightTreeAddress, lngSubTreeSize, lngLeftSubTreeSize);
                    }

                    // 'Navigate across from the left child to the right child.
                    SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);

                    // 'Get the lngLeftRightTreeAddress of the left child
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress * 2 + 1;

                    // 'Finish navigating across from the left child to the right child
                    lngNodeIndex = lngNodeIndex + lngLeftSubTreeSize;

                    // 'Call semi-smooth trinkle to make sure that it has three legs and that it links up with
                    // 'the left child and all other previous heaps.
                    SmoothSemiTrinkle(plngArray, lngNodeIndex, lngLeftRightTreeAddress, lngSubTreeSize, lngLeftSubTreeSize);

                    SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress * 2 + 1;
                }
            }
        }
        private void SmoothUp(ref int lngSubTreeSize, ref int lngLeftSubTreeSize)
        {
            // 'This function, passed two sequential Leonardo numbers like 15, 9
            // 'will step up the sequence of Leonardo numbers and return the next one.
            // '
            // 'For example, if passed 15,9 - this function will return 25,15
            // '             if passed 5,3  - this function will return 9, 5
            // '
            // 'If called once, it will calculate the size of a parent heap for a left child.
            // 'If called once, it will calculate the size of the left sibling of a right child.
            // 'If called twice, it will calculate the size of a parent heap for a right child.

            int temp = lngSubTreeSize + lngLeftSubTreeSize + 1;
            lngLeftSubTreeSize = lngSubTreeSize;
            lngSubTreeSize = temp;
        }
        private void SmoothDown(ref int lngSubTreeSize, ref int lngLeftSubTreeSize)
        {
            // 'This function, passed two sequential Leonardo numbers like 15, 9
            // 'will step down the sequence of Leonardo numbers and return the previous one.
            // '
            // 'For example, if passed 15,9 - this function will return 9, 5
            // '             if passed 5,3  - this function will return 3, 1
            // '
            // 'If called once, it will calculate the size of a left child sub-heap.
            // 'If called once, it will calculate the size of the right sibling of a left child.
            // 'If called twice, it will calculate the size of a right child sub-heap.

            int temp = lngSubTreeSize - lngLeftSubTreeSize - 1;
            lngSubTreeSize = lngLeftSubTreeSize;
            lngLeftSubTreeSize = temp;
        }
        private void SmoothSift(IList plngArray, int lngNodeIndex, int lngSubTreeSize, int lngLeftSubTreeSize)
        {
            // 'This function pushes the element on top of a binary heap down
            // 'until it reaches the correct place in the heap.
            // 'Just like heap sort.

            int lngChildIndex;

            // 'Do while the current tree has children
            while (lngSubTreeSize >= 3)
            {
                // 'Get the index of the left child
                lngChildIndex = lngNodeIndex - lngSubTreeSize + lngLeftSubTreeSize;

                // 'Compare the value of the left child with the right child to find
                // 'the child with the maximum value.
                // If plngArray(lngChildIndex).theKey < plngArray(lngNodeIndex - 1).theKey Then
                if (CompareItems(plngArray, lngChildIndex, lngNodeIndex - 1) < 0)
                {
                    // 'The right child has the greater value, this is the value that
                    // 'will rise to the top of the heap if need be.
                    lngChildIndex = lngNodeIndex - 1;

                    // 'Because we are going down the right child, we need to do an
                    // 'extra SmoothDown operation because right children are two
                    // 'steps down the Leonardo sequence.
                    SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);

                    // 'We dont need to worry about the virtual left/right tree
                    // 'because we wont be going back up the tree.
                }

                // 'Compare the greater child with the parent
                if (CompareItems(plngArray, lngNodeIndex, lngChildIndex) >= 0)
                {
                    // 'The parent was bigger, the job is done, no more to do.
                    lngSubTreeSize = 1;
                }
                else
                {
                    // 'The child is greater than the parent, swap them around
                    SwapItems(plngArray, lngNodeIndex, lngChildIndex);

                    // 'Move down to the next level of the heap
                    lngNodeIndex = lngChildIndex;
                    // 'Going down either leg only requires one step because an
                    // 'extra step for the right has already been done.
                    SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                }
            }
        }
        private void SmoothTrinkle(IList plngArray, int lngNodeIndex, int lngLeftRightTreeAddress, int lngSubTreeSize, int lngLeftSubTreeSize)
        {
            // 'This function pushes the current node down into the heap
            // 'until it reaches the correct place.
            // 'It differs from SmoothSift though as the node passed
            // 'to this function is given three children:
            // ' - The two normal children that all nodes have; plus
            // ' - A third child which is the top of the previous complete sub-heap
            // '
            // 'It assumes that the node is already the top of a properly constructed
            // 'heap with the normal 2 children.

            int lngChildIndex;
            int lngPreviousCompleteTreeIndex;

            // 'Consider the complete virtual tree:
            // '
            // '                                       1
            // '                                      / \
            // '                      ----------------   ----------------
            // '                     /                                   \
            // '                    1                                     3
            // '                   / \                                   / \
            // '            -------   -------                     -------   -------
            // '           /                 \                   /                 \
            // '          1                   3                 5                   11
            // '         / \                 / \               / \                 / \
            // '       --   --             --   --           --   --             --   --
            // '      /       \           /       \         /       \           /       \
            // '     1         3         5         11      9         19        21        43
            // '    / \       / \       / \       / \     / \       / \       / \       / \
            // '   1   3     5   11    9   19    21  43  17  35    37  75    41  83    85  171
            // '
            // '
            // 'If the number of elements in the heap is smaller than this by let say 3,
            // 'the virtual tree will look like this:
            // '
            // '
            // '                    1
            // '                   / \
            // '            -------   -------
            // '           /                 \
            // '          1                   3                 5
            // '         / \                 / \               / \
            // '       --   --             --   --           --   --
            // '      /       \           /       \         /       \
            // '     1         3         5         11      9         19        21        43
            // '    / \       / \       / \       / \     / \       / \       / \       / \
            // '   1   3     5   11    9   19    21  43  17  35    37  75    41  83    85  171
            // '
            // '
            // 'This function may have been passed the details of the node at address #43 above.
            // 'It will join these heaps into a single heap and keep on processing until it reaches
            // 'the sub-heap with the address #1 at the top.

            // 'Keep looping until the virtual tree address is > 0 (ie all of the above heaps)
            // Do While lngLeftRightTreeAddress > 0
            while (lngLeftRightTreeAddress > 0)
            {
                // 'Here is yet another tricky thing.  This bit is how the function navigates
                // 'from the top of one of the above complete heaps to the top of the previous.
                // '
                // 'Firstly note that all of the addresses in the virtual tree are odd.
                // '(Not surprisingly as the formulas for getting them are *2-1 and *4-1).
                // '
                // 'Now consider the navigation above:
                // '
                // 'Starting at address #43, Subtract 1 and divide by 2 gives 21.
                // '#21 Is odd so it is a good address and since it is the left sibling of #43
                // 'we need to go up 1.
                // '
                // 'Starting at address #21, subtract 1 and divide by 2 gives 10.
                // '#10 is even and so it is not a good address, divide by 2 again to get #5.
                // '#5 is odd so it is a good address and correct in the above example.
                // 'The SmoothUp function needs to be called once to get to the parent of #21,
                // 'it needs to be called twice to get to its parent (also the parent of #5).
                // 'This means that SmoothUp needs to be called three times and then SmoothDown
                // 'needs to be called once to navigate to #5.
                // 'The net is that SmoothUp needs to be called twice - the same number of times
                // 'that we need to divide by zero.
                // '
                // 'Starting at address #5, we need to subtract 1 and then divide by 2 twice to
                // 'get address #1.  Also SmoothUp needs to be called twice.
                // '
                // 'This loop achieves this navigation.  When SmoothTrinkle is called, the
                // 'lngLeftRightTreeAddress is valid (odd) and so this loop does not execute.
                // 'Each time the outer loop executes, it subtracts 1 from the lngLeftRigthTreeAddress
                // '(later) and so this loop correctly does the / 2 and the SmoothUps.
                // Do While lngLeftRightTreeAddress Mod 2 = 0
                while (lngLeftRightTreeAddress % 2 == 0)
                {
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress / 2;
                    SmoothUp(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                }

                // 'Get the index of the last full tree prior to this sub tree
                lngPreviousCompleteTreeIndex = lngNodeIndex - lngSubTreeSize;
                // 'In the above example, for the node #43, get the address of #21 (ie its left sibling)
                // 'In the above example, for the node #21, get the address of #5 (ie left sibling of parent)

                // 'If this node is the top of the furthest left complete tree then stop processing
                // If lngLeftRightTreeAddress = 1 Then
                if (lngLeftRightTreeAddress == 1)
                {
                    // 'We are in this situation (The numbers here are values)
                    // '            _____
                    // '           9     \   <-lngNodeIndex points here
                    // '          / \     \
                    // '        --   --    \
                    // '       /       \    \
                    // '      5         8    \_____>9
                    // '     / \       / \
                    // '    /   \     /   \
                    // '   3     4   6     7
                    // '  / \
                    // ' 1   2
                    // '
                    // 'There is nothing on the left of this heap.

                    // 'Job is done, stop processing
                    lngLeftRightTreeAddress = 0;
                }
                // 'Else if the value at the top of the previous complete heap is less than this node

                // ElseIf plngArray(lngPreviousCompleteTreeIndex).theKey <= plngArray(lngNodeIndex).theKey Then
                else if (CompareItems(plngArray, lngPreviousCompleteTreeIndex, lngNodeIndex) <= 0)
                {
                    // 'We are in this situation (The numbers here are values)
                    // '            _____
                    // '           9     \   <-lngPreviousCompleteTreeIndex points here
                    // '          / \     \
                    // '        --   --    \
                    // '       /       \    \
                    // '      5         8    \_____10  <-lngNodeIndex points here
                    // '     / \       / \        / \
                    // '    /   \     /   \      /   \
                    // '   3     4   6     7    7     6
                    // '  / \
                    // ' 1   2
                    // '
                    // '
                    // 'Clearly the number 10 is larger than 9, the heap is good.

                    // 'Do not push this value further down the tree, job done.
                    lngLeftRightTreeAddress = 0;
                }
                else
                {
                    // 'Make this even so that it gets calculated correctly on the next loop
                    lngLeftRightTreeAddress = lngLeftRightTreeAddress - 1;

                    // 'If this complete heap has only one element
                    // If lngSubTreeSize = 1 Then
                    if (lngSubTreeSize == 1)
                    {
                        // 'We are in this situation (The numbers here are values)
                        // '            _____
                        // '           9     \   <-lngPreviousCompleteTreeIndex points here
                        // '          / \     \
                        // '        --   --    \
                        // '       /       \    \
                        // '      5         8    \_____7  <-lngNodeIndex points here
                        // '     / \       / \
                        // '    /   \     /   \
                        // '   3     4   6     7
                        // '  / \
                        // ' 1   2
                        // '
                        // '
                        // 'Clearly the number 9 is larger than 7

                        // 'Just do a simple swap and move on to the next complete heap
                        SwapItems(plngArray, lngNodeIndex, lngPreviousCompleteTreeIndex);

                        lngNodeIndex = lngPreviousCompleteTreeIndex;

                        // 'After doing this swap, the next complete heap will not
                        // 'necessarily be valid, (ie in this example 7 would be on top of an 8).
                        // 'If this is the last node processed in this function, the
                        // 'SmoothSift call at the end will do this.
                        // 'If this is not the last node processed, the code below compares
                        // 'the previous top, with the children and deals with this.
                    }
                    // 'Else if this complete heap has normal (2) children
                    // ElseIf lngSubTreeSize >= 3 Then
                    else if (lngSubTreeSize >= 3)
                    {
                        // 'We are in one of these two situations:(The numbers here are values)
                        // 'In both situations, the value at the top of the previous complete heap
                        // 'is greater than the top of this heap.
                        // 'Situation A, has a greater child in this heap.
                        // 'Situation B, has the parent greater in this heap.
                        // '
                        // 'Situation A
                        // '            _____
                        // '           9     \   <-lngPreviousCompleteTreeIndex points here
                        // '          / \     \
                        // '        --   --    \
                        // '       /       \    \
                        // '      5         8    \_____7  <-lngNodeIndex points here
                        // '     / \       / \        / \
                        // '    /   \     /   \      /   \
                        // '   3     4   6     7    10    9
                        // '  / \
                        // ' 1   2
                        // '
                        // '
                        // 'Situation B
                        // '            _____
                        // '           9     \   <-lngPreviousCompleteTreeIndex points here
                        // '          / \     \
                        // '        --   --    \
                        // '       /       \    \
                        // '      5         8    \_____7  <-lngNodeIndex points here
                        // '     / \       / \        / \
                        // '    /   \     /   \      /   \
                        // '   3     4   6     7    6     5
                        // '  / \
                        // ' 1   2
                        // '
                        // 'Clearly the number 9 is larger than 7

                        // 'Identify the maximum child of this heap
                        // 'First get the top of the left child
                        lngChildIndex = lngNodeIndex - lngSubTreeSize + lngLeftSubTreeSize;

                        // 'See whether the left or right child is greater.
                        if (CompareItems(plngArray, lngChildIndex, lngNodeIndex - 1) < 0)
                        {
                            // 'The right child is greater
                            // 'Use the right child
                            lngChildIndex = lngNodeIndex - 1;

                            // 'As we are using the right child, do an extra
                            // 'SmoothDown and an extra * 2
                            SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);
                            lngLeftRightTreeAddress = lngLeftRightTreeAddress * 2;
                        }

                        // 'Now compare the value at the top of the previous complete tree
                        // 'with the maximum child value.
                        // If plngArray(lngPreviousCompleteTreeIndex).theKey >= plngArray(lngChildIndex).theKey Then
                        if (CompareItems(plngArray, lngPreviousCompleteTreeIndex, lngChildIndex) >= 0)
                        {
                            // 'The top of the previous complete heap is greater than the top of this
                            // 'heap and greater than both of its children.
                            // 'Swap it into place
                            SwapItems(plngArray, lngNodeIndex, lngPreviousCompleteTreeIndex);

                            // 'Move on ready to do the next complete heap in the SmoothTrinkle
                            lngNodeIndex = lngPreviousCompleteTreeIndex;
                        }
                        else
                        {
                            // 'The child is greater than the the top and greater than
                            // 'the top of the previous complete heap.
                            // 'Swap this up
                            SwapItems(plngArray, lngNodeIndex, lngChildIndex);

                            // 'We are going to stop SmoothTrinke, but now navigate to the
                            // 'child so that a final SmoothSift can make sure that the
                            // 'heap is valid.
                            lngNodeIndex = lngChildIndex;
                            SmoothDown(ref lngSubTreeSize, ref lngLeftSubTreeSize);

                            // 'Stop the SmoothTrinkle process.
                            lngLeftRightTreeAddress = 0;
                        }
                    }
                }
            }

            // 'Make sure that the top of the final heap is pushed down correctly.
            SmoothSift(plngArray, lngNodeIndex, lngSubTreeSize, lngLeftSubTreeSize);
        }
        private void SmoothSemiTrinkle(IList plngArray, int lngNodeIndex, int lngLeftRightTreeAddress, int lngSubTreeSize, int lngLeftSubTreeSize)
        {
            // 'Function to call SmoothTrinkle but only if needed and from the context
            // 'of removing items from the heap.

            int lngIndexTopPreviousCompleteHeap;

            // 'Parameters to this function are:
            // '  lngNodeIndex -            The index of the right child of a node being removed from the heap
            // '  lngLeftRightTreeAddress - Tree address of the left node of a node being removed from the heap
            // '  lngSubTreeSize -          SubTree size of the left sub-heap of a node being removed
            // '  lngLeftSubTreeSize -      Left subtree size of the left sub-heap of a node being removed
            // '                            As a Leonardo tree, the same size as the heap headed by lngNodeIndex.
            // '
            // 'OR
            // '  lngNodeIndex -            The index of the left child of a node being removed from the heap
            // '  lngLeftRightTreeAddress - A number for example 20 that when divided by 2 a number of times will give
            // '                            the virtual tree address of the previous complete heap prior to the heap where the top
            // '                            is being removed.  The address is found when the number becomes odd.
            // '
            // 'The values in lngSubTreeSize need to be SmoothUp'd the same number of times to give the corresponding values for
            // 'the complete heap prior to the heap where the top is being removed.
            // '
            // '  lngSubTreeSize -          SubTree size of the previous complete heap prior to the heap where the top is being removed
            // '  lngLeftSubTreeSize -      Left subtree size of the previous complete heap prior to the heap where the top is being removed
            // '                            As a Leonardo tree, the same size as the heap headed by lngNodeIndex before being SmoothUp'd.


            // 'Get the index of the previous complete heap.
            lngIndexTopPreviousCompleteHeap = lngNodeIndex - lngLeftSubTreeSize;

            // 'If the top of the previous complete heap is larger then this one then swap it and Trinkle It.
            // If plngArray(lngIndexTopPreviousCompleteHeap).theKey > plngArray(lngNodeIndex).theKey Then
            if (CompareItems(plngArray, lngIndexTopPreviousCompleteHeap, lngNodeIndex) > 0)
            {
                SwapItems(plngArray, lngNodeIndex, lngIndexTopPreviousCompleteHeap);
                SmoothTrinkle(plngArray, lngIndexTopPreviousCompleteHeap, lngLeftRightTreeAddress, lngSubTreeSize, lngLeftSubTreeSize);
            }
        }



        // Timsort is used in Java, Python, and Android. This is my attempt at illustrating it. Fails sometimes (try Nearly Sorted). My fault? I can't debug it if I don't understand it.
        // Code from: https://timsort4net.codeplex.com/SourceControl/latest#source/TimSort/TimSort.cs
        /// <summary>Sorts the specified array.</summary>
        /// <param name="array">Array to be sorted.</param>
        /// <param name="lo">the index of the first element in the range to be sorted.</param>
        /// <param name="hi">the index after the last element in the range to be sorted.</param>
        public void Timsort(IList array, int lo, int hi)
        {
            CheckRange(array.Count, lo, hi);

            var width = hi - lo;
            if (width < 2) return; // Arrays of size 0 and 1 are always sorted

            // If array is small, do a "mini-TimSort" with no merges
            if (width < 32) //if (width < MIN_MERGE)
            {
                var initRunLength = CountRunAndMakeAscending(array, lo, hi);
                BinarySort(array, lo, hi, lo + initRunLength);
                return;
            }

            // March over the array once, left to right, finding natural runs,
            // extending short natural runs to minRun elements, and merging runs
            // to maintain stack invariant.
            //var sorter = new Int32ArrayTimSort(array);

            /// <summary>
            /// A stack of pending runs yet to be merged.  Run i starts at
            /// address base[i] and extends for len[i] elements.  It's always
            /// true (so long as the indices are in bounds) that:
            /// <c>runBase[i] + runLen[i] == runBase[i + 1]</c>
            /// so we could cut the storage for this, but it's a minor amount,
            /// and keeping all the info explicit simplifies the code.
            /// </summary>
            int m_StackSize = 0; // Number of pending runs on stack
            int[] m_RunBase;
            int[] m_RunLength;

            int arrayLength = array.Count;

            // Allocate runs-to-be-merged stack (which cannot be expanded).  The
            // stack length requirements are described in listsort.txt.  The C
            // version always uses the same stack length (85), but this was
            // measured to be too expensive when sorting "mid-sized" arrays (e.g.,
            // 100 elements) in Java.  Therefore, we use smaller (but sufficiently
            // large) stack lengths for smaller arrays.  The "magic numbers" in the
            // computation below must be changed if MIN_MERGE is decreased.  See
            // the MIN_MERGE declaration above for more information.
            int stackLength =
                arrayLength < 120 ? 5 :
                arrayLength < 1542 ? 10 :
                arrayLength < 119151 ? 19 :
                40;
            m_RunBase = new int[stackLength];
            m_RunLength = new int[stackLength];

            int MIN_GALLOP = 7;
            int m_MinGallop = MIN_GALLOP;

            int minRun = GetMinimumRunLength(width);
            do
            {
                // Identify next run
                var runLen = CountRunAndMakeAscending(array, lo, hi);

                // If run is short, extend to min(minRun, nRemaining)
                if (runLen < minRun)
                {
                    var force = width <= minRun ? width : minRun;
                    BinarySort(array, lo, lo + force, lo + runLen);
                    runLen = force;
                }

                // Push run onto pending-run stack, and maybe merge
                PushRun(lo, runLen, ref m_RunBase, ref m_RunLength, ref m_StackSize); //PushRun(array, lo, runLen);
                MergeCollapse(array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);

                // Advance to find next run
                lo += runLen;
                width -= runLen;
            } while (width != 0);

            // Merge all remaining runs to complete sort
            //Debug.Assert(lo == hi);
            MergeForceCollapse(array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);
            //Debug.Assert(sorter._stackSize == 1);
        }
        /// <summary>
        /// Checks that fromIndex and toIndex are in range, and throws an
        /// appropriate exception if they aren't.
        /// </summary>
        /// <param name="arrayLen">the length of the array.</param>
        /// <param name="fromIndex">the index of the first element of the range.</param>
        /// <param name="toIndex">the index after the last element of the range.</param>
        private void CheckRange(int arrayLen, int fromIndex, int toIndex)
        {
            if (fromIndex > toIndex)
                throw new ArgumentException(string.Format("fromIndex({0}) > toIndex({1})", fromIndex, toIndex));
            if (fromIndex < 0)
                throw new IndexOutOfRangeException(string.Format("fromIndex ({0}) is out of bounds", fromIndex));
            if (toIndex > arrayLen)
                throw new IndexOutOfRangeException(string.Format("toIndex ({0}) is out of bounds", toIndex));
        }
        /// <summary>
        /// Returns the length of the run beginning at the specified position in
        /// the specified array and reverses the run if it is descending (ensuring
        /// that the run will always be ascending when the method returns).
        /// A run is the longest ascending sequence with: <c><![CDATA[a[lo] <= a[lo + 1] <= a[lo + 2] <= ...]]></c>
        /// or the longest descending sequence with: <c><![CDATA[a[lo] >  a[lo + 1] >  a[lo + 2] >  ...]]></c>
        /// For its intended use in a stable mergesort, the strictness of the
        /// definition of "descending" is needed so that the call can safely
        /// reverse a descending sequence without violating stability.
        /// </summary>
        /// <param name="a">the array in which a run is to be counted and possibly reversed.</param>
        /// <param name="lo">index of the first element in the run.</param>
        /// <param name="hi">index after the last element that may be contained in the run. It is required 
        /// that <c><![CDATA[lo < hi]]></c>.</param>
        /// <param name="c">the comparator to used for the sort.</param>
        /// <returns>the length of the run beginning at the specified position in the specified array</returns>
        private int CountRunAndMakeAscending(IList a, int lo, int hi)
        {
            int runHi = lo + 1;
            if (runHi == hi) return 1;

            // Find end of run, and reverse range if descending
            if (CompareItems(a, runHi, lo) < 0) //if (c(a[runHi++], a[lo]) < 0)
            {
                runHi++;

                // Descending
                while (runHi < hi && CompareItems(a, runHi, runHi - 1) < 0) runHi++; //while (runHi < hi && c(a[runHi], a[runHi - 1]) < 0) runHi++;
                ReverseRange(a, lo, runHi);
            }
            else
            {
                runHi++;

                // Ascending
                while (runHi < hi && CompareItems(a, runHi, runHi - 1) >= 0) runHi++; //while (runHi < hi && c(a[runHi], a[runHi - 1]) >= 0) runHi++;
            }

            return runHi - lo;
        }
        /// <summary>Reverse the specified range of the specified array.</summary>
        /// <param name="array">the array in which a range is to be reversed.</param>
        /// <param name="lo">the index of the first element in the range to be reversed.</param>
        /// <param name="hi">the index after the last element in the range to be reversed.</param>
        private void ReverseRange(IList array, int lo, int hi)
        {
            //Array.Reverse(array, lo, hi - lo);
            for (int i = lo, j = hi - 1; i < j; i++, j--)
            {
                SwapItems(array, i, j);
            }
        }
        /// <summary>
        /// Sorts the specified portion of the specified array using a binary insertion sort. This is the best method for 
        /// sorting small numbers of elements. It requires O(n log n) compares, but O(n^2) data movement (worst case).
        /// If the initial part of the specified range is already sorted, this method can take advantage of it: the method 
        /// assumes that the elements from index <c>lo</c>, inclusive, to <c>start</c>, exclusive are already sorted.
        /// </summary>
        /// <param name="a">the array in which a range is to be sorted.</param>
        /// <param name="lo">the index of the first element in the range to be sorted.</param>
        /// <param name="hi">the index after the last element in the range to be sorted.</param>
        /// <param name="start">start the index of the first element in the range that is not already known to be sorted 
        /// (<c><![CDATA[lo <= start <= hi]]></c>)</param>
        /// <param name="c">The comparator to used for the sort.</param>
        private void BinarySort(IList a, int lo, int hi, int start)
        {
            //Debug.Assert(lo <= start && start <= hi);

            if (start == lo) start++;

            for (/* nothing */; start < hi; start++)
            {
                object pivot = GetItem(a, start);

                // Set left (and right) to the index where a[start] (pivot) belongs
                int left = lo;
                int right = start;
                //Debug.Assert(left <= right);

                /*
                 * Invariants:
                 *   pivot >= all in [lo, left).
                 *   pivot <  all in [right, start).
                 */
                while (left < right)
                {
                    int mid = (left + right) >> 1;
                    if (CompareItems(a, pivot, mid) < 0)//if (c(pivot, a[mid]) < 0)
                    {
                        right = mid;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                //Debug.Assert(left == right);

                // The invariants still hold: pivot >= all in [lo, left) and
                // pivot < all in [left, start), so pivot belongs at left.  Note
                // that if there are elements equal to pivot, left points to the
                // first slot after them -- that's why this sort is stable.
                // Slide elements over to make room to make room for pivot.

                int n = start - left; // The number of elements to move

                // switch is just an optimization for copyRange in default case
                switch (n)
                {
                    case 2:
                        SetItem(a, left + 2, left + 1); //a[left + 2] = a[left + 1];
                        SetItem(a, left + 1, left); //a[left + 1] = a[left];
                        break;
                    case 1:
                        SetItem(a, left + 1, left); //a[left + 1] = a[left];
                        break;
                    case 0:
                        break;
                    default:
                        CopyRange(a, left, a, left + 1, n);
                        break;
                }

                SetItem(a, left, pivot); //a[left] = pivot;
            }
        }
        /// <summary>Copies the range from one array to another.</summary>
        /// <param name="src">The source array.</param>
        /// <param name="srcIndex">Starting index in source array.</param>
        /// <param name="dst">The destination array.</param>
        /// <param name="dstIndex">Starting index in destination array.</param>
        /// <param name="length">Number of elements to be copied.</param>
        private void CopyRange(IList src, int srcIndex, IList dst, int dstIndex, int length)
        {
            //Array.Copy(src, srcIndex, dst, dstIndex, length);

            if (srcIndex < dstIndex) // could just be moving items to the right, so go through backward
            {
                for (int i = length - 1; i >= 0; i--)
                    SetItem(dst, dstIndex + i, src[srcIndex + i]); // purposely not using GetItem here
            }
            else // could just be moving items to the left, so go through forward
            {
                for (int i = 0; i < length; i++)
                    SetItem(dst, dstIndex + i, src[srcIndex + i]); // purposely not using GetItem here
            }
        }
        private void CopyRangeToTemp(IList src, int srcIndex, IList dst, int dstIndex, int length)
        {
            //Array.Copy(src, srcIndex, dst, dstIndex, length);

            for (int i = 0; i < length; i++)
            {
                while (dst.Count < dstIndex + i)
                    dst.Add(0);

                if (dst.Count <= i)
                    dst.Add(GetItem(src, srcIndex + i));
                else
                    dst[dstIndex + i] = GetItem(src, srcIndex + i);
            }
        }
        /// <summary>
        /// Returns the minimum acceptable run length for an array of the specified length. Natural runs shorter than this 
        /// will be extended with binarySort.
        /// Roughly speaking, the computation is:
        /// If <c>n &lt; MIN_MERGE</c>, return n (it's too small to bother with fancy stuff).
        /// Else if n is an exact power of 2, return <c>MIN_MERGE/2</c>.
        /// Else return an int k, <c>MIN_MERGE/2 &lt;= k &lt;= MIN_MERGE</c>, such that <c>n/k</c> is close to, but strictly 
        /// less than, an exact power of 2. For the rationale, see listsort.txt.
        /// </summary>
        /// <param name="n">the length of the array to be sorted.</param>
        /// <returns>the length of the minimum run to be merged.</returns>
        private static int GetMinimumRunLength(int n)
        {
            //Debug.Assert(n >= 0);
            int r = 0; // Becomes 1 if any 1 bits are shifted off
            while (n >= 32) //while (n >= MIN_MERGE)
            {
                r |= (n & 1);
                n >>= 1;
            }
            return n + r;
        }
        /// <summary>
        /// Pushes the specified run onto the pending-run stack.
        /// </summary>
        /// <param name="runBase">index of the first element in the run.</param>
        /// <param name="runLength">the number of elements in the run.</param>
        private void PushRun(int runBase, int runLength, ref int[] m_RunBase, ref int[] m_RunLength, ref int m_StackSize)
        {
            m_RunBase[m_StackSize] = runBase;
            m_RunLength[m_StackSize] = runLength;
            m_StackSize++;
        }
        /// <summary>
        /// Examines the stack of runs waiting to be merged and merges adjacent runs until the stack invariants are
        /// reestablished: 
        /// <c><![CDATA[1. runLen[i - 3] > runLen[i - 2] + runLen[i - 1] ]]></c> and 
        /// <c><![CDATA[2. runLen[i - 2] > runLen[i - 1] ]]></c>
        /// This method is called each time a new run is pushed onto the stack,
        /// so the invariants are guaranteed to hold for i &lt; stackSize upon
        /// entry to the method.
        /// </summary>
        private void MergeCollapse(IList m_Array, ref int[] m_RunBase, ref int[] m_RunLength, ref int m_StackSize, ref int m_MinGallop)
        {
            //while (m_StackSize > 1)
            //{
            //    int n = m_StackSize - 2;

            //    if (n > 0 && m_RunLength[n - 1] <= m_RunLength[n] + m_RunLength[n + 1])
            //    {
            //        if (m_RunLength[n - 1] < m_RunLength[n + 1]) n--;
            //        MergeAt(n, m_Array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);
            //    }
            //    else if (m_RunLength[n] <= m_RunLength[n + 1])
            //    {
            //        MergeAt(n, m_Array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);
            //    }
            //    else
            //    {
            //        break; // Invariant is established
            //    }
            //}

            //Better? http://www.envisage-project.eu/proving-android-java-and-python-sorting-algorithm-is-broken-and-how-to-fix-it/#sec3.4
            while (m_StackSize > 1)
            {
                int n = m_StackSize - 2;
                if ((n >= 1 && m_RunLength[n - 1] <= m_RunLength[n] + m_RunLength[n + 1])
                    || (n >= 2 && m_RunLength[n - 2] <= m_RunLength[n] + m_RunLength[n - 1]))
                {
                    if (m_RunLength[n - 1] < m_RunLength[n + 1])
                        n--;
                }
                else if (m_RunLength[n] > m_RunLength[n + 1])
                {
                    break; // Invariant is established
                }
                MergeAt(n, m_Array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);
            }
        }
        /// <summary>
        /// Merges the two runs at stack indices i and i+1.  Run i must be the penultimate or antepenultimate run on the stack. 
        /// In other words, i must be equal to stackSize-2 or stackSize-3.
        /// </summary>
        /// <param name="runIndex">stack index of the first of the two runs to merge.</param>
        private void MergeAt(int runIndex, IList m_Array, ref int[] m_RunBase, ref int[] m_RunLength, ref int m_StackSize, ref int m_MinGallop)
        {
            //Debug.Assert(m_StackSize >= 2);
            //Debug.Assert(runIndex >= 0);
            //Debug.Assert(runIndex == m_StackSize - 2 || runIndex == m_StackSize - 3);

            int base1 = m_RunBase[runIndex];
            int len1 = m_RunLength[runIndex];
            int base2 = m_RunBase[runIndex + 1];
            int len2 = m_RunLength[runIndex + 1];
            //Debug.Assert(len1 > 0 && len2 > 0);
            //Debug.Assert(base1 + len1 == base2);

            // Record the length of the combined runs; if i is the 3rd-last
            // run now, also slide over the last run (which isn't involved
            // in this merge). The current run (i+1) goes away in any case.
            m_RunLength[runIndex] = len1 + len2;
            if (runIndex == m_StackSize - 3)
            {
                m_RunBase[runIndex + 1] = m_RunBase[runIndex + 2];
                m_RunLength[runIndex + 1] = m_RunLength[runIndex + 2];
            }
            m_StackSize--;

            // Find where the first element of run2 goes in run1. Prior elements
            // in run1 can be ignored (because they're already in place).
            int k = GallopRight(m_Array[base2], m_Array, base1, len1, 0); //int k = GallopRight(m_Array[base2], m_Array, base1, len1, 0, m_Comparer);
            //Debug.Assert(k >= 0);
            base1 += k;
            len1 -= k;
            if (len1 == 0) return;

            // Find where the last element of run1 goes in run2. Subsequent elements
            // in run2 can be ignored (because they're already in place).
            len2 = GallopLeft(m_Array[base1 + len1 - 1], m_Array, base2, len2, len2 - 1);//len2 = GallopLeft(m_Array[base1 + len1 - 1], m_Array, base2, len2, len2 - 1, m_Comparer);
            //Debug.Assert(len2 >= 0);
            if (len2 == 0) return;

            // Merge remaining runs, using tmp array with min(len1, len2) elements
            if (len1 <= len2)
                MergeLo(m_Array, base1, len1, base2, len2, ref m_MinGallop);
            else
                MergeHi(m_Array, base1, len1, base2, len2, ref m_MinGallop);
        }
        /// <summary>
        /// Like gallopLeft, except that if the range contains an element equal to
        /// key, gallopRight returns the index after the rightmost equal element.
        /// </summary>
        /// <param name="key">the key whose insertion point to search for.</param>
        /// <param name="array">the array in which to search.</param>
        /// <param name="lo">the index of the first element in the range.</param>
        /// <param name="length">the length of the range; must be &gt; 0.</param>
        /// <param name="hint">the index at which to begin the search, 0 &lt;= hint &lt; n. The closer hint is to the result, 
        /// the faster this method will run.</param>
        /// <param name="comparer">the comparator used to order the range, and to search.</param>
        /// <returns>int k, that 0 &lt;= k &lt;= n such that a[b + k - 1] &lt;= key &lt; a[b + k]</returns>
        private int GallopRight(object key, IList array, int lo, int length, int hint)
        {
            //Debug.Assert(length > 0 && hint >= 0 && hint < length);

            int ofs = 1;
            int lastOfs = 0;
            if (CompareItems(array, key, lo + hint) < 0) //if (comparer(key, array[lo + hint]) < 0)
            {
                // Gallop left until a[b+hint - ofs] <= key < a[b+hint - lastOfs]
                int maxOfs = hint + 1;
                while (ofs < maxOfs && CompareItems(array, key, lo + hint - ofs) < 0) //while (ofs < maxOfs && comparer(key, array[lo + hint - ofs]) < 0)
                {
                    lastOfs = ofs;
                    ofs = (ofs << 1) + 1;
                    if (ofs <= 0)   // int overflow
                        ofs = maxOfs;
                }
                if (ofs > maxOfs)
                    ofs = maxOfs;

                // Make offsets relative to b
                int tmp = lastOfs;
                lastOfs = hint - ofs;
                ofs = hint - tmp;
            }
            else
            {
                // a[b + hint] <= key
                // Gallop right until a[b+hint + lastOfs] <= key < a[b+hint + ofs]
                int maxOfs = length - hint;
                while (ofs < maxOfs && CompareItems(array, key, lo + hint + ofs) >= 0) //while (ofs < maxOfs && comparer(key, array[lo + hint + ofs]) >= 0)
                {
                    lastOfs = ofs;
                    ofs = (ofs << 1) + 1;
                    if (ofs <= 0)   // int overflow
                        ofs = maxOfs;
                }
                if (ofs > maxOfs)
                    ofs = maxOfs;

                // Make offsets relative to b
                lastOfs += hint;
                ofs += hint;
            }
            //Debug.Assert(-1 <= lastOfs && lastOfs < ofs && ofs <= length);

            // Now a[b + lastOfs] <= key < a[b + ofs], so key belongs somewhere to
            // the right of lastOfs but no farther right than ofs.  Do a binary
            // search, with invariant a[b + lastOfs - 1] <= key < a[b + ofs].
            lastOfs++;
            while (lastOfs < ofs)
            {
                int m = lastOfs + ((ofs - lastOfs) >> 1);

                if (CompareItems(array, key, lo + m) < 0) //if (comparer(key, array[lo + m]) < 0)
                    ofs = m; // key < a[b + m]
                else
                    lastOfs = m + 1; // a[b + m] <= key
            }

            //Debug.Assert(lastOfs == ofs); // so a[b + ofs - 1] <= key < a[b + ofs]
            return ofs;
        }
        /// <summary>
        /// Locates the position at which to insert the specified key into the
        /// specified sorted range; if the range contains an element equal to key,
        /// returns the index of the leftmost equal element.
        /// </summary>
        /// <param name="key">the key whose insertion point to search for.</param>
        /// <param name="array">the array in which to search.</param>
        /// <param name="base">the index of the first element in the range.</param>
        /// <param name="length">the length of the range; must be &gt; 0.</param>
        /// <param name="hint">the index at which to begin the search, 0 &lt;= hint &lt; n. The closer hint is to the result, 
        /// the faster this method will run.</param>
        /// <param name="comparer">the comparator used to order the range, and to search.</param>
        /// <returns>the int k,  0 &lt;= k &lt;= n such that a[b + k - 1] &lt; key &lt;= a[b + k], pretending that a[b - 1] 
        /// is minus infinity and a[b + n] is infinity. In other words, key belongs at index b + k; or in other words, the 
        /// first k elements of a should precede key, and the last n - k should follow it.</returns>
        private int GallopLeft(object key, IList array, int lo, int length, int hint)
        {
            //Debug.Assert(length > 0 && hint >= 0 && hint < length);
            int lastOfs = 0;
            int ofs = 1;

            if (CompareItems(array, key, lo + hint) > 0) //if (comparer(key, array[lo + hint]) > 0)
            {
                // Gallop right until a[base+hint+lastOfs] < key <= a[base+hint+ofs]
                int maxOfs = length - hint;
                while (ofs < maxOfs && CompareItems(array, key, lo + hint + ofs) > 0) //while (ofs < maxOfs && comparer(key, array[lo + hint + ofs]) > 0)
                {
                    lastOfs = ofs;
                    ofs = (ofs << 1) + 1;
                    if (ofs <= 0)   // int overflow
                        ofs = maxOfs;
                }
                if (ofs > maxOfs)
                    ofs = maxOfs;

                // Make offsets relative to base
                lastOfs += hint;
                ofs += hint;
            }
            else // if (key <= a[base + hint])
            {
                // Gallop left until a[base+hint-ofs] < key <= a[base+hint-lastOfs]
                int maxOfs = hint + 1;
                while (ofs < maxOfs && CompareItems(array, key, lo + hint - ofs) <= 0) //while (ofs < maxOfs && comparer(key, array[lo + hint - ofs]) <= 0)
                {
                    lastOfs = ofs;
                    ofs = (ofs << 1) + 1;
                    if (ofs <= 0) // int overflow
                        ofs = maxOfs;
                }
                if (ofs > maxOfs)
                    ofs = maxOfs;

                // Make offsets relative to base
                int tmp = lastOfs;
                lastOfs = hint - ofs;
                ofs = hint - tmp;
            }
            //Debug.Assert(-1 <= lastOfs && lastOfs < ofs && ofs <= length);

            // Now a[base+lastOfs] < key <= a[base+ofs], so key belongs somewhere
            // to the right of lastOfs but no farther right than ofs.  Do a binary
            // search, with invariant a[base + lastOfs - 1] < key <= a[base + ofs].
            lastOfs++;
            while (lastOfs < ofs)
            {
                int m = lastOfs + ((ofs - lastOfs) >> 1);

                if (CompareItems(array, key, lo + m) > 0) //if (comparer(key, array[lo + m]) > 0)
                    lastOfs = m + 1; // a[base + m] < key
                else
                    ofs = m; // key <= a[base + m]
            }
            //Debug.Assert(lastOfs == ofs); // so a[base + ofs - 1] < key <= a[base + ofs]
            return ofs;
        }
        /// <summary>
        /// Merges two adjacent runs in place, in a stable fashion. The first element of the first run must be greater than 
        /// the first element of the second run (a[base1] &gt; a[base2]), and the last element of the first run 
        /// (a[base1 + len1-1]) must be greater than all elements of the second run.
        /// For performance, this method should be called only when len1 &lt;= len2; its twin, mergeHi should be called if 
        /// len1 &gt;= len2. (Either method may be called if len1 == len2.)
        /// </summary>
        /// <param name="base1">index of first element in first run to be merged.</param>
        /// <param name="len1">length of first run to be merged (must be &gt; 0).</param>
        /// <param name="base2">index of first element in second run to be merged (must be aBase + aLen).</param>
        /// <param name="len2">length of second run to be merged (must be &gt; 0).</param>
        private void MergeLo(IList array, int base1, int len1, int base2, int len2, ref int m_MinGallop)
        {
            //Debug.Assert(len1 > 0 && len2 > 0 && base1 + len1 == base2);

            // Copy first run into temp array
            //var array = m_Array; // For performance
            //var mergeBuffer = EnsureCapacity(len1);
            ArrayList mergeBuffer = new ArrayList(len1);
            CopyRangeToTemp(array, base1, mergeBuffer, 0, len1);

            int cursor1 = 0;       // Indexes into tmp array
            int cursor2 = base2;   // Indexes int a
            int dest = base1;      // Indexes int a

            // Move first element of second run and deal with degenerate cases
            SetItem(array, dest, cursor2); dest++; cursor2++; //array[dest++] = array[cursor2++];

            if (--len2 == 0)
            {
                CopyRange(mergeBuffer, cursor1, array, dest, len1);
                return;
            }
            if (len1 == 1)
            {
                CopyRange(array, cursor2, array, dest, len2);
                SetItem(array, dest + len2, mergeBuffer[cursor1]); //array[dest + len2] = mergeBuffer[cursor1]; // Last elt of run 1 to end of merge
                return;
            }

            //var c = m_Comparer;  // Use local variables for performance
            int MIN_GALLOP = 7;
            int minGallop = m_MinGallop;

            while (true)
            {
                int count1 = 0; // Number of times in a row that first run won
                int count2 = 0; // Number of times in a row that second run won

                /*
                 * Do the straightforward thing until (if ever) one run starts
                 * winning consistently.
                 */
                do
                {
                    //Debug.Assert(len1 > 1 && len2 > 0);
                    if (CompareItems(array, cursor2, mergeBuffer[cursor1]) < 0) //if (c(array[cursor2], mergeBuffer[cursor1]) < 0)
                    {
                        SetItem(array, dest, cursor2); dest++; cursor2++; //array[dest++] = array[cursor2++];
                        count2++;
                        count1 = 0;
                        if (--len2 == 0)
                            goto break_outer;
                    }
                    else
                    {
                        SetItem(array, dest, mergeBuffer[cursor1]); dest++; cursor1++; //array[dest++] = mergeBuffer[cursor1++];
                        count1++;
                        count2 = 0;
                        if (--len1 == 1)
                            goto break_outer;
                    }
                } while ((count1 | count2) < minGallop);

                // One run is winning so consistently that galloping may be a
                // huge win. So try that, and continue galloping until (if ever)
                // neither run appears to be winning consistently anymore.
                do
                {
                    //Debug.Assert(len1 > 1 && len2 > 0);
                    count1 = GallopRight(array[cursor2], mergeBuffer, cursor1, len1, 0);
                    if (count1 != 0)
                    {
                        CopyRange(mergeBuffer, cursor1, array, dest, count1);
                        dest += count1;
                        cursor1 += count1;
                        len1 -= count1;
                        if (len1 <= 1) // len1 == 1 || len1 == 0
                            goto break_outer;
                    }
                    SetItem(array, dest, cursor2); dest++; cursor2++; //array[dest++] = array[cursor2++];
                    if (--len2 == 0)
                        goto break_outer;

                    count2 = GallopLeft(mergeBuffer[cursor1], array, cursor2, len2, 0);
                    if (count2 != 0)
                    {
                        CopyRange(array, cursor2, array, dest, count2);
                        dest += count2;
                        cursor2 += count2;
                        len2 -= count2;
                        if (len2 == 0)
                            goto break_outer;
                    }
                    SetItem(array, dest, mergeBuffer[cursor1]); dest++; cursor1++; //array[dest++] = mergeBuffer[cursor1++];
                    if (--len1 == 1)
                        goto break_outer;
                    minGallop--;
                } while (count1 >= MIN_GALLOP | count2 >= MIN_GALLOP);

                if (minGallop < 0)
                    minGallop = 0;
                minGallop += 2;  // Penalize for leaving gallop mode
            }  // End of "outer" loop

            break_outer: // goto me! ;)

            m_MinGallop = minGallop < 1 ? 1 : minGallop;  // Write back to field

            if (len1 == 1)
            {
                //Debug.Assert(len2 > 0);
                CopyRange(array, cursor2, array, dest, len2);
                SetItem(array, dest + len2, mergeBuffer[cursor1]); //array[dest + len2] = mergeBuffer[cursor1]; //  Last elt of run 1 to end of merge
            }
            else if (len1 == 0)
            {
                //throw new ArgumentException("Comparison method violates its general contract!");
            }
            else
            {
                //Debug.Assert(len2 == 0);
                //Debug.Assert(len1 > 1);
                CopyRange(mergeBuffer, cursor1, array, dest, len1);
            }
        }
        /// <summary>
        /// Like mergeLo, except that this method should be called only if
        /// len1 &gt;= len2; mergeLo should be called if len1 &lt;= len2. (Either method may be called if len1 == len2.)
        /// </summary>
        /// <param name="base1">index of first element in first run to be merged.</param>
        /// <param name="len1">length of first run to be merged (must be &gt; 0).</param>
        /// <param name="base2">index of first element in second run to be merged (must be aBase + aLen).</param>
        /// <param name="len2">length of second run to be merged (must be &gt; 0).</param>
        private void MergeHi(IList a, int base1, int len1, int base2, int len2, ref int m_MinGallop)
        {
            //Debug.Assert(len1 > 0 && len2 > 0 && base1 + len1 == base2);

            // Copy second run into temp array
            //var a = m_Array; // For performance
            ArrayList tmp = new ArrayList(len2); //var tmp = EnsureCapacity(len2);
            CopyRangeToTemp(a, base2, tmp, 0, len2);

            int cursor1 = base1 + len1 - 1;  // Indexes into a
            int cursor2 = len2 - 1;          // Indexes into tmp array
            int dest = base2 + len2 - 1;     // Indexes into a

            // Move last element of first run and deal with degenerate cases
            SetItem(a, dest, cursor1); dest--; cursor1--; //a[dest--] = a[cursor1--];
            if (--len1 == 0)
            {
                CopyRange(tmp, 0, a, dest - (len2 - 1), len2);
                return;
            }
            if (len2 == 1)
            {
                dest -= len1;
                cursor1 -= len1;
                CopyRange(a, cursor1 + 1, a, dest + 1, len1);
                SetItem(a, dest, cursor2); //a[dest] = tmp[cursor2];
                return;
            }

            //var c = m_Comparer;  // Use local variables for performance
            int MIN_GALLOP = 7;
            int minGallop = m_MinGallop;

            while (true)
            {
                int count1 = 0; // Number of times in a row that first run won
                int count2 = 0; // Number of times in a row that second run won

                // Do the straightforward thing until (if ever) one run appears to win consistently.
                do
                {
                    //Debug.Assert(len1 > 0 && len2 > 1);
                    if (CompareItems(a, tmp[cursor2], cursor1) < 0) //if (c(tmp[cursor2], a[cursor1]) < 0)
                    {
                        SetItem(a, dest, cursor1); dest--; cursor1--; //a[dest--] = a[cursor1--];
                        count1++;
                        count2 = 0;
                        if (--len1 == 0)
                            goto break_outer;
                    }
                    else
                    {
                        SetItem(a, dest, tmp[cursor2]); dest--; cursor2--; //a[dest--] = tmp[cursor2--];
                        count2++;
                        count1 = 0;
                        if (--len2 == 1)
                            goto break_outer;
                    }
                } while ((count1 | count2) < minGallop);

                // One run is winning so consistently that galloping may be a
                // huge win. So try that, and continue galloping until (if ever)
                // neither run appears to be winning consistently anymore.
                do
                {
                    //Debug.Assert(len1 > 0 && len2 > 1);
                    count1 = len1 - GallopRight(tmp[cursor2], a, base1, len1, len1 - 1);
                    if (count1 != 0)
                    {
                        dest -= count1;
                        cursor1 -= count1;
                        len1 -= count1;
                        CopyRange(a, cursor1 + 1, a, dest + 1, count1);
                        if (len1 == 0)
                            goto break_outer;
                    }
                    SetItem(a, dest, tmp[cursor2]); dest--; cursor2--; // a[dest--] = tmp[cursor2--];
                    if (--len2 == 1)
                        goto break_outer;

                    count2 = len2 - GallopLeft(a[cursor1], tmp, 0, len2, len2 - 1);
                    if (count2 != 0)
                    {
                        dest -= count2;
                        cursor2 -= count2;
                        len2 -= count2;
                        CopyRange(tmp, cursor2 + 1, a, dest + 1, count2);
                        if (len2 <= 1)  // len2 == 1 || len2 == 0
                            goto break_outer;
                    }
                    SetItem(a, dest, cursor1); dest--; cursor1--; //a[dest--] = a[cursor1--];
                    if (--len1 == 0)
                        goto break_outer;
                    minGallop--;
                } while (count1 >= MIN_GALLOP | count2 >= MIN_GALLOP);

                if (minGallop < 0)
                    minGallop = 0;
                minGallop += 2;  // Penalize for leaving gallop mode
            } // End of "outer" loop

            break_outer: // goto me! ;)

            m_MinGallop = minGallop < 1 ? 1 : minGallop;  // Write back to field

            if (len2 == 1)
            {
                //Debug.Assert(len1 > 0);
                dest -= len1;
                cursor1 -= len1;
                CopyRange(a, cursor1 + 1, a, dest + 1, len1);
                SetItem(a, dest, tmp[cursor2]); //a[dest] = tmp[cursor2];  // Move first elt of run2 to front of merge
            }
            else if (len2 == 0)
            {
                //throw new ArgumentException("Comparison method violates its general contract!"); // sometimes get this for "nearly sorted" data
            }
            else
            {
                //Debug.Assert(len1 == 0);
                //Debug.Assert(len2 > 0);
                CopyRange(tmp, 0, a, dest - (len2 - 1), len2);
            }
        }
        /// <summary>
        /// Merges all runs on the stack until only one remains.  This method is called once, to complete the sort.
        /// </summary>
        private void MergeForceCollapse(IList array, ref int[] m_RunBase, ref int[] m_RunLength, ref int m_StackSize, ref int m_MinGallop)
        {
            while (m_StackSize > 1)
            {
                int n = m_StackSize - 2;
                if (n > 0 && m_RunLength[n - 1] < m_RunLength[n + 1]) n--;
                MergeAt(n, array, ref m_RunBase, ref m_RunLength, ref m_StackSize, ref m_MinGallop);
            }
        }


        private object GetItem(IList arrayToSort, int index)
        {
            if (!draw.highlightedIndexes.ContainsKey(index))
                draw.highlightedIndexes.Add(index, false);
            operations_swap++;
            draw.operationCount++;
            draw.checkForFrame();

            return arrayToSort[index];
        }
        private void SetItem(IList arrayToSort, int toIndex, int fromIndex)
        {
            arrayToSort[toIndex] = arrayToSort[fromIndex];

            if (!draw.highlightedIndexes.ContainsKey(toIndex))
                draw.highlightedIndexes.Add(toIndex, false);
            operations_swap++;
            draw.operationCount++;
            draw.checkForFrame();
        }
        private void SetItem(IList arrayToSort, int toIndex, object fromObject)
        {
            arrayToSort[toIndex] = fromObject;

            if (!draw.highlightedIndexes.ContainsKey(toIndex))
                draw.highlightedIndexes.Add(toIndex, false);
            operations_swap++;
            draw.operationCount++;
            draw.checkForFrame();
        }
        private void SetItem(IList arrayToSort, ref object toObject, int fromIndex)
        {
            toObject = arrayToSort[fromIndex];

            if (!draw.highlightedIndexes.ContainsKey(fromIndex))
                draw.highlightedIndexes.Add(fromIndex, false);

            draw.operationCount++;
            draw.checkForFrame();
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

            operations_swap++;
            draw.operationCount += 2;
            draw.checkForFrame();
        }
        private int CompareItems(IList arrayToSort, int index1, int index2)
        {
            if (!draw.highlightedIndexes.ContainsKey(index1))
                draw.highlightedIndexes.Add(index1, false);
            if (!draw.highlightedIndexes.ContainsKey(index2))
                draw.highlightedIndexes.Add(index2, false);
            operations_compare++;
            draw.operationCount++;
            draw.checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }
        private int CompareItems(IList arrayToSort, int index1, object o)
        {
            if (!draw.highlightedIndexes.ContainsKey(index1))
                draw.highlightedIndexes.Add(index1, false);
            operations_compare++;
            draw.operationCount++;
            draw.checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(o);
        }
        private int CompareItems(IList arrayToSort, object o, int index1)
        {
            if (!draw.highlightedIndexes.ContainsKey(index1))
                draw.highlightedIndexes.Add(index1, false);
            operations_compare++;
            draw.operationCount++;
            draw.checkForFrame();

            return ((IComparable)o).CompareTo(arrayToSort[index1]);
        }



    }
}
