using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06.ReversedListTests
{
    using ImplementationOfReversedList;
    
    [TestClass]
    public class ReversedListTests
    {
        [TestMethod]
        public void ReversedListAddCommand_AddSomeElements_ShouldReturnCorrectCount()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);

            Assert.AreEqual(4, reversedList.Count);
        }

        [TestMethod]
        public void ReversedListAddCommand_AddSomeElements_ShouldReturnInCorrectOrder()
        {
            var reversedList = new ReversedList<int>();
            int[] array = new[] { 50, 20, 10, 5 };
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);

            var expected = string.Join(" ", array);
            var actual = string.Join(" ", reversedList);
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReversedListCountCommand_EmptyList_ShouldReturnCorrectCount()
        {
            var reversedList = new ReversedList<int>();

            Assert.AreEqual(0, reversedList.Count);
        }

        [TestMethod]
        public void ReversedListCountCommand_AddSomeElementsAndDeleteOne_ShouldReturnCorrectCount()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            reversedList.Remove(2);

            Assert.AreEqual(3, reversedList.Count);
        }


        [TestMethod]
        public void ReversedListRemoveCommand_AddSomeElementsAndDeleteOne_ShouldReturnCorrectElement()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            var element = reversedList.Remove(2);

            Assert.AreEqual(10, element);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReversedListRemoveCommand_IndexSmallerThanZero_ShouldThrowArgumentOutOfRange()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            var element = reversedList.Remove(-1);


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReversedListRemoveCommand_IndexBiggerThanCount_ShouldThrowArgumentOutOfRange()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            var element = reversedList.Remove(10);


        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReversedListRemoveCommand_EmptyList_ShouldThrowInvalidOperation()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Remove(1);
        }

        [TestMethod]
        public void ReversedListRemoveCommand_AddSomeElementsAndDeleteOne_ShouldReturnInCorrectOrder()
        {
            var reversedList = new ReversedList<int>();
            int[] array = new[] { 50, 20, 5 };
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            reversedList.Remove(2);

            var expected = string.Join(" ", array);
            var actual = string.Join(" ", reversedList);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReversedListCapacityCommand_EmptyList_ShouldReturnDefaultCapacity()
        {
            var reversedList = new ReversedList<int>();

            Assert.AreEqual(8, reversedList.Capacity);
        }

        [TestMethod]
        public void ReversedListCapacityCommand_AddMoreElementsThanCapacity_ShouldReturnCorrectCapacity()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);
            reversedList.Add(50);

            Assert.AreEqual(16, reversedList.Capacity);
        }

        [TestMethod]
        public void ReversedListByIndexCommand_AddSomeElements_ShouldReturnTheCorrectElement()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(20);
            reversedList.Add(50);

            var actual0 = reversedList[0];
            var actual1 = reversedList[1];
            var actual2 = reversedList[2];
            var actual3 = reversedList[3];

            Assert.AreEqual(50, actual0);
            Assert.AreEqual(20, actual1);
            Assert.AreEqual(10, actual2);
            Assert.AreEqual(5, actual3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReversedListbyIndex_EmptyList_ShouldThrowInvalidOperation()
        {
            var reversedList = new ReversedList<int>();

            var element = reversedList[1];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReversedListbyIndex_IndexBiggerThanCount_ShouldThrowArgumentOutOfRange()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);

            var element = reversedList[5];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReversedListbyIndex_IndexSmallerThanZero_ShouldThrowArgumentOutOfRange()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);

            var element = reversedList[-1];
        }
    }
}
