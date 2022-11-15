using IRepositoryLib;
using ProductLib;
using System.Text.Json;
using LoggerLib;
using Microsoft.Extensions.Logging;

namespace ProductRepoLib
{
    public class ProductRepository : IRepository<Product, int>
    {
        List<Product>? products;
        ILogger<ProductRepository> logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            using (StreamReader r = new StreamReader(@"products.json"))
            {
                products = (List<Product>?)JsonSerializer.Deserialize(r.ReadToEnd(), typeof(List<Product>));
            }
            this.logger = logger;
        }

        public IEnumerable<Product>? Get()
        {
            logger.LogInformation("getting all products");
            return products;
        }

        public Product? GetById(int id)
        {
            logger.LogInformation($"getting product with id = {id}");
            return products?.Find(p => p.ProductID == id);
        }

        public void Add(Product item)
        {
            products?.Add(item);
        }

        public bool Update(int id, Product item)
        {
            Product? p = GetById(id);
            if (p != null && products != null)
            {
                products[p.ProductID - 1] = item;
                return true;
            }
            return false;
        }

        public Product? Delete(int id)
        {
            Product? p = GetById(id);
            if (p != null)
                products?.Remove(p);
            return p;
        }

        public void Dispose()
        {
        }
    }
}