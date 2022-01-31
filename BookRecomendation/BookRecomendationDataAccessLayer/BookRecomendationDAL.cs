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

            contextObj = new BookRecomendation();
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
                    
                    List<BookDTO> lstDept = new List<BookDTO>();
                    while (drDept.Read())
                    {
                        BookDTO deptFromReader = new BookDTO();
                        deptFromReader.book_isbn = drDept["book_isbn"].ToString();
                        deptFromReader.rating = drDept["rating"].ToString();
                        deptFromReader.review = drDept["review"].ToString();

                    lstDept.Add(deptFromReader);
                        
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

        /*public int SaveReviewForBookToDB(BookDTO dptobj, out int dptid)
        {
        try
        {
            conOb = new SqlCommand();
            conOb.CommandText = @"uspAddNewDept";
            conOb.CommandType = System.Data.CommandType.StoredProcedure;
            conOb.Connection = conObj;
            conOb.Parameters.AddWithValue("@book_isbn", dptobj.book_isbn);
            conOb.Parameters.AddWithValue("@rating", dptobj.rating);
            conOb.Parameters.AddWithValue("@review", dptobj.review);
            conOb.Parameters.AddWithValue("@deptDate", System.DateTime.Now);
            SqlParameter returnvalue = new SqlParameter();
            returnvalue.Direction = ParameterDirection.ReturnValue;
            returnvalue.SqlDbType = SqlDbType.Int;
            conOb.Parameters.Add(returnvalue);
            SqlParameter outputValue = new SqlParameter();
            outputValue.Direction = ParameterDirection.Output;
            outputValue.SqlDbType = SqlDbType.Int;
            outputValue.ParameterName = "@deptID";
            conOb.Parameters.Add(outputValue);
            conObj.Open();
            conOb.ExecuteNonQuery();
            dptid = Convert.ToInt32(outputValue.Value);
            return Convert.ToInt32(returnvalue.Value);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            conObj.Close();
        }*/
    }


