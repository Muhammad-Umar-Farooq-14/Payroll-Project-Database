using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inlab2.Models
{
	public class User
	{
		public string userId;
		public string employeeName;
		public string employeeAddress;
		public string dateOfBirth;
		public string contact;
		public string payGrade;
		public string email;
		public string password;
		public string loginStatus;
	}
	public class Attendance
	{
		public string EmpId;
		public string Status;
		public string PresenceDate;
	}
	public class Overtime
	{
		public string EID;
		public string Status;
		public string ExtraHrs;
		public string TotalBonus;
	}
	public class MedicalAllowance
	{
		public string EID;
		public string CategoryID;
		public string MedicalID;
	}
}