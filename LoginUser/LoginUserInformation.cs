using System.Text.Json.Serialization;

namespace PharmacyApplication.LoginUserDetails
{
    public class LoginUserInformation
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? id { get; set; }
        public string role_name { get; set; }
        public string username { get; set; }
        public string password { get; set; } // Ensure this is hashed in practice
    }
}
