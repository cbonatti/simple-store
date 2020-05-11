using FluentAssertions;
using NUnit.Framework;
using StoreManagement.Core.Commands;
using StoreManagement.Core.Validations.Product;
using System;
using System.Linq;

namespace StoreManagement.Core.Tests.Validations.Product
{
    [TestFixture]
    public class UpdateProductCommandValidatorTest
    {
        [Test]
        public void Should_Not_Validate_Product_Without_Name()
        {
            var command = new UpdateProductCommand()
            {
                Id = Guid.NewGuid(),
                Price = 1,
                Stock = 0
            };
            var result = new UpdateProductCommandValidator(command).Validate();
            result.Success.Should().BeFalse();
            result.Messages.FirstOrDefault().Should().Be(ProductValidationMessages.NAME);
        }

        [Test]
        public void Should_Not_Validate_Product_Without_Price()
        {
            var command = new UpdateProductCommand()
            {
                Id = Guid.NewGuid(),
                Name = "TESTE",
                Price = 0,
                Stock = 0
            };
            var result = new UpdateProductCommandValidator(command).Validate();
            result.Success.Should().BeFalse();
            result.Messages.FirstOrDefault().Should().Be(ProductValidationMessages.PRICE);
        }

        [Test]
        public void Should_Not_Validate_Product_Without_Id()
        {
            var command = new UpdateProductCommand()
            {
                Name = "TESTE",
                Price = 1,
                Stock = 0
            };
            var result = new UpdateProductCommandValidator(command).Validate();
            result.Success.Should().BeFalse();
            result.Messages.FirstOrDefault().Should().Be(ProductValidationMessages.ID);
        }

        [Test]
        public void Should__Validate_Product()
        {
            var command = new UpdateProductCommand()
            {
                Id = Guid.NewGuid(),
                Name = "TESTE",
                Price = 1,
                Stock = 0
            };
            var result = new UpdateProductCommandValidator(command).Validate();
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
