using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class WorkWithNumbers
    {

        /// <summary>
        /// InsertNumber method place part (from i to j, i less than j) of bits from one number to another.
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


        #region FindNextBiggerNumber

        /// <summary>
        /// FindNextBiggerNumber method find next bigger number that will contan only digits from original number.
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
                Swap(ref array[i - 1], ref array[min]);

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

        /// <summary>
        /// FindNextBiggerNumberOutParam method find out the time that FindNextBiggerNumber spent
        /// </summary>
        /// <param name="number">Original number</param>
        /// <param name="time">Out parameter that will contain ticks count</param>
        /// <returns>Next bigger number</returns>
        public static int FindNextBiggerNumberOutParam(int number, out long time)
        {
           
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            int result = FindNextBiggerNumber(number);
            stopWatch.Stop();

            time = stopWatch.ElapsedTicks;

            return result;

        }

        /// <summary>
        /// FindNextBiggerNumberTuple method find out the time that FindNextBiggerNumber spent
        /// </summary>
        /// <param name="number">Original number</param>
        /// <returns>Tuple that contain next bigger number and ticks count</returns>
        public static (int number, long time) FindNextBiggerNumberTuple(int number)
        {

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            int result = FindNextBiggerNumber(number);
            stopWatch.Stop();

            long time = stopWatch.ElapsedTicks;

            return (result,time);

        }

        #endregion


        /// <summary>
        /// FilterDigit method find the numbers from the list that contain choosed digit
        /// </summary>
        /// <param name="list">List of numbers for verification</param>
        /// <param name="digit">Choosed digit</param>
        /// <returns>List of numbers that contain choosed digit</returns>
        public static List<int> FilterDigit(List<int> list, int digit)
        {
            var resultList = new List<int>();

            if ((digit / 10) >= 1)
                throw new ArgumentException("Wrong format of input parameter 'digit'.");

            if(list.Count == 0)
                throw new ArgumentException("Wrong format of input parameter 'list'.");


            foreach (int number in list)
            {
                if ((number / 10) >= 1)
                {
                    char[] digits = number.ToString().ToCharArray();
                    
                    foreach (char ch in digits)
                    {
                        
                        if ((int)Char.GetNumericValue(ch) == digit)
                        {
                            resultList.Add(number);
                            break;
                        }
                    }
                }
                else
                {
                    if(number == digit)
                    {
                        resultList.Add(number);
                        continue;
                    }
                }
            }

            return resultList;
        }



        #region Privat

        private static void Swap(ref int i,ref int j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

        #endregion

    }
}
