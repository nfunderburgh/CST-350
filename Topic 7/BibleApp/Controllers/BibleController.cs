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

        public BibleController()
        {
            repository = new BibleDAO();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SearchForm()
        {
            return View();
        }

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
