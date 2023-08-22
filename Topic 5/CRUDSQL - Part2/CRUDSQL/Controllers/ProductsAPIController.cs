using Act_2.Models;
using Act_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository = new ProductsDAO();


        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Index()
        {
            return repository.AllProducts();
        }

        [HttpGet("searchresults/{searchTerm}")]
        public ActionResult<IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return productList;
        }

        [HttpGet("showoneproduct/{Id}")]
        public ActionResult <ProductModel> ShowOneProduct(int Id)
        {
            return repository.GetProductById(Id);
        }

        [HttpPut("processedit")]
        public ActionResult<IEnumerable<ProductModel>> ProcessEdit(ProductModel product)
        {
            repository.update(product);
            return repository.AllProducts();
        }

        [HttpPut("ProcessEditReturnOneItem")]
        public ActionResult<ProductModel> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.update(product);
            return repository.GetProductById(product.Id);
        }
    }
}
