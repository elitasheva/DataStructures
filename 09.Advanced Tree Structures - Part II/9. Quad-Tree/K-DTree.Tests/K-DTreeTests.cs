namespace K_DTree.Tests
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class K_DTreeTests
    {
        [TestMethod]
        public void InsertSevenStars_ShouldReturnTheInsertedStarsOrderedByXCoordinate()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            int count = 0;
            foreach (var star in tree)
            {
                Assert.AreEqual(star.Name, stars[count].Name);
                count++;
            }
        }

        [TestMethod]
        public void InsertSevenStars_ShouldReturnCorrectCount()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            Assert.AreEqual(tree.Count, stars.Count);
        }

        [TestMethod]
        public void Range1_InsertedSevenStars_ShouldReturnStarsInRange()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            var expectedStars = new List<Star>()
            {
                new Star("Local_Cluster", 8, 16),
                new Star("Krogan_DMZ", 6, 15)
            };

            var actualStars = tree.Range(6.3, 16.5, 2);

            int count = 0;
            foreach (Star star in actualStars)
            {
                Assert.AreEqual(expectedStars[count].Name, star.Name);
                count++;
            }
        }

        [TestMethod]
        public void Range2_InsertedSevenStars_ShouldReturnStarsInRange()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            var expectedStars = new List<Star>()
            {
                new Star("Hades_Gamma", 19, 13),
                new Star("Artemis_Tau", 15.4, 17)
            };

            var actualStars = tree.Range(17.5, 15, 3);

            int count = 0;
            foreach (Star star in actualStars)
            {
                Assert.AreEqual(expectedStars[count].Name, star.Name);
                count++;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RangeInvalidRange_InsertedSevenStars_ShouldThrowInvalidOperationException()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            tree.Range(17.5, 15, 0);

        }

        [TestMethod]
        public void Range3_InsertedSevenStars_ShouldReturnStarsInRange()
        {
            List<Star> stars = new List<Star>
            {
                new Star("Crescent_Nebula", 5.5, 5),
                new Star("Krogan_DMZ", 6, 15),
                new Star("Local_Cluster", 8, 16),
                new Star("Nqkoq si", 9, 8),
                new Star("Exodus_Cluster", 12, 13.5),
                new Star("Kepler_Verge", 15, 8),
                new Star("Artemis_Tau", 15.4, 17),
                new Star("Hades_Gamma", 19, 13)
            };

            K_DTree<Star> tree = new K_DTree<Star>(stars);

            var expectedStars = new List<Star>()
            {
                new Star("Nqkoq si", 9, 8),
                new Star("Kepler_Verge", 15, 8)
            };

            var actualStars = tree.Range(12, 8, 3.5);

            int count = 0;
            foreach (Star star in actualStars)
            {
                Assert.AreEqual(expectedStars[count].Name, star.Name);
                count++;
            }
        }
    }
}




