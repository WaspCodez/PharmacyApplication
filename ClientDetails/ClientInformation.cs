using System.Numerics;

namespace PharmacyApplication.ClientDetails
{
    public class ClientInformation
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public BigInteger id_number { get; set; }
        public BigInteger? medical_aid_number { get; set; }
        public string address { get; set; }
        public BigInteger cell_number {  get; set; }
    }
}
