namespace PharmacyApplication.ProductDetails
{
    public class ProductAPI
    {
        private readonly ProductRepo _productRepo;
        public bool hasError = false;
        public string lastErrorMessage = "";

        public ProductAPI()
        {
            _productRepo = new ProductRepo();
        }

        public async Task<IEnumerable<ProductInformation>> ProductGetAsync()
        {
            try
            {
                var productList = await _productRepo.ProductGetAsync();
                return productList;
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
                return Enumerable.Empty<ProductInformation>();
            }
        }

        public async Task ProductAddAsync(ProductInformation productInformation)
        {
            try
            {
                await _productRepo.ProductAddAsync(productInformation);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }

        public async Task ProductPutAsync(int id, string product_name, string product_description, decimal product_price, int product_quantity)
        {
            try
            {
                await _productRepo.ProductPutAsync(id, product_name, product_description, product_price, product_quantity);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }

        public async Task ProductDeleteAsync(int id)
        {
            try
            {
                await _productRepo.ProductDeleteAsync(id);
            }
            catch (Exception ex)
            {
                hasError = true;
                lastErrorMessage = ex.Message;
            }
        }
    }
}
