using IRepositoryLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductLib;
using ProductRepoLib;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //IRepository<Product, int> repo = new ProductRepository();
        IRepository<Product, int> repo;
        ProductService service;

        public ProductController(IRepository<Product, int> repo, ProductService service)
        {

            this.repo = repo;
            this.service = service;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product>? Get()
        {
            return repo.Get();
        }


        // GET api/values/5
        [ProducesResponseType(201)] // No need for typeof(Product)
        [ProducesResponseType(404)]
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product? product = repo.GetById(id);
            if (product == null)
                return NotFound();
            return product;         // Can return the product directly
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            if (id != product.ProductID)
                return BadRequest();
            if (repo.GetById(id) == null)
                return NotFound();
            repo.Update(id, product);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            repo.Add(product);
            // Sets status to Created, adds body and Location header
            return CreatedAtRoute("default", new { id = product.ProductID }, product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product? product = repo.Delete(id);
            if (product == null)
                return NotFound();
            return product;
        }

    }
}
