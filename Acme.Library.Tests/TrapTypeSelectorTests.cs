using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Library.Tests
{
    [TestClass]
    public class TrapTypeSelectorTests
    {
        [TestMethod]
        public void TypeSelector_ReturnsType_IfSeedValid()
        {
            //Arrange
            var validSeed = 0;
            var sut = new TrapTypeSelector();

            //Act
            var result = sut.Select(validSeed);

            //Assert
            Assert.AreEqual(result, TrapType.Anvil);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TypeSelector_ThrowsException_IfSeedInvalid()
        {
            //Arrange
            var invalidSeed = 42;
            var sut = new TrapTypeSelector();

            //Act
            var resut = sut.Select(invalidSeed);

            //Assert
            //Uh-oh spaghetti-ohs - nothing to assert!
        }
    }
}