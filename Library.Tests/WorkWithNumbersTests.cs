using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestClass]
    public class WorkWithNumbersTests
    {
        [DataRow(9, 9, 0, 0, 9)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(6, 11, 5, 8, 358)]
        [DataTestMethod]
        public void InsertNumber_TwoNumbersAndBitsPositions_ResultNumber(int numberSource, int numberIn, int i, int j, int expectedResult)
        {
            int actualResult = WorkWithNumbers.InsertNumber(numberSource, numberIn, i, j);
            Assert.AreEqual(actualResult, expectedResult, "Failed to insert Number.");
        }

        [DataRow(8, 15, 4, 3)]
        [DataTestMethod]
        public void InsertNumber_WrongParameters_ArgumentException(int numberSource, int numberIn, int i, int j)
        {
            Assert.ThrowsException<ArgumentException>(() => WorkWithNumbers.InsertNumber(numberSource, numberIn, i, j));
        }


        [DataRow(23, 32)]
        [DataRow(8, -1)]
        [DataRow(654321, -1)]
        [DataRow(2017, 2071)]
        [DataRow(1234321, 1241233)]
        [DataTestMethod]
        public void FindNextBiggerNumber_Number_ResultNumber(int number, int expectedResult)
        {
            int actualResult = WorkWithNumbers.FindNextBiggerNumber(number);
            Assert.AreEqual(actualResult, expectedResult, "Failed to find next bigger number that will contain only digits from original number.");
        }

        [DataRow(23, 32)]
        [DataRow(2017, 2071)]
        [DataRow(1234321, 1241233)]
        [DataTestMethod]
        public void FindNextBiggerNumberOutParam_Number_ResultNumberAndTimeSpent(int number, int expectedResult)
        {
            long time;
            int actualResult = WorkWithNumbers.FindNextBiggerNumberOutParam(number, out time);
            Assert.AreEqual(actualResult, expectedResult, "Failed to find next bigger number that will contain only digits from original number.");
            Assert.IsTrue(time > 0, "Failed to get time that was spent on FindNextBiggerNumber method.");
        }

        [DataRow(23, 32)]
        [DataRow(2017, 2071)]
        [DataRow(1234321, 1241233)]
        [DataTestMethod]
        public void FindNextBiggerNumberTuple_Number_ResultNumberAndTimeSpent(int number, int expectedResult)
        {
            var actualResult = WorkWithNumbers.FindNextBiggerNumberTuple(number);
            
            Assert.AreEqual(actualResult.number, expectedResult, "Failed to find next bigger number that will contain only digits from original number.");
            Assert.IsTrue(actualResult.time > 0, "Failed to get time that was spent on FindNextBiggerNumber method.");
        }


        [TestMethod]
        public void FilterDigit_ListOfNumbersAndChoosedDigit_ListOfNumbersWithChoosedDigit()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 , 857};
            var list = new List<int>();

            foreach(int a in array)
            {
                list.Add(a);
            }

            var resultList =  WorkWithNumbers.FilterDigit(list,7);

            CollectionAssert.Contains(resultList, 7);
            CollectionAssert.Contains(resultList, 70);
            CollectionAssert.Contains(resultList, 17);
        }

        //TODO: create a test method FilterDigit that will verify exeptions
    }
}