using Act_2.Models;

namespace Act_2.Services
{
    public interface IProductsDataService
    {
        List<ProductModel> AllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        bool Delete(ProductModel product);
        int update(ProductModel product);

    }
}
