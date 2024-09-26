using System.Collections;

namespace PharmacyApplication.ClientDetails
{
    public class ClientAPI
    {
        private readonly ClientRepo _clientRepo;
        public bool hasError = false;
        public String lastErrorMessage = "";

        public ClientAPI()
        {
            _clientRepo = new ClientRepo();
        }

        public async Task ClientAddAsync(ClientInformation clientInformation)
        {
            try
            {
                await _clientRepo.ClientAddAsync(clientInformation);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;

            }
        }
    }
}
