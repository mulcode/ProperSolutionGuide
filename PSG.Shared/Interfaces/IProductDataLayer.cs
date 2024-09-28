using PSG.Shared.Models;

namespace PSG.Shared.Interfaces
{
    public interface IProductDataLayer
    {
        bool Create(Product product);
        bool Update(Product product);
        bool Delete(int id);
        List<Product> GetProducts();
        Product GetProductById(int id);
    }
}

