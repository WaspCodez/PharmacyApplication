namespace PharmacyApplication.LoginUserDetails
{
    public class LoginUserRepo
    {
        private readonly DapperAdapter _dapper;

        public LoginUserRepo()
        {
            _dapper = new DapperAdapter();
        }

        public async Task<IEnumerable<LoginUserInformation>> LoginUserGetAsync()
        {
            var userList = await _dapper.QueryAsync<LoginUserInformation>("dbo.get_all_login_users");
            return userList;
        }

        public async Task LoginUserAddAsync(LoginUserInformation loginUserInformation)
        {
            var param = new
            {
                @role_name = loginUserInformation.role_name,
                @username = loginUserInformation.username,
                @password = loginUserInformation.password 
            };

            await _dapper.ExecuteAsync("dbo.add_login_user", param);
        }

        public async Task LoginUserPutAsync(int id, string role_name, string username, string password)
        {
            var param = new Dictionary<string, object>
            {
                { "@id", id }
            };

            if (!string.IsNullOrEmpty(role_name)) param.Add("@role_name", role_name);
            if (!string.IsNullOrEmpty(username)) param.Add("@username", username);
            if (!string.IsNullOrEmpty(password)) param.Add("@password", password); 

            await _dapper.ExecuteAsync("dbo.edit_login_user", param);
        }

        public async Task LoginUserDeleteAsync(int id)
        {
            var param = new { @id = id };
            await _dapper.ExecuteAsync("dbo.delete_login_user", param);
        }
    }
}
