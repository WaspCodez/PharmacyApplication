using Microsoft.AspNetCore.Mvc;
using PharmacyApplication.LoginUserDetails;
using System.Threading.Tasks;

namespace PharmacyApplication.Controllers
{
    [ApiController]
    [Route("api/v1/loginuser")]
    public class LoginUserController : ControllerBase
    {
        private readonly LoginUserAPI _loginUserAPI;

        public LoginUserController()
        {
            _loginUserAPI = new LoginUserAPI();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await _loginUserAPI.LoginUserGetAsync();

            return _loginUserAPI.hasError
                ? BadRequest(_loginUserAPI.lastErrorMessage)
                : Ok(userList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginUserInformation loginUserInformation)
        {
            await _loginUserAPI.LoginUserAddAsync(loginUserInformation);

            return _loginUserAPI.hasError
                ? BadRequest(_loginUserAPI.lastErrorMessage)
                : Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LoginUserInformation loginUserInformation)
        {
            await _loginUserAPI.LoginUserPutAsync(id, loginUserInformation.role_name, loginUserInformation.username, loginUserInformation.password);

            return _loginUserAPI.hasError
                ? BadRequest(_loginUserAPI.lastErrorMessage)
                : Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _loginUserAPI.LoginUserDeleteAsync(id);

            return _loginUserAPI.hasError
                ? BadRequest(_loginUserAPI.lastErrorMessage)
                : Ok();
        }
    }
}
