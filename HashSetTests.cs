using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantsLibrary;

namespace PlantsLibrary.Tests
{
    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void AddNewPlantShouldIncreaseCount()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);
            var plant = new Plant { Id = new IdNumber(1) };

            // Act
            bool result = hashSet.Add(plant);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, hashSet.Count);
        }

        [TestMethod]
        public void AddDuplicatePlantShouldNotAdd()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);
            var plant = new Plant { Id = new IdNumber(1) };
            hashSet.Add(plant);

            // Act
            bool result = hashSet.Add(plant);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual(1, hashSet.Count);
        }

        [TestMethod]
        public void RemoveExistingPlantShouldDecreaseCount()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);
            var plant = new Plant { Id = new IdNumber(1) };
            hashSet.Add(plant);

            // Act
            bool result = hashSet.Remove(1);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, hashSet.Count);
        }

        [TestMethod]
        public void RemoveNonExistentPlantShouldReturnFalse()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);

            // Act
            bool result = hashSet.Remove(999);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FindExistingPlantShouldReturnPlant()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);
            var plant = new Plant { Id = new IdNumber(1) };
            hashSet.Add(plant);

            // Act
            var foundPlant = hashSet.Find(1);

            // Assert
            Assert.IsNotNull(foundPlant);
            Assert.AreEqual(1, foundPlant.Id.Number);
        }

        [TestMethod]
        public void FindNonExistentPlantShouldReturnNull()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(10, 0.72);

            // Act
            var foundPlant = hashSet.Find(999);

            // Assert
            Assert.IsNull(foundPlant);
        }

        [TestMethod]
        public void ResizeWhenLoadFactorExceededShouldIncreaseCapacity()
        {
            // Arrange
            var hashSet = new HashSet<Plant>(3, 0.5); // Маленький размер для теста
            var plant1 = new Plant { Id = new IdNumber(1) };
            var plant2 = new Plant { Id = new IdNumber(2) };
            var plant3 = new Plant { Id = new IdNumber(3) };

            // Act
            hashSet.Add(plant1);
            hashSet.Add(plant2);
            int initialCapacity = hashSet.Capacity;
            hashSet.Add(plant3); // Должен вызвать Resize()

            // Assert
            Assert.IsTrue(hashSet.Capacity > initialCapacity);
            Assert.AreEqual(3, hashSet.Count);
        }
    }
}