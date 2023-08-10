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
    }
}
