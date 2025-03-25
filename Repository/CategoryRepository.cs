using ApiCatalogo.Context;
using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        //instancia o context
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }
        
        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }
        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }
        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Category>> GetAllProducts()
        {
            //Include() Faz com que seja possível carregar entidades relacionadas
            //Nesse caso ele inclui todos produtos das categorias
            return await _context.Categories.Include(x => x.Products).AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
