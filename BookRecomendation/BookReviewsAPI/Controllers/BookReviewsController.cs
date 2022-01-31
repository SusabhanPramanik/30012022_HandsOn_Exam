using BookRecomendationDTO;
using BookRecomendationBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookReviewsAPI.Controllers
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookReviewsController : ApiController
    {
        BookRecomendationBL blObj;
        public BookReviewsController()
        {
            blObj = new BookRecomendationBL();
        }

        [HttpGet]
        public HttpResponseMessage GetRatingsForBook()
        {
            try
            {
                List<BookDTO> lstOfBook = blObj.ShowReviewsForBook();
                if (lstOfBook.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, lstOfBook);
                else
                    return Request.CreateResponse(HttpStatusCode.OK, "No Book Details");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

