using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetCategory(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if(category == null)
            {
                NotFound("category does not exist");
            }

            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _categoryRepository.GetAll());
        }
        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Category>>> GetProducts()
        {
            return Ok(await _categoryRepository.GetAllProducts());
        }
        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            if(await _categoryRepository.SaveAll())
            {
                return Ok("Category created.");
            }
            return BadRequest("Error");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _categoryRepository.Update(category);
            if (await _categoryRepository.SaveAll())
            {
                return Ok(category);
            }
            return BadRequest("Error");

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if(category == null)
            {
                NotFound("category does not exist");
            }
            _categoryRepository.Delete(category);

            if(await _categoryRepository.SaveAll())
            {
                return Ok("Category deleted");
            }
            return BadRequest("Error");

        }

     }
}
