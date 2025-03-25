using ApiCatalogo.Models;
using System.Threading.Tasks;

namespace ApiCatalogo.Interface
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetAllProducts();
        Task<IEnumerable<Category>> GetAll();
        Task<bool> SaveAll();
    }
}
