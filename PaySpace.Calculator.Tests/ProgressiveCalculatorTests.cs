using NUnit.Framework;
using PaySpace.Calculator.Web.Services;
using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Tests
{
    [TestFixture]
    internal sealed class ProgressiveCalculatorTests
    {
        private readonly CalculatorHttpService _calculator;
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(-1, 0)]
        [TestCase(50, 5)]
        [TestCase(8350.1, 835.01)]
        [TestCase(8351, 835)]
        [TestCase(33951, 4674.85)]
        [TestCase(82251, 16749.60)]
        [TestCase(171550, 41753.32)]
        [TestCase(999999, 327681.79)]
        public async Task Calculate_Should_Return_Expected_Tax(decimal income, decimal expectedTax)
        {
            var request = new CalculateRequest { Income = income };
            // Act
            var calculatedTax = await _calculator.CalculateTaxAsync(request);

            // Assert
            Assert.Equals(expectedTax, calculatedTax.Tax);
        }
    }
}