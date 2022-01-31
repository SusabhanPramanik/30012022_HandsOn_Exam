using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookRecomendationBusinessLayer;
using BookRecomendationDTO;
using BookRecomendationWebApp.Models;
using Newtonsoft.Json;

namespace BookRecomendationWebApp.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class RecomendBookController : Controller
    {
        BookRecomendationBL blObj;
        public RecomendBookController()
        {
            blObj = new BookRecomendationBL();
        }
        // GET: RecomendBook
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult AddReviews()
        {
            try
            {
                List<BookDTO> lstRecomendBook = blObj.ShowReviewsForBook();
                List<BookViewModel> lstRecomendModel = new List<BookViewModel>();
                foreach (var RecomendBook in lstRecomendBook)
                {
                    BookViewModel newObj = new BookViewModel();
                    newObj.book_isbn = RecomendBook.book_isbn;
                    newObj.rating = RecomendBook.rating;
                    newObj.review = RecomendBook.review;
                    lstRecomendModel.Add(newObj);
                }
                return View(lstRecomendModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public void DisplayResultsUsingWebAPI()
        {

        }
    }
}


