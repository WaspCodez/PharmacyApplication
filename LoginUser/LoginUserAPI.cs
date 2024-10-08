namespace PharmacyApplication.LoginUserDetails
{
    public class LoginUserAPI
    {
        private readonly LoginUserRepo _loginUserRepo;
        public bool hasError = false;
        public string lastErrorMessage = "";

        public LoginUserAPI()
        {
            _loginUserRepo = new LoginUserRepo();
        }

        public async Task<IEnumerable<LoginUserInformation>> LoginUserGetAsync()
        {
            try
            {
                var userList = await _loginUserRepo.LoginUserGetAsync();
                return userList;
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
                return Enumerable.Empty<LoginUserInformation>();
            }
        }

        public async Task LoginUserAddAsync(LoginUserInformation loginUserInformation)
        {
            try
            {
                await _loginUserRepo.LoginUserAddAsync(loginUserInformation);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }

        public async Task LoginUserPutAsync(int id, string role_name, string username, string password)
        {
            try
            {
                await _loginUserRepo.LoginUserPutAsync(id, role_name, username, password);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }

        public async Task LoginUserDeleteAsync(int id)
        {
            try
            {
                await _loginUserRepo.LoginUserDeleteAsync(id);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }
    }
}
