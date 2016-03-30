namespace LinkedQueueTest
{
    using System;
    using LinkedQueue;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void LinkedQueueTests_NoElements_ShouldReturnCorrectCount()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();

            Assert.AreEqual(0, numbers.Count);
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueSomeElements_ShouldReturnCorrectCount()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(5);
            numbers.Enqueue(10);
            Assert.AreEqual(2, numbers.Count);
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueSomeElementsDequeueOne_ShouldReturnCorrectCount()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(5);
            numbers.Enqueue(10);
            numbers.Dequeue();
            Assert.AreEqual(1, numbers.Count);
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueSomeElementsDequeueElements_ShouldReturnCorrectElement()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(5);
            numbers.Enqueue(10);
            var element1 = numbers.Dequeue();
            var element2 = numbers.Dequeue();
            Assert.AreEqual(5, element1);
            Assert.AreEqual(10,element2);
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueThousandElements_ShouldReturnCorrectCount()
        {
            LinkedQueue<string> numbers = new LinkedQueue<string>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Enqueue(i.ToString());
                Assert.AreEqual(i + 1, numbers.Count);
            }
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueThousandElementsDequeueAll_ShouldReturnCorrectElement()
        {
            LinkedQueue<string> numbers = new LinkedQueue<string>();

            for (int i = 0; i < 1000; i++)
            {
                numbers.Enqueue(i.ToString());
            }

            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(1000-i, numbers.Count);

                var element = numbers.Dequeue();
                Assert.AreEqual(i.ToString(), element);
                
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedQueueTests_DequeueFromEmptyQueue_ShouldThrowInvalidOperationException()
        {
            LinkedQueue<string> numbers = new LinkedQueue<string>();
            numbers.Dequeue();
        }

        [TestMethod]
        public void LinkedQueueTests_EnqueueSomeElements_ShouldReturnCorrectArray()
        {
            LinkedQueue<int> numbers = new LinkedQueue<int>();
            numbers.Enqueue(3);
            numbers.Enqueue(5);
            numbers.Enqueue(-2);
            numbers.Enqueue(7);

            var expected = new int[] { 3, 5, -2, 7 };
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LinkedQueueTests_EmptyQueue_ShouldReturnEmptyArray()
        {
            LinkedQueue<DateTime> numbers = new LinkedQueue<DateTime>();

            var expected = new DateTime[] { };
            var actual = numbers.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
