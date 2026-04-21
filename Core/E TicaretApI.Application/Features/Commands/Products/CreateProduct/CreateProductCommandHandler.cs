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

namespace E_TicaretApI.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<Product> _validator;

        public CreateProductCommandHandler(IRepository<Product> repository, IValidator<Product> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {

            var product = new Product
            {
                Name = request.Name,
                Stock = request.Stock,
                Price = request.Price
            };

            var validationresult = _validator.Validate(product);

            if (!validationresult.IsValid)
            {
                return new CreateProductCommandResponse
                {
                    Success = false,
                    Errors = validationresult.Errors.Select(v => v.ErrorMessage).ToList()
                };
            }

            await _repository.AddAsync(product);
            await _repository.SaveAsync();

            return new CreateProductCommandResponse
            {
                Success = true
            };
        }
    }
}
