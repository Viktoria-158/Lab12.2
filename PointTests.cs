using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsLibrary;

namespace PlantsLibrary.Tests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void ConstructorWithDataShouldSetData()
        {
            // Arrange
            var plant = new Plant { Id = new IdNumber(1) };

            // Act
            var point = new Point<Plant>(plant);

            // Assert
            Assert.AreEqual(plant, point.Data);
            Assert.IsFalse(point.IsDeleted);
        }

        [TestMethod]
        public void ToStringWithDataShouldReturnDataString()
        {
            // Arrange
            var plant = new Plant { Id = new IdNumber(1) };
            var point = new Point<Plant>(plant);

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual(plant.ToString(), result);
        }

        [TestMethod]
        public void ToStringNullDataShouldReturnNullString()
        {
            // Arrange
            var point = new Point<Plant>();

            // Act
            string result = point.ToString();

            // Assert
            Assert.AreEqual("null", result);
        }

        [TestMethod]
        public void GetHashCodeWithDataShouldReturnHashOfData()
        {
            // Arrange
            var plant = new Plant { Id = new IdNumber(1) };
            var point = new Point<Plant>(plant);

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(plant.GetHashCode(), hashCode);
        }

        [TestMethod]
        public void GetHashCodeNullDataShouldReturnZero()
        {
            // Arrange
            var point = new Point<Plant>();

            // Act
            int hashCode = point.GetHashCode();

            // Assert
            Assert.AreEqual(0, hashCode);
        }
    }
}