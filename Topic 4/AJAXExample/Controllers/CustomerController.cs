using AJAXExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAXExample.Controllers
{
    public class CustomerController : Controller
    {
        List<CustomerModel> customers = new List<CustomerModel>();

        public CustomerController()
        {
            customers.Add(new CustomerModel(0, "Sherry", 42));
            customers.Add(new CustomerModel(1, "Melvin", 18));
            customers.Add(new CustomerModel(2, "Jerry", 26));
            customers.Add(new CustomerModel(3, "Velma", 34));
            customers.Add(new CustomerModel(4, "Wendy", 7));
            customers.Add(new CustomerModel(5, "Kim", 82));
        }

        public IActionResult Index()
        {
            return View(customers);
        }

        public IActionResult ShowOnePerson(int Id)
        {
            return PartialView(customers.FirstOrDefault(c => c.Id == Id));
        }
    }
}
