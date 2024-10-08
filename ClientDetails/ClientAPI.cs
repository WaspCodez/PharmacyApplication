using System.Collections;
using System.Net;

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

        public async Task<IEnumerable<ClientInformation>> ClientGetAsync()
        {
            try
            {
                var clientList = await _clientRepo.ClientGetAsync();
                return clientList;
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
                return Enumerable.Empty<ClientInformation>();
            }
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

        public async Task ClientPutAsync(int id, string name, string surname, string identity_number, string medical_aid_number, string address, string cell_number)
        {
            try
            {
                await _clientRepo.ClientPutAsync(id, name, surname, identity_number, medical_aid_number, address, cell_number);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }

        public async Task ClientDeleteAsync(int id)
        {
            try
            {
                await _clientRepo.ClientDeleteAsync(id);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;

            }
        }
    }
}
