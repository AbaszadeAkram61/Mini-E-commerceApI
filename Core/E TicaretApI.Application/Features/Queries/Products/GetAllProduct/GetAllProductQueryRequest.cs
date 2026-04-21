using E_TicaretApI.Application.RequestParametr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryRequest:IRequest<GetAllProductQueryResponse>
    {
        public int Page {  get; set; }
        public int Size {  get; set; }
    }
}
