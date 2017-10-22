using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class WorkWithNumbers
    {

        /// <summary>
        /// InsertNumber method will place part (from i to j, i less than j) of bits from one number to another.
        /// </summary>
        /// <param name="numberSource">First number</param>
        /// <param name="numberIn">Second number</param>
        /// <param name="i">First bit position</param>
        /// <param name="j">Second bit position</param>
        /// <returns>Inserted number</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
                throw new ArgumentException("Wrong bits positions. i should be less than j");

            byte[] firstByteArray = BitConverter.GetBytes(numberSource);
            BitArray firstBitArray = new BitArray(firstByteArray);

            byte[] secondByteArray = BitConverter.GetBytes(numberIn);
            BitArray secondBitArray = new BitArray(secondByteArray);

            bool[] firstArray = new bool[32];
            bool[] secondArray = new bool[32];

            firstBitArray.CopyTo(firstArray, 0);
            secondBitArray.CopyTo(secondArray, 0);

            Array.Copy(secondArray, 0, firstArray, i, j - i + 1);

            BitArray resultArray = new BitArray(firstArray);

            if (resultArray.Length > 32)
                throw new ArgumentException("Argument length should be no more than 32 bits.");

            int[] array = new int[1];
            resultArray.CopyTo(array, 0);

            return array[0];

        }

        /// <summary>
        /// FindNextBiggerNumber method will find next bigger number that will contan only digits from original number.
        /// </summary>
        /// <param name="number">Original number</param>
        /// <returns>Next bigger number</returns>
        public static int FindNextBiggerNumber(int number)
        {
            int result = 0;
            var digits = new List<int>();

            //Create from int digits array 
            for (; number != 0; number /= 10)
                digits.Add(number % 10);

            var array = digits.ToArray();
            Array.Reverse(array);

            // Starting from the end trying to find a digit that will be smaller then the digit next to it
            int i = array.Length - 1;
            while (i > 0)
            {
                if (array[i] > array[i - 1])
                      break;
                i--;
            }

            // If there are no such digit return -1
            if (i == 0)
                return -1;
            else
            {
                int x = array[i - 1];
                int min = i;

                // Find the smollest digit on the right side that wiil be greate that choosed one 
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > x && array[j] < array[min])
                        min = j;
                }

                // Swap found digits
                Swap(array, i - 1, min);

                //Sort the right side from first choosed digit
                Array.Sort(array, i, array.Length - i);
            }
            //Convert int array to int
            for (int k = 0; k < array.Length; k++)
            {
                result += array[k] * Convert.ToInt32(Math.Pow(10, array.Length - k - 1));
            }
            return result;
        }
        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
