using NUnit.Framework;
using Moq;
using CalculatorApp;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_AddsTwoNumbers_CorrectResult()
        {
            var result = _calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Subtract_SubtractsTwoNumbers_CorrectResult()
        {
            var result = _calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Multiply_MultipliesTwoNumbers_CorrectResult()
        {
            var result = _calculator.Multiply(4, 3);
            Assert.AreEqual(12, result);
        }

        [Test]
        public void Divide_DividesTwoNumbers_CorrectResult()
        {
            var result = _calculator.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        [Test]
        public void Add_WithMocks_ReturnsExpectedResult()
        {
            var mock = new Mock<ICalculatorService>();
            mock.Setup(m => m.Add(It.IsAny<double>(), It.IsAny<double>())).Returns(10);
            var result = mock.Object.Add(4, 6);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Subtract_WithMocks_ReturnsExpectedResult()
        {
            var mock = new Mock<ICalculatorService>();
            mock.Setup(m => m.Subtract(It.IsAny<double>(), It.IsAny<double>())).Returns(1);
            var result = mock.Object.Subtract(5, 4);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Multiply_WithMocks_ReturnsExpectedResult()
        {
            var mock = new Mock<ICalculatorService>();
            mock.Setup(m => m.Multiply(It.IsAny<double>(), It.IsAny<double>())).Returns(20);
            var result = mock.Object.Multiply(4, 5);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Divide_WithMocks_ReturnsExpectedResult()
        {
            var mock = new Mock<ICalculatorService>();
            mock.Setup(m => m.Divide(It.IsAny<double>(), It.IsAny<double>())).Returns(2);
            var result = mock.Object.Divide(10, 5);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Divide_WithMocks_ThrowsException()
        {
            var mock = new Mock<ICalculatorService>();
            mock.Setup(m => m.Divide(It.IsAny<double>(), 0)).Throws(new DivideByZeroException("Cannot divide by zero."));
            Assert.Throws<DivideByZeroException>(() => mock.Object.Divide(10, 0));
        }
    }
}
