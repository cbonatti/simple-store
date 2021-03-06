﻿using Newtonsoft.Json;
using StoreManagement.Core.Commands;
using StoreManagement.Core.Responses;
using StoreManagement.Core.Services.Interfaces;
using StoreManagement.Core.Validations.Product;
using StoreManagement.Domain.Entities;
using StoreManagement.Infra;
using StoreManagement.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagement.Core.Services
{
    public class ProductService : ServiceBase<Product, ProductResponse>, IProductService
    {
        private readonly IProductCommunicationService communicationService;

        public ProductService(IRepositoryAsync<Product> repository, IProductCommunicationService communicationService) : base(repository)
        {
            this.communicationService = communicationService;
        }

        public async Task<Result<ProductResponse>> Get(Guid id)
        {
            var query = await GetByIdAsync(id);
            return new Result<ProductResponse>(ProductResponse.ToResponse(query));
        }

        public async Task<Result<IEnumerable<ProductResponse>>> GetAll()
        {
            var query = await GetAllAsync();
            var products = query
                            .OrderBy(x => x.Name)
                            .Select(ProductResponse.ToResponse)
                            .AsEnumerable();
            return new Result<IEnumerable<ProductResponse>>(products);
        }

        public async Task<Result<ProductResponse>> Add(AddProductCommand command)
        {
            var validationResult = Validate(new AddProductCommandValidator(command).Validate());
            if (!validationResult.Success)
                return validationResult;

            var product = command.ToEntity();

            product = await AddAsync(product);
            communicationService.Post(product);

            return new Result<ProductResponse>(ProductResponse.ToResponse(product));
        }

        public async Task<Result<ProductResponse>> Update(UpdateProductCommand command)
        {
            var validationResult = Validate(new UpdateProductCommandValidator(command).Validate());
            if (!validationResult.Success)
                return validationResult;

            var product = await GetByIdAsync(command.Id);
            product
                .SetPrice(command.Price)
                .SetStock(command.Stock)
                .SetName(command.Name);

            await UpdateAsync(product);
            communicationService.Put(product);

            return new Result<ProductResponse>(ProductResponse.ToResponse(product));
        }

        public async Task<Result<ProductResponse>> Delete(DeleteProductCommand command)
        {
            var validationResult = Validate(new DeleteProductCommandValidator(command).Validate());
            if (!validationResult.Success)
                return validationResult;
            await RemoveAsync(command.Id);
            communicationService.Delete(command.Id);

            return new Result<ProductResponse>();
        }
    }
}
