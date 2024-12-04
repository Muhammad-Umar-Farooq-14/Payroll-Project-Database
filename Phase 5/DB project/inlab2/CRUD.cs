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

		public static User getuserinfo(string email)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;

			try
			{
				cmd = new SqlCommand("sp_ShowEmployee", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@EmpEmail", SqlDbType.NVarChar, 50).Value = email;

				cmd.ExecuteNonQuery();

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
        public static int AdminLogin(string email, string password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("sp_AdminLogin", con);
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
		public static Attendance showAttendance(string email)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;

			try
			{
				cmd = new SqlCommand("sp_ShowAttendance", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

				cmd.ExecuteNonQuery();

				SqlDataReader rdr = cmd.ExecuteReader();
				Attendance attendance = new Attendance();
				if (rdr.Read())
				{
					attendance.EmpId = rdr["EID"].ToString();
					attendance.Status = rdr["Status"].ToString();
					attendance.PresenceDate = rdr["PresenceDate"].ToString();
					

					return attendance;
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
		public static Overtime showOvertime(string email)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;

			try
			{
				cmd = new SqlCommand("sp_ShowOvertime", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

				cmd.ExecuteNonQuery();

				SqlDataReader rdr = cmd.ExecuteReader();
				Overtime overtime  = new Overtime();
				if (rdr.Read())
				{
					overtime.EID = rdr["EID"].ToString();
					overtime.Status = rdr["Status"].ToString();
					overtime.ExtraHrs = rdr["ExtraHrs"].ToString();
					overtime.TotalBonus = rdr["TotalBonus"].ToString();

					return overtime;
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
		public static MedicalAllowance showMedical(string email)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;

			try
			{
				cmd = new SqlCommand("sp_MedicalAllowance", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

				cmd.ExecuteNonQuery();

				SqlDataReader rdr = cmd.ExecuteReader();
				MedicalAllowance medicalAllowance = new MedicalAllowance();
				if (rdr.Read())
				{
					medicalAllowance.EID = rdr["EID"].ToString();
					medicalAllowance.CategoryID = rdr["CategoryID"].ToString();
					medicalAllowance.MedicalID = rdr["MedicalID"].ToString();

					return medicalAllowance;
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
		public static int Logout(string email)
		{

			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_UserLogout", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
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
        public static int AdminLogout(string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("sp_AdminLogout", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
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
        public static Admin GetAdmin(string email)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("SELECT * FROM admin where admin_Email=@email AND admin_LoginStatus=1", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                

                SqlDataReader rdr = cmd.ExecuteReader();
                Admin admin = new Admin();
                if (rdr.Read())
                {
                    admin.AdminID= Convert.ToInt32(rdr["adminID"]);
                    admin.AdminEmail = rdr["admin_Email"].ToString();
                    admin.AdminName = rdr["admin_Name"].ToString();
                    admin.AdminPassword = rdr["admin_Password"].ToString();
                    admin.AdminLoginStatus= Convert.ToInt32(rdr["admin_LoginStatus"]);
					admin.ContactNo = rdr["admin_ContactNo"].ToString();

					return admin;
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

        public static List<User> GetUsers()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("SELECT * FROM employee", con);
                cmd.CommandType = System.Data.CommandType.Text;
                List <User> users= new List<User>();

                SqlDataReader rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    User user = new User();
                    user.userId = rdr["EmployeeID"].ToString();
                    user.employeeName = rdr["EmployeeName"].ToString();
                    user.employeeAddress = rdr["EmployeeAddress"].ToString();
                    user.dateOfBirth = rdr["EmployeeDOB"].ToString();
                    user.contact = rdr["Emp_ContactNo"].ToString();
                    user.payGrade = rdr["PayGrade"].ToString();
                    user.email = rdr["Emp_Email"].ToString();
                    user.password = rdr["Emp_Password"].ToString();
                    user.loginStatus = rdr["Emp_LoginStatus"].ToString();
                    users.Add(user);
                }
                rdr.Close();

                return users;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }
            finally
            {
                con.Close();
            }
        }
		public static int EmpDelete(string email)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_MasterEmployeeDelete", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
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
		public static int EmployeeInsert(string Name,string Address,string email,string contact,string dateOfBirth,string password,string payGrade)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_MasterEmployeeInsert", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = Name;
				cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = Address;
				cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 50).Value = dateOfBirth;
				cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 50).Value = contact;
				cmd.Parameters.Add("@PGrade", SqlDbType.NVarChar, 10).Value = payGrade;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
				cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = password;

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
		public static int EmployeeUpdate(string Name, string Address, string email, string contact, string dateOfBirth, string password, string payGrade)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			SqlCommand cmd;
			int result = 0;

			try
			{
				cmd = new SqlCommand("sp_MasterEmployeeUpdate", con);
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = Name;
				cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = Address;
				cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 50).Value = dateOfBirth;
				cmd.Parameters.Add("@ContactNo", SqlDbType.NVarChar, 50).Value = contact;
				cmd.Parameters.Add("@PGrade", SqlDbType.NVarChar, 10).Value = payGrade;
				cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
				cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = password;

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