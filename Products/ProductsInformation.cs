using System.Text.Json.Serialization;

namespace PharmacyApplication.ProductDetails
{
    public class ProductInformation
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public decimal product_price { get; set; }
        public int product_quantity { get; set; }
    }
}
