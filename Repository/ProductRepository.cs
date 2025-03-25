using ApiCatalogo.Context;
using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repository
{
    public class ProductRepository : IProductRepository
    {
        //instancia o context
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }
        public void Update(Product product)
        {
            //Configuração para conseguir realizar a edição do Product no banco(usando Entity).
            _context.Entry(product).State = EntityState.Modified;
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<bool> SavelAll()
        {
            //Se for maior que zero ele salva, caso contrário ele retorna um erro(Não conseguiu salvar). 
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
