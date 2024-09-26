using Microsoft.AspNetCore.Mvc;
using PharmacyApplication.ClientDetails;

namespace PharmacyApplication.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController:BaseApiController
    {
        public ClientController(ILogger<ClientController> logger)
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClientInformation clientInformation)
        {
            var api = new ClientAPI();
            await api.ClientAddAsync(clientInformation);

            return api.hasError
              ? BadRequest(api.lastErrorMessage)
              : Ok();


        }
    }
}
