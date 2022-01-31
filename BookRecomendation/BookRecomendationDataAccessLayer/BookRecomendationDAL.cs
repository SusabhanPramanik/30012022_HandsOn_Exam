using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecomendationDTO;

namespace BookRecomendationDataAccessLayer
{
    //DO NOT MODIFY THE METHOD NAMES : Adding of parameters / changing the return types of the given methods may be required.
    public class BookRecomendationDAL
    {
        SqlConnection conObj;
        SqlCommand conOb;
        public BookRecomendationDAL()
        {
            conObj = new SqlConnection(ConfigurationManager.ConnectionStrings["BookRecomendation"].ConnectionString);


        }

        public int ConnectionToDB()
        {
            try
            {
                BookRecomendationDAL dalObj = new BookRecomendationDAL();
                return dalObj.ConnectionToDB();
            }
            catch (Exception)
            {
                return -1;
            }
        }



        public List<BookDTO> FetchReviewsForBook()
        {
            
                try
                {
                    conOb = new SqlCommand(@"SELECT book_isbn,rating,review FROM dbo.Reviews", conObj);
                    conObj.Open();
                    SqlDataReader drDept = conOb.ExecuteReader();
                    //while (drDept.Read())
                    //{
                    //    Console.WriteLine(drDept["Name"]+" | "+drDept["GroupName"]);
                    //}
                    List<BookDTO> lstDept = new List<BookDTO>();
                    while (drDept.Read())
                    {
                        BookDTO deptFromReader = new BookDTO();
                        deptFromReader.book_isbn = drDept["book_isbn"].ToString();
                        deptFromReader.rating = drDept["rating"].ToString();
                        deptFromReader.review = drDept["review"].ToString();

                    lstDept.Add(deptFromReader);
                        //lstDept.Add(new DeptDetailsDTO()
                        //{
                        //    DeptName = drDept["Name"].ToString(),
                        //    DeptGroupName = drDept["GroupName"].ToString()
                        //});
                    }
                    return lstDept;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conObj.Close();
                }
            }
        }

       /* public void SaveReviewForBookToDB()
        {

        }*/

}

