namespace OrderedSetWithAVLTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OrderedSetWithAVL;

    [TestClass]
    public class OrderedSetWithAVLTests
    {
        [TestMethod]
        public void Add_EmptyOrdered_ShouldAddElement()
        {
            //Arrange
            var set = new OrderedSetWithAVL<int>();

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
        public void Count_AddSomeElements_ShouldReturnCorrectCount()
        {
            //Arrange
            var set = new OrderedSetWithAVL<int>();

            //Assert
            Assert.AreEqual(0, set.Count);

            //Act & Assert
            set.Add(5);
            set.Add(3);
            set.Add(10);
            Assert.AreEqual(3, set.Count);
        }

        [TestMethod]
        public void Count_AddDuplicates_ShouldReturnCorrectCount()
        {
            //Arrange
            var set = new OrderedSetWithAVL<int>();

            //Assert
            Assert.AreEqual(0, set.Count);

            //Act & Assert
            set.Add(5);
            set.Add(3);
            set.Add(5);
            Assert.AreEqual(2, set.Count);
        }

        [TestMethod]
        public void Contains_ExistingElement_ShouldReturnTrue()
        {
            //Arrange
            var set = new OrderedSetWithAVL<int>();
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
            var set = new OrderedSetWithAVL<int>();
            set.Add(5);
            set.Add(10);

            //Act
            var contains = set.Contains(20);

            //Assert
            Assert.IsFalse(contains);
        }

        [TestMethod]
        public void EmptyOrderedSet_ShouldReturnEmptyCollection()
        {
            //Arrange
            var set = new OrderedSetWithAVL<int>();

            //Act
            var actualElements = set.ToList();
            var expected = new int[] { };

            //Assert
            CollectionAssert.AreEquivalent(expected, actualElements);
        }
    }
}
