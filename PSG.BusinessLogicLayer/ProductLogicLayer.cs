using PSG.Shared.Interfaces;
using PSG.Shared.Models;

namespace PSG.BusinessLogicLayer
{
    public class ProductLogicLayer : IProductBusinessLayer
    {
        private readonly IProductDataLayer nextLayer;

        public ProductLogicLayer(IProductDataLayer layer)
        {
            nextLayer = layer;
        }

        public bool Create(Product product)
        {
            bool result = nextLayer.Create(product);

            return result;
        }
        public Product GetProductById(int id)
        {
            Product resutlt = nextLayer.GetProductById(id);
            return resutlt;
        }
        public bool Update(Product product)
        {
            bool result = nextLayer.Update(product);
            return result;
        }
        public List<Product> GetProducts()
        {
            List<Product> products = nextLayer.GetProducts();
            return products;
        }
        public bool Delete(int id)
        {
            bool result = nextLayer.Delete(id);
            return result;
        }
    }
}