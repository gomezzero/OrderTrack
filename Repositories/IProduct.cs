using OrderTrack.Models;

namespace OrderTrack.Repositories
{
    public interface IProduct
    {
        // CRUD
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);

        // GET
        Task<List<Product>> GetAll();
        Task<Product?> GetById(int id);

        // Util
        Task<bool> CheckExistence(int id);

    }
}