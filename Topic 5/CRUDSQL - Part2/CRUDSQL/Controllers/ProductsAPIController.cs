using Act_2.Models;
using Act_2.Services;
using CRUDSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDSQL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsAPIController : ControllerBase
    {
        ProductsDAO repository = new ProductsDAO();


        [HttpGet]
        [ProducesDefaultResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> Index()
        {
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select
                                                     new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOList;
        }

        [HttpGet("searchresults/{searchTerm}")]
        public IEnumerable<ProductDTO> SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);

            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach(ProductModel p in productList)
            {
                productDTOList.Add(new ProductDTO(p.Id, p.Name, p.Price, p.Description));
            }
            return productDTOList;
        }

        [HttpGet("showoneproduct/{Id}")]
        [ProducesDefaultResponseType(typeof(ProductDTO))]
        public ActionResult <ProductDTO> ShowOneProduct(int Id)
        {
            
            ProductModel product = repository.GetProductById(Id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);

            return productDTO;
        }

        [HttpPut("processedit")]
        [ProducesDefaultResponseType(typeof(List<ProductDTO>))]
        public IEnumerable<ProductDTO> ProcessEdit(ProductModel product)
        {
            repository.update(product);
            List<ProductModel> productList = repository.AllProducts();
            IEnumerable<ProductDTO> productDTOList = from p in productList
                                                     select new ProductDTO(p.Id, p.Name, p.Price, p.Description);
            return productDTOList;
        }

        [HttpPut("ProcessEditReturnOneItem")]
        [ProducesDefaultResponseType(typeof(ProductDTO))]
        public ActionResult<ProductDTO> ProcessEditReturnOneItem(ProductModel product)
        {
            repository.update(product);
            ProductModel updatedProduct = repository.GetProductById(product.Id);
            ProductDTO productDTO = new ProductDTO(product.Id, product.Name, product.Price, product.Description);
            return productDTO;
        }
    }
}
