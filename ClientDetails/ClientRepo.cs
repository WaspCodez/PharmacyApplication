using PharmacyApplication;

namespace PharmacyApplication.ClientDetails
{
    public class ClientRepo
    {
        private readonly DapperAdapter _dapper;

        public ClientRepo()
        {
            _dapper = new DapperAdapter();
        }

        public async Task<IEnumerable<ClientInformation>> ClientGetAsync()
        {
            var clientList = await _dapper.QueryAsync<ClientInformation>("dbo.get_all_client_details");
            return clientList;
        }

        public async Task ClientAddAsync(ClientInformation clientInformation)
        {
            var param = new
            {
                @name = clientInformation.name,
                @surname = clientInformation.surname,
                @identity_number = clientInformation.identity_number,
                @medical_aid_number = clientInformation.medical_aid_number,
                @address = clientInformation.address,
                @cell_number = clientInformation.cell_number
            };

            await _dapper.ExecuteAsync("dbo.add_client_details", param);
        }

        public async Task ClientPutAsync(int id, string name, string surname, string identity_number, string medical_aid_number, string address, string cell_number)
        {
            var param = new Dictionary<string, object>();

            if (name != null) param.Add("@name", name);
            if (surname != null) param.Add("@surname", surname);
            if (identity_number != null) param.Add("@identity_number", identity_number);
            if (medical_aid_number != null) param.Add("@medical_aid_number", medical_aid_number);
            if (address != null) param.Add("@address", address);
            if (cell_number != null) param.Add("@cell_number", cell_number);

            param.Add("@id", id); 

            await _dapper.ExecuteAsync("dbo.edit_client_details", param);
        }

        public async Task ClientDeleteAsync(int id)
        {
            var param = new
            {
                @id = id
            };
            await _dapper.ExecuteAsync("dbo.delete_client_details", param);
        }
    }
}
