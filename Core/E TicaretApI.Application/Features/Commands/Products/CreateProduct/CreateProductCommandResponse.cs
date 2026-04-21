using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Products.CreateProduct
{
    public class CreateProductCommandResponse
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}
