using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void FindNextBiggerNumber_TwoNumbersAndBitsPositions_ResultNumber(int number, int expectedResult)
        {
            int actualResult = WorkWithNumbers.FindNextBiggerNumber(number);
            Assert.AreEqual(actualResult, expectedResult, "Failed to find next bigger number that will contain only digits from original number.");
        }
    }
}