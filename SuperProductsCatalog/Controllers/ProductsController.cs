//using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SuperProductsCatalog.Model;
using SuperProductsCatalog.Model.Data;

namespace SuperProductsCatalog.Controllers
{

    //GET/PUT/POST/DELETE www.ey.com/api/products
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsDBContext db;
        public ProductsController(ProductsDBContext db)
        {
            this.db = db;
        }

        // endpoint
        // type - GET/POST/PUT/DELETE
        // design url

        //EX: expose an endpoint for getting all products
        // M
        // C

        // GET .../api/products
        [EnableQuery]
        [HttpGet]
        public IQueryable<Product> GetProducts()
        {
            return db.Products.AsQueryable();
        }

        // get product by id
        // URL: GET........./api/products/345

        #region Not Required

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = db.Products.Find(id);

            if (product == null)
            {
                return NotFound($"Product {id} not found"); // 404
            }

            return Ok(product); // 200 + data

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var product = await db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound($"Product {id} not found"); // 404
            }

            return Ok(product); // 200 + data

        }


        // create, design, implement and test below endpoints

        //1. get product by name


        // GET ..../api/products/name/iphone
        [HttpGet]
        [Route("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var product = db.Products.Where(p => p.Name == name).FirstOrDefault();
            if (product == null) { return NotFound(); }
            return Ok(product);
        }



        //2. get all products by category

        // GET......api/products/laptops/category

        [HttpGet]
        [Route("{category}/category")]
        public List<Product> GetAllProductsByCategory(string category)
        {
            var products = from p in db.Products
                           where p.Category == category
                           select p;

            return products.ToList();
        }
        //3. get all products by availability
        // GET ..../api/products/instock
        [HttpGet]
        [Route("instock")]
        public List<Product> GetAllAvailableProducts()
        {
            return db.Products.Where(p => p.IsAvailable).ToList();
        }
        //4. get all products by brand
        // GET....api/products/brand/apple
        [HttpGet]
        [Route("brand/{brand}")]
        public List<Product> GetProductsByBrand(string brand)
        {
            var products = from p in db.Products
                           where p.Brand == brand
                           select p;
            return products.ToList();
        }
        //5. get all products by country
        [HttpGet]
        [Route("country/{country}")]
        public List<Product> GetProductsByCoutry(string country)
        {
            var products = from p in db.Products
                           where p.Country == country
                           select p;
            return products.ToList();
        }


        //6. get all products by price range (300 - 600)
        // GET....api/products/min/300/max/600
        [HttpGet]
        [Route("min/{min:int}/max/{max:int}")]
        public List<Product> GetProductsByPriceRange(int min, int max)
        {
            var products = from p in db.Products
                           where p.Price >= min && p.Price <= max
                           select p;
            return products.ToList();
        }

        //7. get costliest product
        // get.....api/proudcts/costliest
        [HttpGet]
        [Route("costliest")]
        public Product GetCostliestProduct()
        {
            var product = from p in db.Products
                          where p.Price == (from i in db.Products select i.Price).Max()
                          select p;
            return product.FirstOrDefault();
        }
        //8. get cheapest product
        [HttpGet]
        [Route("cheapest")]
        public Product GetCheapestProduct()
        {
            var product = from p in db.Products
                          where p.Price == (from i in db.Products select i.Price).Min()
                          select p;
            return product.FirstOrDefault();
        }
        //9. get all products based on desc (partial match) "a"
        // get ....api/products/description/abcd
        [HttpGet]
        [Route("description/{desc}")]
        public List<Product> GetProductsByDescsdfsdfsdfsdfasdf(string desc)
        {
            return db.Products.Where(p => p.Description.Contains(desc)).ToList();
        }

        //10. get total products by country
        // GET ....api/products/count/country

        [HttpGet]
        [Route("count/{country}")]
        public int GetProductsCountByCountry(string country)
        {
            return db.Products.Where(p => p.Country == country).Count();
        }
        //11. get total cost of all products based on brand
        // GET....api/products/totalcost/{brand}

        //12. get the costliest products based on the category
        // GET...api/products/costliest/{category}

        #endregion

        // endpoint for adding new product


        // POST ....api/products
        [HttpPost] // Save/Create

        public IActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            db.Products.Add(product);
            db.SaveChanges();
            // return 201+location+saved res
            return Created($"api/products/{product.Id}", product);
        }

        // Delete
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var itemToDel = db.Products.Find(id);
            if (itemToDel == null)
            {
                return NotFound("Item not found");
            }
            db.Products.Remove(itemToDel);
            db.SaveChanges();
            return Ok();
        }

        // Edit
        [HttpPut]
        //[HttpPatch] //ToDO: do some reading and implement
        public IActionResult PutProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            // return 200
            return Ok();
        }
    }
}
