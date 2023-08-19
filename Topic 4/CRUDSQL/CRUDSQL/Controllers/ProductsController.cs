using Act_2.Models;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Act_2.Services;

namespace Act_2.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDAO repository = new ProductsDAO();
        public ProductsController()
        {
            repository = new ProductsDAO();

        }

        public IActionResult Index()
        {
            return View(repository.AllProducts());
        }

        public IActionResult SearchResults(string searchTerm)
        {
            List<ProductModel> productList = repository.SearchProducts(searchTerm);
            return View("Index", productList);
        }

        public IActionResult SearchForm()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            ViewBag.name = "Shad";
            ViewBag.secretNumber = 13;
            return View();
        }

        public IActionResult ShowEditForm(int id)
        {
            return View(repository.GetProductById(id));
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
            repository.update(product);
            return View("Index", repository.AllProducts());
        }

        public IActionResult DeleteItem(ProductModel product)
        {
            repository.Delete(product);
            return View("Index", repository.AllProducts());
        }
        public IActionResult ShowOneProduct(int Id)
        {
            return View(repository.GetProductById(Id));
        }

        public IActionResult ShowOneProductJSON(int Id)
        {
            return Json(repository.GetProductById(Id));
        }

        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
            repository.update(product);
            return PartialView("_productCard", product);
        }
    }
}
