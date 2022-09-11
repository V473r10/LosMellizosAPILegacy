using LosMellizos.Methods;
using Microsoft.AspNetCore.Mvc;

namespace LosMellizos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpPost]
        [Route("SignUp")]
        public IActionResult SignUp(string FirstName, string LastName, string Email, string UserName, string Pass, int UserLevel)
        {
            return Ok(Users.SignUp(FirstName, LastName, Email, UserName, Pass, UserLevel));
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string UserName, string Pass)
        {
            return Ok(Users.Login(UserName, Pass));
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(string FirstName, string LastName, string Email, string UserName, int Id)
        {
            return Ok(Users.Update(FirstName, LastName, Email, UserName, Id));
        }

        [HttpPut]
        [Route("ChangePass")]
        public IActionResult ChangePass(int Id, string Pass)
        {
            return Ok(Users.ChangePass(Id, Pass));
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int Id)
        {
            return Ok(Users.Delete(Id));
        }

        [HttpGet]
        [Route("Read")]
        public IActionResult Read()
        {
            return Ok(Users.Read());
        }
    }
}
