using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Queries.Products.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalCount {  get; set; }
        public object Products {  get; set; }
    }
}
