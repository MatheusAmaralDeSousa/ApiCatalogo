using ApiCatalogo.Models;

namespace ApiCatalogo.Interface
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        Task<User> GetById(int Id);
        Task<IEnumerable<User>> GetAll();
        Task<bool> SavelAll();
    }
}
