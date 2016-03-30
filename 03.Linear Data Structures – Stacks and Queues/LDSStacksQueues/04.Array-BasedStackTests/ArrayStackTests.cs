namespace Array_BasedStackTests
{
    using System;
    using Array_BasedStack;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void ArrayStackTests_NoElements_ShouldReturnCorrectCount()
        {
            ArrayStack<int> numbers = new ArrayStack<int>();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void ArrayStackTests_PushSomeElements_ShouldReturnCorrectCount()
        {
            ArrayStack<int> numbers = new ArrayStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            Assert.AreEqual(2, numbers.Count);
        }

        [TestMethod]
        public void ArrayStackTests_PushSomeElementsPopOne_ShouldReturnCorrectCount()
        {
            ArrayStack<int> numbers = new ArrayStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            numbers.Pop();
            Assert.AreEqual(1, numbers.Count);
        }

        [TestMethod]
        public void ArrayStackTests_PushSomeElementsPopOne_ShouldReturnCorrectElement()
        {
            ArrayStack<int> numbers = new ArrayStack<int>();
            numbers.Push(5);
            numbers.Push(10);
            var element = numbers.Pop();
            Assert.AreEqual(10, element);
        }

        [TestMethod]
        public void ArrayStackTests_PushThousandElements_ShouldReturnCorrectCount()
        {
            ArrayStack<string> numbers = new ArrayStack<string>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Push(i.ToString());
                Assert.AreEqual(i + 1, numbers.Count);
            }

        }

        [TestMethod]
        public void ArrayStackTests_PushThousandElementsPopAll_ShouldReturnCorrectElement()
        {
            ArrayStack<string> numbers = new ArrayStack<string>();

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
        public void ArrayStackTests_PopFromEmptyStack_ShouldThrowInvalidOperationException()
        {
            ArrayStack<string> numbers = new ArrayStack<string>();
            numbers.Pop();
        }

        [TestMethod]
        public void ArrayStackTests_InitialCapacityOne_ShouldReturnCorrectCount()
        {
            ArrayStack<int> numbers = new ArrayStack<int>(1);
            Assert.AreEqual(0, numbers.Count);

            numbers.Push(5);
            Assert.AreEqual(1, numbers.Count);

            numbers.Push(10);
            Assert.AreEqual(2, numbers.Count);

            var element1 = numbers.Pop();
            Assert.AreEqual(10, element1);
            Assert.AreEqual(1, numbers.Count);

            var element2 = numbers.Pop();
            Assert.AreEqual(5, element2);
            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void ArrayStackTests_PushSomeElements_ShouldReturnCorrectArray()
        {
            ArrayStack<int> numbers = new ArrayStack<int>();
            numbers.Push(3);
            numbers.Push(5);
            numbers.Push(-2);
            numbers.Push(7);

            var expected = new int[] { 7, -2, 5, 3 };
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArrayStackTests_EmptyStack_ShouldReturnEmptyArray()
        {
            ArrayStack<DateTime> numbers = new ArrayStack<DateTime>(3);
           
            var expected = new DateTime[] {};
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
