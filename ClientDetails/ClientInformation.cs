using System.Numerics;
using System.Text.Json.Serialization;

namespace PharmacyApplication.ClientDetails
{
    public class ClientInformation
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string identity_number { get; set; }
        public string? medical_aid_number { get; set; }
        public string address { get; set; }
        public string cell_number {  get; set; }
    }
}
