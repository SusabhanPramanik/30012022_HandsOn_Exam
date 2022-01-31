using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDataAccessLayer;
using BookRecomendationDTO;

namespace BookRecomendationBusinessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required. 
    public class BookRecomendationBL
    {
        BookRecomendationDAL dalObj;
        public BookRecomendationBL()
        {
            dalObj = new BookRecomendationDAL();
        }
        public int ConnectToDB()
        {
            try
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -89;
            }
        }


        public List<BookDTO> ShowReviewsForBook()
        {
            BookRecomendationDAL dalObj = new BookRecomendationDAL();
            List<BookDTO> lstOfDep = dalObj.FetchReviewsForBook();
            //dalObj.FetchAllDept();
            return lstOfDep;

        }


        public int AddReviewForBook(BookDTO newDeptobj, out int newDeptid)
        {
            BookRecomendationDAL dalObj = new BookRecomendationDAL();
            return dalObj.SaveReviewForBookToDB(newdeptobj, out newdeptid);
        }

    }
}
