using IRepositoryLib;
using ProductLib;

namespace WebAPIDemo
{
    public class ProductService
    {
        IRepository<Product, int> repo;

        public ProductService(IRepository<Product, int> repo)
        {
            this.repo = repo;
        }

        public Product? Get()
        {
            return repo.GetById(10);
        }
    }
}
