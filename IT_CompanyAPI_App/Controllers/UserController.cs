using IT_CompanyAPI_App.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT_CompanyAPI_App.Controllers
{
    public class UserController : ApiController
    {
        SqlConnection conn;
        private void SqlConn()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            conn = new SqlConnection(conString);
        }

        //public IEnumerable<Users> GetUsersList()
        //{
        //    List<Users> UserData = new List<Users>();
        //    SqlConn();
        //    SqlCommand cmd = new SqlCommand("Select * From Users", conn);
        //    conn.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        Users user = new Users();
        //        user.Id = Convert.ToInt32(rdr["Id"]);
        //        user.Username = rdr["tbUname"].ToString();
        //        user.Password = rdr["tbPass"].ToString();
        //        UserData.Add(user);
        //    }
        //    conn.Close();
        //    return UserData;
        //}

        [HttpGet]
        public Response CheckUser(Users user)
        {
            SqlConn();
            conn.Open();

            Response response = new Response();
            try
            {
                if (string.IsNullOrEmpty(user.Username))
                {
                    response.Message = "Username is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(user.Password))
                {
                    response.Message = "Password is Required!";
                    response.Status = 0;
                }
                else
                {
                    string sSQL = "SELECT COUNT(1) FROM Users WHERE tbUname=@Uname AND tbPass=@Pass";
                    var cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@Uname", user.Username);
                    cmd.Parameters.AddWithValue("@Pass", user.Password);
                    int temp = 0;

                    temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        conn.Close();
                        response.Message = "User is Validation Successfully!";
                        response.Status = 1;

                    }
                    else
                    {
                        conn.Close();
                        response.Message = "User Validation Failed!";
                        response.Status = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                response.Message = ex.Message;
                response.Status = 0;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }
    }
}
