using ApiCatalogo.Context;
using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }
        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<bool> SavelAll()
        {
            //Se for maior que zero ele salva, caso contrário ele retorna um erro(Não conseguiu salvar). 
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
