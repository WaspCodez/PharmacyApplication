using Microsoft.AspNetCore.Mvc;
using PharmacyApplication.ClientDetails;

namespace PharmacyApplication.Controllers
{
    [ApiController]
    [Route("api/v1/client")]
    public class ClientController : BaseApiController
    {
        public ClientController(ILogger<ClientController> logger)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var api = new ClientAPI();
            var ClientList = await api.ClientGetAsync();

            return api.hasError
                ? Ok(ClientList)
                : BadRequest(ClientList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientInformation clientInformation)
        {
            var api = new ClientAPI();
            await api.ClientAddAsync(clientInformation);

            return api.hasError
              ? BadRequest(api.lastErrorMessage)
              : Ok();


        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, string name, string surname, string identity_number, string medical_aid_number, string address, string cell_number)
        {
            var api = new ClientAPI();
            await api.ClientPutAsync(id, name, surname, identity_number, medical_aid_number, address, cell_number);

            return api.hasError 
                ? BadRequest(api.lastErrorMessage) 
                : Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var api = new ClientAPI();
            await api.ClientDeleteAsync(id);

            return api.hasError
              ? BadRequest(api.lastErrorMessage)
              : Ok();

        }
    }
}
