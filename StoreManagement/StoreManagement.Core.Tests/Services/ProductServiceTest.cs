using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using StoreManagement.Core.Commands;
using StoreManagement.Core.Services;
using StoreManagement.Domain.Entities;
using StoreManagement.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Core.Tests.Services
{
    [TestFixture]
    public class ProductServiceTest
    {
        static Guid Id1 = Guid.Parse("6d7b6c8f-4a91-4fdc-86b9-6578344658c4");
        static Guid Id2 = Guid.Parse("715da63c-ca4c-4329-b629-a05786c7c51d");
        static Guid Id3 = Guid.Parse("1daa5a6b-cdf1-454b-abf5-8989e869ab62");
        readonly Product Product1 = new Product(Id1, "TESTE 1", 1, 1);
        readonly Product Product2 = new Product(Id2, "TESTE 2", 1, 1);
        readonly Product Product3 = new Product(Id3, "TESTE 3", 1, 1);

        private ProductService service;

        [OneTimeSetUp]
        public void Setup()
        {
            var repository = Substitute.For<IRepositoryAsync<Product>>();
            repository.GetByIdAsync(Id1).Returns(Product1);
            repository.GetByIdAsync(Id2).Returns(Product2);
            repository.GetByIdAsync(Id3).Returns(Product3);

            repository.AddAsync(Arg.Any<Product>()).ReturnsForAnyArgs(new Product("NEW PRODUCT", 3, 3));
            repository.UpdateAsync(Arg.Any<Product>()).ReturnsForAnyArgs(1);
            repository.RemoveAsync(Arg.Any<Guid>()).ReturnsForAnyArgs(true);

            repository.GetAllAsync().Returns(new List<Product>()
            {
                Product1,
                Product2,
                Product3
            });

            service = new ProductService(repository);
        }

        [Test]
        public void Should_Get_Product()
        {
            var result = service.Get(Id1).Result;
            result.Success.Should().BeTrue();
            result.Value.Name.Should().Be(Product1.Name);
        }

        [Test]
        public void Should_Get_All()
        {
            var result = service.GetAll().Result;
            result.Success.Should().BeTrue();
            result.Value.Count().Should().Be(3);
        }

        [Test]
        public void Should_Add_New_Product()
        {
            var result = service.Add(new AddProductCommand() { Name = "NEW PRODUCT", Price = 3, Stock = 3 }).Result;
            result.Success.Should().BeTrue();
            result.Value.Name.Should().Be("NEW PRODUCT");
        }

        [Test]
        public void Should_Not_Add_New_Product_Without_Name()
        {
            var result = service.Add(new AddProductCommand() { Price = 3, Stock = 3 }).Result;
            result.Success.Should().BeFalse();
        }

        [Test]
        public void Should_Not_Add_New_Product_Without_Price()
        {
            var result = service.Add(new AddProductCommand() { Name = "NEW PRODUCT", Stock = 3 }).Result;
            result.Success.Should().BeFalse();
        }

        [Test]
        public void Should_Update_Product()
        {
            var result = service.Update(new UpdateProductCommand() { Id = Id2, Name = "ALTER PRODUCT", Price = 3, Stock = 3 }).Result;
            result.Success.Should().BeTrue();
            result.Value.Name.Should().Be("ALTER PRODUCT");
        }

        [Test]
        public void Should_Not_Update_Product_Without_Id()
        {
            var result = service.Update(new UpdateProductCommand() { Name = "ALTER PRODUCT", Price = 3, Stock = 3 }).Result;
            result.Success.Should().BeFalse();
        }

        [Test]
        public void Should_Not_Update_Product_Without_Name()
        {
            var result = service.Update(new UpdateProductCommand() { Id = Id2, Price = 3, Stock = 3 }).Result;
            result.Success.Should().BeFalse();
        }

        [Test]
        public void Should_Not_Update_Product_Without_Price()
        {
            var result = service.Update(new UpdateProductCommand() { Id = Id2, Name = "ALTER PRODUCT", Stock = 3 }).Result;
            result.Success.Should().BeFalse();
        }

        [Test]
        public void Should_Delete_Product()
        {
            var result = service.Delete(new DeleteProductCommand() { Id = Id3 }).Result;
            result.Success.Should().BeTrue();
        }

        [Test]
        public void Should_Delete_Product_Without_Id()
        {
            var result = service.Delete(new DeleteProductCommand()).Result;
            result.Success.Should().BeFalse();
        }
    }
}
