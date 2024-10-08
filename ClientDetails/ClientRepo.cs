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
    }
}
