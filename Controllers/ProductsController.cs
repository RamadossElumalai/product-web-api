using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> products = new List<Product> ();

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return products.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            if(product.Id > 0) {
                var existingProduct = products.Where(x=>x.Id.Equals(product.Id)).FirstOrDefault();
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Category = product.Category;
                existingProduct.Price = product.Price;
            }
            else {
                product.Id = products.Count + 1;
                products.Add(product);
            }
            return product;
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            var product = products.Where(x=>x.Id.Equals(id)).FirstOrDefault();
            products.Remove(product);
        }

    }
}
