using ApiCatalogo.Models;

namespace ApiCatalogo.Interface
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        //Utilizado para salvar todas as alterações.
        Task<bool> SavelAll();
    }
}
