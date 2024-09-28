using PSG.DataAccessLayer;
using PSG.DataAccessLayer.Models;

namespace PSG.BusinessLogicLayer
{
    public class ProductLogicLayer
    {
        public bool Create(Product product)
        {
            ProductDataAccess nextLayer = new ProductDataAccess();
            nextLayer.Create(product);
            return true;
        }
        public Product GetProductById(int id)
        {
            ProductDataAccess nextLayer = new ProductDataAccess();
            Product resutlt = nextLayer.GetProductById(id);
            return resutlt;
        }
        public bool Update(Product product)
        {
            ProductDataAccess nextLayer = new ProductDataAccess();
            bool result = nextLayer.Update(product);
            return result;
        }
        public List<Product> GetProducts()
        {
            ProductDataAccess nextLayer = new ProductDataAccess();
            List<Product> products = nextLayer.GetProducts();
            return products;
        }
        public bool Delete(int id)
        {
            ProductDataAccess nextLayer = new ProductDataAccess();
            bool result = nextLayer.Delete(id);
            return result;
        }
    }
}