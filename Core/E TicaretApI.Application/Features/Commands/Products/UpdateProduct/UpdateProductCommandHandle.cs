using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Application.ViewModel.Product;
using E_TicaretApI.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Products.UpdateProduct
{
    public class UpdateProductCommandHandle : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<Product> _validator;

        public UpdateProductCommandHandle(IRepository<Product> repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<UpdateProductCommandResponse> Handle(
     UpdateProductCommandRequest request,
     CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;

            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return new UpdateProductCommandResponse
                {
                    Success = false,
                    Errors = validationResult.Errors
                                .Select(e => e.ErrorMessage)
                                .ToList()
                };
            }

            await _repository.SaveAsync();

            return new UpdateProductCommandResponse
            {
                Success = true,
                Message = "Product updated successfully"
            };
        }
    }
}
