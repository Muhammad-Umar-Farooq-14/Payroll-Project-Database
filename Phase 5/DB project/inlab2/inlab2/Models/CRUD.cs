using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace inlab2.Models
{
	public class CRUD
	{   //use Integrated Security= true instead of User ID and password for windows authentication.
		public static string connectionString = "data source=localhost; Initial Catalog=PayrollManagement; user ID=sa; password=12345678";

		public static User getuserinfo()
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;

			try
			{ 
				cmd = new SqlCommand("select * from employee where Emp_Email=@email", con);
				cmd.Parameters.AddWithValue("@email",Session["email"].ToString());
				cmd.CommandType = System.Data.CommandType.Text;

				SqlDataReader rdr = cmd.ExecuteReader();
				User user = new User();
				if (rdr.Read())
				{
					user.userId = rdr["EmployeeID"].ToString();
					user.employeeName = rdr["EmployeeName"].ToString();
					user.employeeAddress = rdr["EmployeeAddress"].ToString();
					user.dateOfBirth = rdr["EmployeeDOB"].ToString();
					user.contact = rdr["Emp_ContactNo"].ToString();
					user.payGrade = rdr["PayGrade"].ToString();
					user.email = rdr["Emp_Email"].ToString();
					user.password = rdr["Emp_Password"].ToString();
					user.loginStatus = rdr["Emp_LoginStatus"].ToString();
					
					return user;
				}
				rdr.Close();
				con.Close();

				return null;


			}

			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
				return null;

			}

		}
		public static int Login(string email, string password)
		{

			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_UserLogin", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
				cmd.Parameters.Add("@Pass", SqlDbType.NVarChar, 50).Value = password;
				cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd.ExecuteNonQuery();
				result = Convert.ToInt32(cmd.Parameters["@output"].Value);


			}

			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
				result = -1; //-1 will be interpreted as "error while connecting with the database."
			}
			finally
			{
				con.Close();
			}
			return result;

		}





		public static int Signup(string Name, string Address, string email, string contact, string dateOfBirth, string password2)
		{

			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_SignUp", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
				cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 250).Value = Address;
				cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 20).Value = contact;
				cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password2;
				cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = dateOfBirth;


				cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

				cmd.ExecuteNonQuery();
				result = Convert.ToInt32(cmd.Parameters["@output"].Value);

			}

			catch (SqlException ex)
			{
				Console.WriteLine("SQL Error" + ex.Message.ToString());
				result = -1; //-1 will be interpreted as "error while connecting with the database."
			}
			finally
			{
				con.Close();
			}
			return result;

		}

	}
}