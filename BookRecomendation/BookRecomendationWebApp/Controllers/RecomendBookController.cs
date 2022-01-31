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



namespace AdvWorksPL.Controllers
{
    public class DepartmentController : Controller
    {
        BookRecomendationBL blObj;
        public DepartmentController()
        {
            blObj = new BookRecomendationBL();
        }
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayAllDepartment()
        {
            try
            {
                List<BookDTO> lstDepartments = blObj.GetAllDepts();
                List<BookViewModel> lstDeptModel = new List<BookViewModel>();
                foreach (var department in lstDepartments)
                {
                    BookViewModel newObj = new BookViewModel();
                    newObj.book_isbn = department.book_isbn;
                    newObj.rating = department.rating;
                    newObj.review = department.review; 
                    lstDeptModel.Add(newObj);
                }
                return View(lstDeptModel);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult AddDepartment(BookViewModel fromUI)
        {
            try
            {
                if (fromUI != null)
                {
                    BookDTO NewDept = new BookDTO();
                    NewDept.book_isbn = fromUI.book_isbn;
                    NewDept.review = fromUI.review;
                    NewDept.rating = fromUI.rating;

                    int newDeptID = 0;
                    int retVal = blObj.Addnewdept(NewDept, out newDeptID);
                    if (retVal == 1)
                    {
                        return RedirectToAction("DisplayAllDepartment");
                    }
                    else
                    {
                        return View("Error");
                    }
                    //return RedirectToAction("Success");
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public async Task<ActionResult> DisplayAllDepartmentWebAPIAsync()
        {
            try
            {
                string baseURL = "http://localhost:55577/";
                string routeURL = @"api/Department/GetAllDepartment";
                var apiClient = new HttpClient();
                apiClient.BaseAddress = new Uri(baseURL);
                apiClient.DefaultRequestHeaders.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage apiResponse = await apiClient.GetAsync(routeURL);
                if (apiResponse.IsSuccessStatusCode)
                {
                    var result = apiResponse.Content.ReadAsStringAsync().Result;
                    List<BookViewModel> lstAllDepts = new List<BookViewModel>();
                    var finalResult = JsonConvert.DeserializeObject<List<BookViewModel>>(result);
                    return View(finalResult);
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}