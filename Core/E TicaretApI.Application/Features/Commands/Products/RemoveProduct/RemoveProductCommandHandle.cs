using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Products.RemoveProduct
{
    public class RemoveProductCommandHandle : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IRepository<Product> _repository;

        public RemoveProductCommandHandle(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id);
            await _repository.SaveAsync();
            return new();
        }
    }
}
