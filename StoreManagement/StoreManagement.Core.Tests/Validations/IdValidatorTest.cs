using FluentAssertions;
using NUnit.Framework;
using StoreManagement.Core.Validations;
using StoreManagement.Core.Validations.Product;
using System;
using System.Linq;

namespace StoreManagement.Core.Tests.Validations
{
    [TestFixture]
    public class IdValidatorTest
    {
        [Test]
        public void Should_Not_Validate_Empty_Id()
        {
            var result = new IdValidator().Validate(Guid.Empty);
            result.Success.Should().BeFalse();
            result.Messages.FirstOrDefault().Equals(ProductValidationMessages.ID);
        }

        [Test]
        public void Should_Validate_Id()
        {
            var result = new IdValidator().Validate(Guid.NewGuid());
            result.Success.Should().BeTrue();
            result.Messages.Any().Should().BeFalse();
        }
    }
}
