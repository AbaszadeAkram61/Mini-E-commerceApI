using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Application.RequestParametr;
using E_TicaretApI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IRepository<Product> _repository;

        public GetAllProductQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            var totalCount = _repository.GetAll().Count();
            var products = _repository.GetAll().Select(p => new
            {
                p.Name,
                p.Price,
                p.Stock
            }).Skip(request.Page * request.Size).Take(request.Size);
            return new()
            {
                Products=products,
                TotalCount=totalCount
            };
        }
    }
}
