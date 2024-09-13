using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_free.Models;
using WebAPI_free.Repositories;

namespace WebAPI_free.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepostory accountRepostory;

        public AccountController(IAccountRepostory repostory)
        {
            accountRepostory = repostory;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result =await accountRepostory.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return StatusCode(500);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await accountRepostory.SigninAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized("khong thanh cong, loi, roi");
            }
            return Ok(result);
        }
    }
}
