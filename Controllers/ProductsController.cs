using ApiCatalogo.Context;
using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using ApiCatalogo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetAll();
            if(products is null || !products.Any())
            {
                return NotFound("Not found Products.");
            }
            return Ok(products); 
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetById(id);
            if(product is null)
            {
                return NotFound("Not found Product.");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            if(product is null)
            {
                return BadRequest("Product not null");
            }
            _productRepository.Add(product);


            if (await _productRepository.SavelAll()){
                //Aqui nessa ação são passadas a rota(Url) ao qual vai retornar após cadastrar um produto
                //Depois informa qual o id que foi cadastrado e também o Produto(Retornar um status 201).
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            return BadRequest("Error");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditProduct(int id, Product product)
        {
            if(id != product.Id)
            {
                return BadRequest();
            }

            _productRepository.Update(product);

            if(await _productRepository.SavelAll())
            {
                return Ok(product);
            }
            return BadRequest("Error");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetById(id);

            if(product == null)
            {
                NotFound("Product is not null");
            }

            _productRepository.Delete(product);

            if(await _productRepository.SavelAll())
            {
                return Ok("Sucess");
            }
            return BadRequest("Error");
        }

    }
}
