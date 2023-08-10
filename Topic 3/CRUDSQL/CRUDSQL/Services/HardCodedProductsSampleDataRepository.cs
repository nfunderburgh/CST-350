using Act_2.Models;
using Bogus;

namespace Act_2.Services
{
    public class HardCodedProductsSampleDataRepository : IProductsDataService
    {
        List<ProductModel> productList = new List<ProductModel>();

        public HardCodedProductsSampleDataRepository()
        {
            productList.Add(new ProductModel(1, "Mouse Pad", 5.99m, "A square piece of plastic to make a mouse move easier"));
            productList.Add(new ProductModel(2, "Web Cam", 10.99m, "Enables you to show you face when on a zoom meeting"));
            for (int i = 0; i < 100; i++)
            {
                productList.Add(new Faker<ProductModel>()
                    .RuleFor(p => p.Id, i + 5)
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                    .RuleFor(p => p.Description, f => f.Rant.Review())
                    );
            }
        }

        public List<ProductModel> AllProducts()
        {
            return productList;
        }

        public bool Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public ProductModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public int update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
