namespace LinkedListTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void LinkedListAddCommand_AddSomeElements_ShouldReturnAddedElements()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            int[] arr = new int[]{ 5, 8, 10 };
            list.Add(5);
            list.Add(8);
            list.Add(10);

            var expected = string.Join(" ", arr);
            var actual = string.Join(" ", list);

            Assert.AreEqual(expected, actual);
           
        }

        [TestMethod]
        public void LinkedListCountCommand_AddSomeElements_ShouldReturnCorrectCount()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void LinkedListCountCommand_EmptyList_ShouldReturnCorrectCount()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();

            Assert.AreEqual(0, list.Count);

        }

        [TestMethod]
        public void LinkedListCountCommand_AddSomeElementsRemoveOneInTheMiddles_ShouldReturnCorrectCount()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
            list.Remove(1);

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void LinkedListRemoveCommand_AddSomeElementsRemoveAllByOne_ShouldReturnCorrectElement()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
            var actual0 = list.Remove(0);
            var actual1 = list.Remove(0);
            var actual2 = list.Remove(0);

            Assert.AreEqual(5, actual0);
            Assert.AreEqual(8, actual1);
            Assert.AreEqual(10, actual2);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void LinkedListRemoveCommand_AddSomeElementsRemoveLast_ShouldReturnCorrectElement()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
            var actual0 = list.Remove(2);

            Assert.AreEqual(10, actual0);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedListRemoveCommand_EmptyList_ShouldThrowInvalidOperation()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();

            var element = list.Remove(2);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void LinkedListRemoveCommand_AddedSomeElementsIndexSmallerThanZero_ShouldThrowArgumentOutOfRange()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            var element = list.Remove(-1);

        }

        [TestMethod]
        public void LinkedListFirstIndexOf_AddedSomeElementsGetIndexInTheMiddle_ShouldReturnCorrectIndex()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
            list.Add(8);
            list.Add(8);

            int index = list.FirstIndexOf(8);

            Assert.AreEqual(1, index);

        }

        [TestMethod]
        public void LinkedListFirstIndexOf_AddedSomeElementsGetFirstIndex_ShouldReturnCorrectIndex()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            int index = list.FirstIndexOf(5);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void LinkedListFirstIndexOf_AddedSomeElementsGetLastIndex_ShouldReturnCorrectIndex()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            int index = list.FirstIndexOf(10);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void LinkedListFirstIndexOf_AddedSomeElementsNotFound_ShouldReturnMinusOne()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            int index = list.FirstIndexOf(20);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LinkedListFirstIndexOf_AddedOneElement_ShouldReturnCorrectElement()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);

            int index = list.FirstIndexOf(5);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedListFirstIndexOf_EmptyList_ShouldThrowInvalidOperation()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();

            int index = list.FirstIndexOf(20);

        }

        [TestMethod]
        public void LinkedListLastIndexOf_AddedSomeEqualElements_ShouldReturnLastOneThatMatch()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);
            list.Add(8);
            list.Add(8);

            int index = list.LastIndexOf(8);

            Assert.AreEqual(4, index);
        }

        [TestMethod]
        public void LinkedListLastIndexOf_AddedSomeElementsNotFound_ShouldReturnMinusOne()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            int index = list.LastIndexOf(20);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedListLastIndexOf_EmptyList_ShouldThrowInvalidOperation()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();

            int index = list.LastIndexOf(20);

        }

        [TestMethod]
        public void LinkedListLastIndexOf_AddedSomeDifferentElements_ShouldReturnLastOneThatMatch()
        {
            var list = new ImplementationOfLinkedList.LinkedList<int>();
            list.Add(5);
            list.Add(8);
            list.Add(10);

            int index = list.LastIndexOf(8);

            Assert.AreEqual(1, index);
        }

    }
}