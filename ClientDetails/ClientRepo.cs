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
                p_name = clientInformation.name,
                p_surname = clientInformation.surname,
                p_id_number = clientInformation.id_number,
                p_medical_aid_number = clientInformation.medical_aid_number,
                p_address = clientInformation.address,
                p_cell_number = clientInformation.cell_number
            };

            await _dapper.ExecuteAsync("dbo.add_client_details", param);
        }
    }
}
