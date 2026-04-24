using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Products.UploadProduct
{
    public class UploadProductCommandRequest:IRequest<UploadProductCommandRespnse>
    {
        public IFormFileCollection Files { get; set; }
    }
}
