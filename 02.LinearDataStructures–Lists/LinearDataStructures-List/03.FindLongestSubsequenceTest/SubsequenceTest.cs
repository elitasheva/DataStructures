namespace _03.FindLongestSubsequenceTest
{
    using System.Collections.Generic;
    using LongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SubsequenceTest
    {
        [TestMethod]
        public void SequenceTest_WithTwoEqualElements_ShouldReturnListWithTwoElements()
        {
            List<int> array = new List<int>{12, 2, 7, 4, 3, 3, 8};

            var result = MainClass.FindLongestSubsequenceOfEqualNumbers(array);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(3, result[0]);
        }
           
        [TestMethod]
        public void SequenceTest_WithTwoSubsequenceEqualLength_ShouldReturnTheLeftmost()
        {
            List<int> array = new List<int> { 2, 2, 2, 3, 3, 3 };

            var result = MainClass.FindLongestSubsequenceOfEqualNumbers(array);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(2, result[0]);
        }

        [TestMethod]
        public void SequenceTest_WithSubsequenceOfOneElement_ShouldReturnTheLeftmost()
        {
            List<int> array = new List<int> { 1, 2, 3 };

            var result = MainClass.FindLongestSubsequenceOfEqualNumbers(array);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void SequenceTest_WithOnlyOneElement_ShouldReturnTheElement()
        {
            List<int> array = new List<int> { 0 };

            var result = MainClass.FindLongestSubsequenceOfEqualNumbers(array);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(0, result[0]);
        }

        [TestMethod]
        public void SequenceTest_WithSubsequenceAtTheEndOfTheSequence_ShouldReturnTheCorrectSubsequence()
        {
            List<int> array = new List<int> { 4, 4, 5, 5, 5 };

            var result = MainClass.FindLongestSubsequenceOfEqualNumbers(array);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(5, result[0]);
        }
    }
}
