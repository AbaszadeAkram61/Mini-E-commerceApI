using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Queries.Products.GetByIdProduct
{
    public class GetByIdProductQueryHandle : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IRepository<Product> _repository;
        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetByIdAsync(request.Id);
            return new GetByIdProductQueryResponse()
            {
                Product = product
            };

        }
    }
}
