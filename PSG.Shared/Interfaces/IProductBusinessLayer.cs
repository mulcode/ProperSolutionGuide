using System;
using PSG.Shared.Models;

namespace PSG.Shared.Interfaces;

public interface IProductBusinessLayer
{
    bool Create(Product product);
    bool Update(Product product);
    bool Delete(int id);
    List<Product> GetProducts();
    Product GetProductById(int id);
}
