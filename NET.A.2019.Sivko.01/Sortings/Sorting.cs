namespace Sortings
{
    public class Sorting
    {
        public static void QuickSort(int[] A, int first, int last)
        {
            if (first >= last)
                return;
            int middle = Transposition(A, first, last);
            //sort the left part of the array
            QuickSort(A, first, middle - 1);
            //sort the right part of the array
            QuickSort(A, middle + 1, last);
        }

        private static int Transposition(int[] array, int start, int end)
        {
            //divides left and right subarrays
            int marker = start;
            //to view the entire array
            for (int i = start; i <= end; i++)
            {
                //array[end] is pivot
                if (array[i] <= array[end])
                {
                    //swap
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            return marker - 1;
        }

        //sorts and joins an array
        private static int[] Merge(int[] left, int[] right)
        {
            //sorted array
            int[] buff = new int[left.Length + right.Length];
            //three array length counters
            int i = 0, l = 0, r = 0;
            //sorting by item comparison
            for (; i < buff.Length; i++)
            {
                //check for right array out of bounds
                if (r >= right.Length)
                {
                    buff[i] = left[l];
                    l++;
                }
                else if (l < left.Length && left[l] < right[r]) //check to go beyond the left array and compare the current values of both arrays
                {
                    buff[i] = left[l];
                    l++;
                }
                else //if the current value of the right side is greater
                {
                    buff[i] = right[r];
                    r++;
                }
            }
            return buff;
        }

        //divides array into subarrays
        public static int[] MergeSort(int[] array)
        {
            //check the length of the array
            //if it is equal to 1, then the array does not need to be sorted
            if (array.Length > 1)
            {
                //arrays for storing the halves of the incoming array
                int[] left = new int[array.Length / 2];
                int[] right = new int[array.Length - left.Length];

                //fill submassive
                for (int i = 0; i < left.Length; i++)
                    left[i] = array[i];
                for (int i = 0; i < right.Length; i++)
                    right[i] = array[left.Length + i];

                //if the length of the subarrays is greater than 1
                //we call the this function again(recursively)
                if (left.Length > 1)
                    left = MergeSort(left);
                if (right.Length > 1)
                    right = MergeSort(right);

                array = Merge(left, right);
            }

            return array;
        }
    }
}
