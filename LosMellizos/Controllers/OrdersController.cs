using LosMellizos.Methods;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpPost]
        [Route("create")]
        public IActionResult Create(int Customer, string Address, List<int> Items, int ListPrice, int FinalPrice,
            string State, DateTime DeliveryDate)
        {
            return Ok(Orders.Create(Customer, Address, Items, ListPrice, FinalPrice, State, DeliveryDate));
        }
        [HttpGet]
        [Route("read")]
        public IActionResult Read()
        {
            return Ok(Orders.Read());
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(string Address, List<int> Items, int ListPrice, int FinalPrice,
            string State, DateTime DeliveryDate, int Id )
        {
            return Ok(Orders.Update(Address, Items, ListPrice, FinalPrice, DeliveryDate, Id));
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(Orders.Delete(Id));
        }

        [HttpGet]
        [Route("getById")]
        public IActionResult GetById(int Id)
        {
            return Ok(Orders.GetById(Id));
        }
        
        [HttpGet]
        [Route("getByCustomer")]
        public IActionResult GetByCustomer(int Customer)
        {
            return Ok(Orders.GetByCustomer(Customer));
        }
        
        [HttpGet]
        [Route("getByCreateDate")]
        public IActionResult GetByCreateDate(DateTime CreateDate)
        {
            return Ok(Orders.GetByCreateDate(CreateDate));
        }
        
        [HttpGet]
        [Route("getByDeliveryDate")]
        public IActionResult GetByDeliveryDate(DateTime DeliveryDate)
        {
            return Ok(Orders.GetByDeliveryDate(DeliveryDate));
        }
        
        [HttpGet]
        [Route("getByState")]
        public IActionResult GetByState(string State)
        {
            return Ok(Orders.GetByState(State));
        }

        
        
    }
}
