using E_TicaretApI.Application.Features.Commands.Products.CreateProduct;
using E_TicaretApI.Application.Features.Commands.Products.RemoveProduct;
using E_TicaretApI.Application.Features.Commands.Products.UpdateProduct;
using E_TicaretApI.Application.Features.Commands.Products.UploadProduct;
using E_TicaretApI.Application.Features.Queries.Products.GetAllProduct;
using E_TicaretApI.Application.Features.Queries.Products.GetByIdProduct;
using E_TicaretApI.Application.Repositories;
using E_TicaretApI.Application.RequestParametr;
using E_TicaretApI.Application.Services;
using E_TicaretApI.Application.ViewModel.Product;
using E_TicaretApI.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_TicaretApI.ApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        private readonly IValidator<Product> _validator;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IFileService _file;
        private readonly IMediator _mediator;

        public ProductsController(IRepository<Product> repository,
            IValidator<Product> validator,
            IWebHostEnvironment webHostEnvironment,
            IFileService file,
            IMediator mediator)
        {
            _repository = repository;
            _validator = validator;
            _webHostEnvironment = webHostEnvironment;
            _file = file;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQuery)
        {
            GetAllProductQueryResponse response= await _mediator.Send(getAllProductQuery);
            return Ok(response); 
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest request)
        {
           GetByIdProductQueryResponse response=await _mediator.Send(request);
           return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response=await _mediator.Send(request);
            return Ok("Mehsul elave olundu");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveProductCommandRequest request)
        {
            RemoveProductCommandResponse response=await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromForm] UploadProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();

          
        }

    }
}
