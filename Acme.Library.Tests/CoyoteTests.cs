using System;
using Acme.Library.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Acme.Library.Tests
{
    [TestClass]
    public class CoyoteTests
    {
        public CoyoteTests()
        {
            TrapTypeSelectorMock = new Mock<ITrapTypeSelector>();
            TrapFactoryMock = new Mock<ITrapFactory>();
            TrapProcessorMock = new Mock<ITrapProcessor>();
        }

        private Mock<ITrapTypeSelector> TrapTypeSelectorMock { get; }
        private Mock<ITrapFactory> TrapFactoryMock { get; }
        private Mock<ITrapProcessor> TrapProcessorMock { get; }

        [TestMethod]
        public void TryCatchRoadrunner_Returns_TrapResult()
        {
            //Arrange
            TrapTypeSelectorMock.Setup(m => m.Select(It.IsAny<int>())).Returns(TrapType.Anvil);
            TrapFactoryMock.Setup(m => m.Create(It.IsAny<TrapType>())).Returns(new Trap {ChanceOfSuccess = 0, Type = TrapType.Anvil});
            TrapProcessorMock.Setup(m => m.Process(It.IsAny<Trap>())).Returns(new TrapResult());

            var sut = new Coyote(TrapTypeSelectorMock.Object, TrapFactoryMock.Object, TrapProcessorMock.Object);

            //Act
            var result = sut.TryCatchRoadrunner();

            //Assert
            Assert.IsInstanceOfType(result, typeof(TrapResult));
        }

        [TestMethod]
        public void TryCatchRoadrunner_Returns_UnsucessfulTrapResult()
        {
            //Arrange
            TrapTypeSelectorMock.Setup(m => m.Select(It.IsAny<int>())).Returns(TrapType.Anvil);
            TrapFactoryMock.Setup(m => m.Create(It.IsAny<TrapType>())).Returns(new Trap {ChanceOfSuccess = 0, Type = TrapType.Anvil});
            TrapProcessorMock.Setup(m => m.Process(It.IsAny<Trap>())).Returns(new TrapResult());

            var sut = new Coyote(TrapTypeSelectorMock.Object, TrapFactoryMock.Object, TrapProcessorMock.Object);

            //Act
            var result = sut.TryCatchRoadrunner();

            //Assert
            result.IsSuccess.Should().BeFalse();
        }

        [TestMethod]
        public void TryCatchRoadrunner_HasNoExceptionHandling()
        {
            //Arrange
            TrapTypeSelectorMock.Setup(m => m.Select(It.IsAny<int>())).Returns(TrapType.Anvil);
            TrapFactoryMock.Setup(m => m.Create(It.IsAny<TrapType>())).Throws<Exception>();
            var sut = new Coyote(TrapTypeSelectorMock.Object, TrapFactoryMock.Object, TrapProcessorMock.Object);

            //Act
            Action a = () => sut.TryCatchRoadrunner();

            //Assert
            a.ShouldThrow<Exception>();
        }
    }
}