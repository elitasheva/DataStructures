namespace LinkedStackTest
{
    using System;
    using LinkedStackImplementation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void LinkedStackTests_NoElements_ShouldReturnCorrectCount()
        {
            LinkedStack<int> numbers = new LinkedStack<int>();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void LinkedStackTests_PushSomeElements_ShouldReturnCorrectCount()
        {
            LinkedStack<int> numbers = new LinkedStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            Assert.AreEqual(2, numbers.Count);
        }

        [TestMethod]
        public void LinkedStackTests_PushSomeElementsPopOne_ShouldReturnCorrectCount()
        {
            LinkedStack<int> numbers = new LinkedStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            numbers.Pop();
            Assert.AreEqual(1, numbers.Count);
        }

        [TestMethod]
        public void LinkedStackTests_PushSomeElementsPopOne_ShouldReturnCorrectElement()
        {
            LinkedStack<int> numbers = new LinkedStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            var element = numbers.Pop();
            Assert.AreEqual(10, element);
        }

        [TestMethod]
        public void LinkedStackTests_PushThousandElements_ShouldReturnCorrectCount()
        {
            LinkedStack<string> numbers = new LinkedStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Push(i.ToString());
                Assert.AreEqual(i + 1, numbers.Count);
            }
        }

        [TestMethod]
        public void LinkedStackTests_PushThousandElementsPopAll_ShouldReturnCorrectElement()
        {
            LinkedStack<string> numbers = new LinkedStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Push(i.ToString());
            }

            for (int i = 999; i >= 0; i--)
            {
                var element = numbers.Pop();
                Assert.AreEqual(i.ToString(), element);
                Assert.AreEqual(i, numbers.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedStackTests_PopFromEmptyStack_ShouldThrowInvalidOperationException()
        {
            LinkedStack<string> numbers = new LinkedStack<string>();
            numbers.Pop();
        }

        [TestMethod]
        public void LinkedStackTests_PushSomeElements_ShouldReturnCorrectArray()
        {
            LinkedStack<int> numbers = new LinkedStack<int>();
            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(-2);
            numbers.Push(7);

            var expected = new int[] { 7, -2, 5, 3 };
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinkedStackTests_EmptyStack_ShouldReturnEmptyArray()
        {
            LinkedStack<DateTime> numbers = new LinkedStack<DateTime>();

            var expected = new DateTime[] { };
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
