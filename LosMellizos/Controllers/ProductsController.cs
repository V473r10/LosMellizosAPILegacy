using LosMellizos.Methods;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(Products.Read());
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetProduct(int Id)
        {
            return Ok(Products.Read(Id));
        }

        [HttpPost]
        [Route("NewProduct")]
        public IActionResult NewProduct(string Product, int Stock, int Price)
        {
            return Ok(Products.NewProduct(Product, Stock, Price));
        }
        
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(string Product, int Price, int Id)
        {
            return Ok(Products.Update(Product, Price, Id));
        }

        [HttpPut]
        [Route("ChangePrice")]
        public IActionResult ChangePrice(int Price, int Id)
        {
            return Ok(Products.ChangePrice(Price, Id));
        }

        [HttpPut]
        [Route("AddStock")]
        public IActionResult AddStock(int Add, int Id)
        {
            return Ok(Products.AddStock(Add, Id));
        }

        [HttpPut]
        [Route("SubStock")]
        public IActionResult SubStock(int Sub, int Id)
        {
            return Ok(Products.SubStock(Sub, Id));
        }

        [HttpPut]
        [Route("SetStock")]
        public IActionResult SetStock(int Stock, int Id)
        {
            return Ok(Products.SetStock(Stock, Id));
        }

        [HttpPut]
        [Route("SetAvailable")]
        public IActionResult SetAvailable(bool Available, int Id)
        {
            return Ok(Products.SetAvailable(Available, Id));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(Products.Delete(Id));
        }

    }
}
