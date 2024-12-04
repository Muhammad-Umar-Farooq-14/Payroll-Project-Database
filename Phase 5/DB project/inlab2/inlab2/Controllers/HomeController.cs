using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inlab2.Models;

namespace inlab2.Controllers
{
	public class HomeController : Controller
	{

		public ActionResult Login()
		{
			if (Session["email"] != null)
			{
				return RedirectToAction("homePage", new { email = Session["email"].ToString() });
			}
			return View();
		}
        public ActionResult AdminLogin()
        {
            if (Session["email"] != null)
            {
                return RedirectToAction("homePage", new { email = Session["email"].ToString() });
            }
            return View();
        }
		public ActionResult Signup()
		{

			return View();
		}
		public ActionResult Index()
		{

			return View();
		}
		public ActionResult Contact()
		{

			return View();
		}
		public ActionResult About()
		{
			return View();
		}
		public ActionResult EmpInsert()
		{
			if (Session["Adminemail"] != null)
			{
				return View();
			}
			if (Session["email"] != null)
			{
				return RedirectToAction("homePage", new { email = Session["email"].ToString() });
			}
			String data = "Cannot access Insertion";
			return View("Login", (object)data);
		}
		public ActionResult EmpUpdate(String email)
		{
			if (Session["Adminemail"] != null)
			{
				User user = CRUD.getuserinfo(email);
				return View(user);
				
			}
			if (Session["email"] != null)
			{
				return RedirectToAction("homePage", new { email = Session["email"].ToString() });
			}
			String data = "Cannot access Insertion";
			return View("Login", (object)data);
		}
		public ActionResult _Home()
		{
			if (Session["Adminemail"] != null)
			{
				return RedirectToAction("AdminhomePage", new { email = Session["Adminemail"].ToString() });
			}
			if (Session["email"] != null)
			{
				return RedirectToAction("homePage", new { email = Session["email"].ToString() });
			}
			String data = "Cannot access Home Page";
			return View("Login", (object)data);
		}
		public ActionResult RegisterAction(String Name, String Address, String email, String contact, String dateOfBirth, String password2)
		{
			int result = CRUD.Signup(Name, Address, email, contact, dateOfBirth, password2);

			if (result == -1)
			{
				String data = "Something went wrong while connecting with the database.";
				return View("Signup", (object)data);
			}
			else if (result == 0)
			{

				String data = "Email already exists";
				return View("Signup", (object)data);
			}
			else
			{
				String data = "Sign Up was successful";
				return View("Signup", (object)data);
			}



		}
		public ActionResult Attendance(String email)
		{
			Attendance attendance = CRUD.showAttendance(email);
			if (attendance == null)
			{
				return RedirectToAction("homePage", new { email = email });
			}
			return View(attendance);
		}
		public ActionResult Overtime(String email)
		{
			Overtime overtime  = CRUD.showOvertime(email);
			if (overtime == null)
			{
				return RedirectToAction("homePage", new { email = email });
			}
			return View(overtime);
		}
		public ActionResult MedicalAllowance(String email)
		{
			MedicalAllowance medicalAllowance = CRUD.showMedical(email);
			if (medicalAllowance == null)
			{
				return RedirectToAction("homePage", new { email = email });
			}
			return View(medicalAllowance);
		}
		public ActionResult authetnticateLogin(String email, String password)
		{
			int result = CRUD.Login(email, password);

			if (result == -1)
			{
				String data = "Something went wrong while connecting with the database.";
				return View("Login", (object)data);
			}
			else if (result == 0)
			{

				String data = "Incorrect Credentials";
				return View("Login", (object)data);
			}

			else
			{
				Session["email"] = email;
				return RedirectToAction("homePage",new { email=email });
			}
		}
        public ActionResult authetnticateAdminLogin(String email, String password)
        {
            int result = CRUD.AdminLogin(email, password);

            if (result == -1)
            {
                String data = "Something went wrong while connecting with the database.";
                return View("AdminLogin", (object)data);
            }
            else if (result == 0)
            {

                String data = "Incorrect Credentials";
                return View("AdminLogin", (object)data);
            }

            else
            {
                Session["Adminemail"] = email;
                return RedirectToAction("Adminhomepage", new { email = @email });
            }
        }

		public ActionResult homePage(String email)
		{
			User user = CRUD.getuserinfo(email);
			
			
			
			if (user == null)
			{
				String data = "user is null";
				return View("Login", (object)data);
			}
			if (Session["email"] == null)
			{
				String data = "userid is null in session";
				return View("Login", (object)data);
			}
			Console.Write(user);
			return View(user);
			
		}
        public ActionResult Adminhomepage(String email)
        {
			Admin admin= CRUD.GetAdmin(email);

            if (admin == null)
            {
                String data = "user is null";
                return View("Login", (object)data);
            }
            if (Session["Adminemail"] == null)
            {
                String data = "userid is null in session";
                return View("Login", (object)data);
            }
            Console.Write(admin);
            return View(admin);
        }
        public ActionResult ViewUsers()
        {
            if (Session["Adminemail"] != null)
            { 
                List <User> users= new List<User>();
                users = CRUD.GetUsers();
                return View("ViewUsers", users);
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

        }

		public ActionResult Logout()
		{
			if (Session["Adminemail"] != null)
			{
				return RedirectToAction("AdminLogout", new { email = Session["Adminemail"].ToString() });
			}
			if (Session["email"] != null)
			{
				int result = CRUD.Logout(Session["email"].ToString());

				if (result == -1)
				{
					return RedirectToAction("homePage", new { email = Session["email"].ToString() });
				}
				else if (result == 0)
				{

					return RedirectToAction("homePage", new { email = Session["email"].ToString() });
				}

				else
				{
					Session["email"] = null;
					return RedirectToAction("Login");
				}
			}

			String data = "No user logged in";
			return View("Login", (object)data);
		}
        public ActionResult AdminLogout(String email)
        {
            if (Session["Adminemail"] != null)
            {
                int result = CRUD.AdminLogout(email);

                if (result == -1)
                {
                    return RedirectToAction("Adminhomepage", new { email = Session["Adminemail"].ToString() });
                }
                else if (result == 0)
                {

                    return RedirectToAction("Adminhomepage", new { email = Session["Adminemail"].ToString() });
                }

                else
                {
                    Session["Adminemail"] = null;
                    return RedirectToAction("Login");
                }
            }

            String data = "No user logged in";
            return View("Login", (object)data);
        }
		public ActionResult EmployeeDelete(String email)
		{
			if (Session["Adminemail"] != null)
			{
				int result = CRUD.EmpDelete(email);

				if (result == -1)
				{
					return RedirectToAction("ViewUsers");
				}
				else if (result == 0)
				{

					return RedirectToAction("ViewUsers");
				}

				else
				{
					return RedirectToAction("ViewUsers");
				}
			}

			String data = "No user logged in";
			return View("Login", (object)data);
		}
		public ActionResult EmployeeInsert(String Name, String Address, String email, String contact, String dateOfBirth, String password,String payGrade)
		{
			if (Session["Adminemail"] != null)
			{
				int result = CRUD.EmployeeInsert(Name,Address,email,contact,dateOfBirth,password,payGrade);

				if (result == -1)
				{
					return View("ViewUsers");
				}
				else if (result == 0)
				{
					return View("ViewUsers");
				}
				
				else
				{
					return RedirectToAction("ViewUsers");
				}
			}

			String data = "No user logged in";
			return View("Login", (object)data);
		}
		public ActionResult EmployeeUpdate(String Name, String Address,String email, String contact, String dateOfBirth, String password, String payGrade)
		{
			if (Session["Adminemail"] != null)
			{
				int result = CRUD.EmployeeUpdate(Name, Address, email, contact, dateOfBirth, password, payGrade);

				if (result == -1)
				{
					String data = "No connection";
					return View("Login", (object)data);
				}
				else if (result == 0)
				{
					String data = "NOT updated";
					return View("Login", (object)data);
				}

				else
				{
					return RedirectToAction("ViewUsers");
				}
			}
			else
			{
				String data = "No user logged in";
				return View("Login", (object)data);
			}
		}
	}
}