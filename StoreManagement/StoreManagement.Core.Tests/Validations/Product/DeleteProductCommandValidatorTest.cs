using FluentAssertions;
using NUnit.Framework;
using StoreManagement.Core.Commands;
using StoreManagement.Core.Validations.Product;
using System;
using System.Linq;

namespace StoreManagement.Core.Tests.Validations.Product
{
    [TestFixture]
    public class DeleteProductCommandValidatorTest
    {
        [Test]
        public void Should_Not_Validate_Product_Without_Id()
        {
            var command = new DeleteProductCommand();
            var result = new DeleteProductCommandValidator(command).Validate();
            result.Success.Should().BeFalse();
            result.Messages.FirstOrDefault().Should().Be(ProductValidationMessages.ID);
        }

        [Test]
        public void Should__Validate_Product()
        {
            var command = new DeleteProductCommand()
            {
                Id = Guid.NewGuid()
            };
            var result = new DeleteProductCommandValidator(command).Validate();
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
