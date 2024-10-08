namespace PharmacyApplication.ProductDetails
{
    public class ProductRepo
    {
        private readonly DapperAdapter _dapper;

        public ProductRepo()
        {
            _dapper = new DapperAdapter();
        }

        public async Task<IEnumerable<ProductInformation>> ProductGetAsync()
        {
            var productList = await _dapper.QueryAsync<ProductInformation>("dbo.get_all_product_details");
            return productList;
        }

        public async Task ProductAddAsync(ProductInformation productInformation)
        {
            var param = new
            {
                @product_name = productInformation.product_name,
                @product_description = productInformation.product_description,
                @product_price = productInformation.product_price,
                @product_quantity = productInformation.product_quantity
            };

            await _dapper.ExecuteAsync("dbo.add_product_details", param);
        }

        public async Task ProductPutAsync(int id, string product_name, string product_description, decimal product_price, int product_quantity)
        {
            var param = new Dictionary<string, object>();

            if (product_name != null) param.Add("@product_name", product_name);
            if (product_description != null) param.Add("@product_description", product_description);
            if (product_price != 0) param.Add("@product_price", product_price);
            if (product_quantity != 0) param.Add("@product_quantity", product_quantity);

            param.Add("@id", id);

            await _dapper.ExecuteAsync("dbo.edit_product_details", param);
        }

        public async Task ProductDeleteAsync(int id)
        {
            var param = new
            {
                @id = id
            };
            await _dapper.ExecuteAsync("dbo.delete_product_details", param);
        }
    }
}
