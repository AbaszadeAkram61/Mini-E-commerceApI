using E_TicaretApI.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretApI.Application.Features.Commands.Products.UploadProduct
{
    public class UploadProductCommandHandle : IRequestHandler<UploadProductCommandRequest, UploadProductCommandRespnse>
    {
        private readonly IFileService _file;
        public async Task<UploadProductCommandRespnse> Handle(UploadProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _file.UploadAsync("product-images", request.Files);
            return new UploadProductCommandRespnse();
        }
    }
}
