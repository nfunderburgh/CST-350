using BibleApp.Models;
using BibleApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BibleApp.Controllers
{
    public class BibleController : Controller
    {
        BibleDAO repository = new BibleDAO();

        /* The `public BibleController()` is a constructor method for the `BibleController` class. It is responsible for
        initializing the `repository` variable with a new instance of the `BibleDAO` class. This allows the controller
        to have access to the methods and properties of the `BibleDAO` class for performing database operations or any
        other necessary functionality. */
        public BibleController()
        {
            repository = new BibleDAO();
        }

        /// <summary>
        /// The function returns a view for the Index page.
        /// </summary>
        /// <returns>
        /// The method is returning a View result.
        /// </returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The function returns a view for a search form.
        /// </summary>
        /// <returns>
        /// The method is returning a View.
        /// </returns>
        public IActionResult SearchForm()
        {
            return View();
        }

        /// <summary>
        /// The SearchResults function takes in a search term and a selected testament, and returns a list of Bible verses
        /// based on the search term and testament.
        /// </summary>
        /// <param name="searchTerm">The searchTerm parameter is a string that represents the term or keyword that the user
        /// wants to search for in the Bible verses.</param>
        /// <param name="selectTestanment">The selectTestanment parameter is a string that represents the selected Testament
        /// in a search. It can have three possible values: "Both", "Old Testament", or "New Testament".</param>
        /// <returns>
        /// The method is returning an IActionResult, which is typically used to return a view in ASP.NET MVC. In this case,
        /// it is returning the "Index" view with the verseList as the model.
        /// </returns>
        public IActionResult SearchResults(string searchTerm, string selectTestanment)
        {
            List<BibleModel> verseList = null;

            switch (selectTestanment)
            {
                case "Both":
                    verseList = repository.SearchVersesBoth(searchTerm);
                    break;
                case "Old Testanment":
                    verseList = repository.SearchVersesOld(searchTerm);
                    break;
                case "New Testanment":
                    verseList = repository.SearchVersesNew(searchTerm);
                    break;
                default:
                    verseList = repository.SearchVersesBoth(searchTerm);
                    break;
            }
            return View("Index", verseList);
        }
    }
}
