using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderedSet;

namespace OrderedSetTests
{
    using System.Linq;

    [TestClass]
    public class OrderedSetTests
    {
        [TestMethod]
        public void Add_EmptyOrdered_ShouldAddElement()
        {
            //Arrange
            var set = new OrderedSet<int>();

            //Act
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(3);

            //Assert
            var actualElements = set.ToList();
            var expected = new int[] { 3, 6, 9, 12, 17, 19, 25 };
            CollectionAssert.AreEquivalent(expected, actualElements);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_EmptyOrderedSet_Duplicates_ShouldThrowException()
        {
            //Arrange
            var set = new OrderedSet<int>();

            //Act
            set.Add(5);
            set.Add(3);
            set.Add(5);
        }

        [TestMethod]
        public void Count_Empty_Add_Remove_ShouldWorkCorrectly()
        {
            //Arrange
            var set = new OrderedSet<int>();

            //Assert
            Assert.AreEqual(0, set.Count);

            //Act & Assert
            set.Add(5);
            set.Add(3);
            set.Add(10);
            Assert.AreEqual(3, set.Count);

            //Act & Assert
            set.Remove(10);
            Assert.AreEqual(2, set.Count);

            //Act & Assert
            set.Remove(3);
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            //Arrange
            var set = new OrderedSet<int>();
            set.Add(5);
            set.Add(10);

            //Act
            var contains = set.Contains(5);

            //Assert
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Contains_NonExistingElement_ShouldReturnFalse()
        {
            //Arrange
            var set = new OrderedSet<int>();
            set.Add(5);
            set.Add(10);

            //Act
            var contains = set.Contains(20);

            //Assert
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void Remove_ExistingElement_ShouldWorkCorrectly()
        {
            //Arrange
            var set = new OrderedSet<int>();

            //Act
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(19);
            set.Add(6);
            set.Add(25);
            set.Add(3);
            set.Remove(3);

            //Assert
            var actualElements = set.ToList();
            var expected = new int[] { 6, 9, 12, 17, 19, 25 };
            CollectionAssert.AreEquivalent(expected, actualElements);
        }

        [TestMethod]
        public void Remove_NonExistingElement_ShouldWorkCorrectly()
        {
            //Arrange
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);

            //Assert
            Assert.AreEqual(2, set.Count);

            //Act
            set.Remove(20);

            //Assert
            Assert.AreEqual(2, set.Count);
        }

        [TestMethod]
        public void EmptyOrderedSet_ShouldReturnEmptyCollection()
        {
            //Arrange
            var set = new OrderedSet<int>();

            //Act
            var actualElements = set.ToList();
            var expected = new int[] { };

            //Assert
            CollectionAssert.AreEquivalent(expected, actualElements);
        }
    }
}
