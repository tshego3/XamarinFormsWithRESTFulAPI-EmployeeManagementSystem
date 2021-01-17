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
    public class EmployeeController : ApiController
    {
        SqlConnection conn;
        private void SqlConn()
        {
            string conString = ConfigurationManager.ConnectionStrings["DBCS"].ToString();
            conn = new SqlConnection(conString);
        }

        public IEnumerable<Employees> GetEmployeesList()
        {
            List<Employees> EmployeeData = new List<Employees>();
            SqlConn();
            SqlCommand cmd = new SqlCommand("Select * From Employees", conn);
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Employees employee = new Employees();
                employee.EmployeeID = Convert.ToInt32(rdr["employeeID"]);
                employee.Firstname = rdr["tbFirstName"].ToString();
                employee.Surname = rdr["tbSurname"].ToString();
                employee.TellNo = rdr["tbTellNo"].ToString();
                employee.Email = rdr["tbEmail"].ToString();
                EmployeeData.Add(employee);
            }
            conn.Close();
            return EmployeeData;
        }

        [HttpPost]
        public Response SaveEmployee(Employees employee)
        {
            SqlConn();

            Response response = new Response();
            try
            {
                conn.Open();

                SqlCommand cmdR = new SqlCommand("Select * From Employees Where tbTellNo='" + employee.TellNo.ToString() + "'", conn);
                SqlDataReader rdr = cmdR.ExecuteReader();
                if (rdr.Read())
                {
                    conn.Close();
                    response.Message = "Employee Tell No. Already Exist!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.Firstname))
                {
                    response.Message = "Employee Firstname is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.Surname))
                {
                    response.Message = "Employee Surname is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.TellNo))
                {
                    response.Message = "Employee Tell No. is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.Email))
                {
                    response.Message = "Email is Required!";
                    response.Status = 0;
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    string sSQL = "Insert Into Employees (tbFirstName,tbSurname,tbTellNo,tbEmail)values(@Firstname,@Surname,@TellNo,@Email)";
                    var cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@Firstname", employee.Firstname);
                    cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                    cmd.Parameters.AddWithValue("@TellNo", employee.TellNo);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);

                    int temp = 0;

                    temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        conn.Close();
                        response.Message = "Employee Registration Successfully!";
                        response.Status = 1;

                    }
                    else
                    {
                        conn.Close();
                        response.Message = "Employee Registration Failed!";
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

        [HttpPut]
        public Response UpdateEmployee(Employees employee)
        {
            SqlConn();
            conn.Open();

            Response response = new Response();
            try
            {
                if (string.IsNullOrEmpty(employee.Firstname))
                {
                    response.Message = "Employee Firstname is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.Surname))
                {
                    response.Message = "Employee Surname is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.TellNo))
                {
                    response.Message = "Employee Tell No. is Required!";
                    response.Status = 0;
                }
                else if (string.IsNullOrEmpty(employee.Email))
                {
                    response.Message = "Email is Required!";
                    response.Status = 0;
                }
                else
                {
                    string sSQL = "Update Employees Set tbFirstName=@Firstname,tbSurname=@Surname,tbTellNo=@TellNo,tbEmail=@Email Where tbTellNo=@TellNo";
                    var cmd = new SqlCommand(sSQL, conn);
                    cmd.Parameters.AddWithValue("@Firstname", employee.Firstname);
                    cmd.Parameters.AddWithValue("@Surname", employee.Surname);
                    cmd.Parameters.AddWithValue("@TellNo", employee.TellNo);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    int temp = 0;

                    temp = cmd.ExecuteNonQuery();
                    if (temp > 0)
                    {
                        conn.Close();
                        response.Message = "Employee is Updated Successfully!";
                        response.Status = 1;

                    }
                    else
                    {
                        conn.Close();
                        response.Message = "Employee Updation Failed!";
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


        [HttpDelete]
        public Response DeleteEmployee(int EmpID)
        {
            SqlConn();
            conn.Open();

            Response response = new Response();
            try
            {
                string sSQL = "Delete from Employees Where EmployeeID=@Id";
                var cmd = new SqlCommand(sSQL, conn);
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(EmpID));
                int temp = 0;

                temp = cmd.ExecuteNonQuery();
                if (temp > 0)
                {
                    conn.Close();
                    response.Message = "Employee is Deleted Successfully!";
                    response.Status = 1;

                }
                else
                {
                    conn.Close();
                    response.Message = "Employee Delition Failed!";
                    response.Status = 0;
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
