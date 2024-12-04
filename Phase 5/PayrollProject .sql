
Create Database PayrollManagement
go
use PayrollManagement
go

/*Drop Table Department
go
Drop Table Company
go
Drop Table Employee
go
Drop Table BasicPay
go
Drop Table Attendance
go
Drop Table MedicalCategory
go
Drop Table MedicalAllowance
go
Drop Table Overtime
go
Drop Table Admin
go
Drop Procedure sp_ShowDepartment
go
Drop Procedure sp_ShowCompany
go
Drop Procedure sp_ShowEmployee
go
Drop Procedure sp_ShowBasicPay
go
Drop Procedure sp_ShowAttendance
go
Drop Procedure sp_ShowMedicalCategory
go
Drop Procedure sp_MedicalAllowance
go
Drop Procedure sp_ShowOvertime
go
Drop Procedure sp_ShowLoginInfo
go
Drop Procedure sp_UserLogin
go
Drop Procedure sp_UserLogout
go
Drop Procedure sp_MasterEmployeeInsertDeleteUpdate
go
Drop Procedure sp_SignUp
go
Drop Proc sp_AdminLogin
go
Drop Proc sp_AdminLogout
go
Drop Proc sp_AdminSignUp
go*/


---------------------------------------------------
Create Table Department(
	DeptNo int NOT NULL,--	NOT NULL UNIQUE,
	DeptName varchar(20),	
)
go
---------------------------------------------------
Create Table Company (
	CompanyID int identity (1,1) NOT NULL,
	CompanyName varchar(20),
	CompanyAddress varchar(100),
	Comp_ContactNo varchar(20),
	ExistingDepts int,
)
go
-----------------------------------------------------------------
Create Table Employee(
	EmployeeID int identity (10,10) Not NULL,-- NOT NULL UNIQUE,
	EmployeeName varchar(20),
	EmployeeAddress varchar(50),
	EmployeeDOB Date,
	Emp_ContactNo varchar(20),
	PayGrade int,
	Emp_Email varchar(50) Unique NOT NULL,
	Emp_Password varchar(50),
	Emp_LoginStatus char(1) Default '0', Check (Emp_LoginStatus ='1' or Emp_LoginStatus='0')
)
go
-- Adding a new column in Employee Table
--Alter Table Employee Add Emp_Email varchar(30)
--go
--Alter Table Employee Add Constraint UNIQUE_EMAIL Unique(Emp_Email)
--go

-------------------------------------------------------------------
Create Table Admin(
	adminID int identity (0,5) Primary Key Not Null,
	admin_Email varchar(30) Unique NOT NULL,
	admin_Name varchar(100),
	admin_Password varchar(30),
	admin_LoginStatus char(1) Default '0', Check (admin_LoginStatus ='1' or admin_LoginStatus = '0'),
	admin_ContactNo varchar(25),
)
go
-------------------------------------------------------------------
Create Table BasicPay(	
	Grades int NOT NULL,--NOT NULL UNIQUE,
	Pay int,
)
go
------------------------------------------------------------------


Create Table Attendance(
	EID int,
	Status char(1),
	PresenceDate Date,
)
go
---------------------------------------------------------------------

Create Table MedicalCategory(
	CategoryID int identity (100,50) NOT NULL,-- NOT NULL UNIQUE,
	Category char(1),
	Price int,
)
go
--------------------------------------------------------


Create Table MedicalAllowance(

	MedicalID int identity (5,5) NOT NULL,-- NOT NULL UNIQUE,
	CategoryID int,
	EID int,
	
)
go
----------------------------------------------------------------

Create Table Overtime(
	EID int,
	Status char(1),
	ExtraHrs int,
	TotalBonus int,
)
go
---------------------------------------------------------------------------
--A FOREIGN KEY constraint does not have to be linked only to a PRIMARY KEY 
--constraint in another table; it can also be defined to reference
-- the columns of a UNIQUE constraint in another table

--------------------------------------------------------------------------------------------------------------------
Alter Table Company Alter Column CompanyID int NOT NULL
go
Alter Table Company Add Constraint PK_CompanyID Primary Key(CompanyID)
go
--Alter Table Company Add Constraint FK_ExistingDepts Foreign Key(ExistingDepts) References Department(DeptNo)
--On Delete Set NULL On Update Cascade
--go
--Alter Table Company Drop Constraint FK_ExistingDepts
--go
--------------------------------------------------------------------------------------------------------------------


Alter Table BasicPay Alter Column Grades int NOT NULL
go
Alter Table BasicPay Add Constraint PK_Grades Primary Key(Grades)
go

--------------------------------------------------------------------------------------------------------------------

Alter Table Employee Alter Column EmployeeID int NOT NULL
go
Alter Table Employee Add Constraint PK_EmployeeID Primary Key(EmployeeID)
go

Alter Table Employee Add Constraint PK_PayGrade Foreign Key(PayGrade) references BasicPay(Grades)
On Delete cascade On Update cascade
go
--------------------------------------------------------------------------------------------------------------------






Alter Table Department Alter Column DeptNo int NOT NULL
go
Alter Table Department Add Constraint PK_DeptNo Primary Key(DeptNo)
go

--------------------------------------------------------------------------------------------------------------------



Alter Table Attendance Add Constraint FK_EID Foreign Key(EID) References Employee(EmployeeID)
On Delete Cascade On Update Cascade
go
Alter Table Attendance Add Constraint Check_Status_Attendance Check(Status in ('A','P','L'))
go
Alter Table Attendance Add Constraint Default_Attendance Default 'P' for Status
go
--------------------------------------------------------------------------------------------------------------------



Alter Table MedicalCategory Alter Column CategoryID int NOT NULL
go
Alter Table MedicalCategory Add Constraint PK_CategoryID Primary Key(CategoryID)
go
Alter Table MedicalCategory Add Constraint Check_Med_Category Check(Category in('A','B'))
go
--------------------------------------------------------------------------------------------------------------------



Alter Table MedicalAllowance Alter Column MedicalID int NOT NULL
go
Alter Table MedicalAllowance Add Constraint PK_MedicalID Primary Key(MedicalID)
go
Alter Table MedicalAllowance Add Constraint FK_MedicalCategoryID Foreign Key(CategoryID) References MedicalCategory(CategoryID)
On Delete NO Action On Update NO Action
go
Alter Table MedicalAllowance Add Constraint FK_MedicalEID Foreign Key(EID) References Employee(EmployeeID)
ON Delete Cascade On Update Cascade
go
--------------------------------------------------------------------------------------------------------------------



Alter Table Overtime Add Constraint Check_Status_Overtime Check(Status in ('Y','N')) --Y for Yes, N for No
go
--------------------------------------------------------------------------------------------------------------------


------Inserting some rows---------

Insert Into Admin values
--(ID,Email,Name,Pass,LoginStatus,PhoneNo)
('admin1@gmail.com','Saad Farooq','bigfastboi123','0',0313232312),
('admin2@gmail.com','Saddam Hussain','smolfastboi123','0',0313332312),
('admin3@gmail.com','Qabaacha','qustuntuniya','0',0313232322)
go
---------------------------------------------------------
Insert Into Department values
--(DeptNo, DeptName)
(10,'Human Resources'),
(20,'Sales'),
(30,'Engineering'),
(40,'Public Relations')
go

-----------------------------------------------------------
Insert Into Company values
--(Id, Name, Address, Contact No,Existing Depts)
('NetSol','Ferozepur Road, Lahore',03130011771,3),
('Hooli','Street Walton, Silicon Valley, LA',02210011771,5),
('Pied Piper','Hendricks Street, Silicon Valley,LA',03330011771,2)
go
------------------------------------------------------
Insert Into BasicPay values
--(Grades, Pay)
(7,15000),
(8,20000),
(9,25000),
(10,30000),
(11,35000),
(12,40000),
(15,45000),
(16,50000),
(17,55000),
(18,60000),
(19,65000),
(20,70000)
go
-------------------------------------------------------
Insert Into Employee values
--(ID, Name, Address, DOB, ContactNo, Paygrade, Email,pass,login Status)
('Ahmad Sheikhzada','9211 home, Ghaazi Colony, Lahore','1994-04-20',03311234567,15,'abcd@gmail.com','mankindangel',0),
('Hania Amir','9215 home, Maraaasi Colony, Lahore','1992-01-01',03007860122,7,'efgh@gmail.com','andaywalaburger',0),
('Noyan Aziz','123 home, DHA EME, Lahore','1998-10-20',03331111111,10,'ijk@gmail.com','araybhaibhai',0)
go
----------------------------------------------------
Insert Into Attendance values
--(EID, Status, PresenceDate)
(10,'A','2019-03-24')
go
----------------------------------------------------

Insert Into MedicalCategory values
--(CatID, Cat, Price)
('A',10000),
('B',5000)
go
------------------------------------------------------

Insert Into MedicalAllowance values 
--(MedID, CatID, EID)
(100,10)
go
---------------------------------------------------

Insert Into Overtime values
--(EID, Status, ExtraHrs, Bonus)
(120,'Y',10,1000),
(110,'N',1,100)

go
-------------------------------------------------


--------------------------------------------------
Select* From Department
Select* From Company
Select* From Employee
Select* From BasicPay
Select* From Attendance
Select* From MedicalCategory
Select* From MedicalAllowance
Select* From Overtime
Select* From Admin 
go
---------------------------------------------------------


--Making Stored Procedures--
----------------------------------------------------

-----------------------------------------------------
--Drop Procedure sp_ShowDepartment
go
Create Procedure sp_ShowDepartment (@Deptno int) --Takes DeptNo and returns shows it's information
As
Begin
	Select Department.DeptNo, Department.DeptName
	From Department
	Where Department.DeptNo=@Deptno
End
go

--Execute sp_ShowDepartment @Deptno=30
go
-----------------------------------------------------
--Drop Procedure sp_ShowCompany
go
Create Procedure sp_ShowCompany (@CompID int)
As
Begin

	Select * From Company
	Where CompanyID=@CompID
	
End
go

--Execute sp_ShowCompany @CompID=321
go

------------------------------------------------------
--Drop Procedure sp_ShowEmployee
go
Create Procedure sp_ShowEmployee (@EmpEmail varchar(50))
As
Begin
	Select*From Employee
	Where Emp_Email=@EmpEmail
End
go

--Execute sp_ShowEmployee @EmpID=120
go
-----------------------------------------------------
--Drop Procedure sp_ShowBasicPay
go
Create Procedure sp_ShowBasicPay (@Grade int)
As
Begin
	Select*From BasicPay
	Where @Grade=Grades
End
go

--Execute sp_ShowBasicPay @Grade=19
go
------------------------------------------------------
--Drop Procedure sp_ShowAttendance
go
Create Procedure sp_ShowAttendance (@email varchar(50))
As
Begin
	Select*From Attendance
	Where EID=(select Employee.EmployeeID from Employee where Emp_Email=@email)
End
go

--Execute sp_ShowAttendance 100
go
-------------------------------------------------------
--Drop Procedure sp_ShowMedicalCategory
go
--Create Procedure at first... then Alter
Create Procedure sp_ShowMedicalCategory (@CatID int)
As 
Begin
	Select Distinct *From MedicalCategory
	Where CategoryID=@CatID
End
go

--Exec sp_ShowMedicalCategory 2000
go
-------------------------------------------------------
--Drop Procedure sp_MedicalAllowance
go
Create Procedure sp_MedicalAllowance (@email varchar(50))
As
Begin
	Select*From MedicalAllowance
	Where EID=(select Employee.EmployeeID from Employee where Emp_Email=@email)
End
go

--Exec sp_MedicalAllowance 2200
go
------------------------------------------------------
--Drop Procedure sp_ShowOvertime
go
Create Procedure sp_ShowOvertime (@email varchar(20))
As 
Begin
	Select*From Overtime 
	Where EID=(select Employee.EmployeeID from Employee where Emp_Email=@email)
End
go
--Exec sp_ShowOvertime 120
go
------------------------------------------------------
--Drop Procedure sp_ShowLoginInfo
go

Create Procedure sp_ShowLoginInfo (@Email varchar(20))
As
Begin
	Select Distinct *From Employee
	Where Employee.Emp_Email=@Email
End
go
Exec sp_ShowLoginInfo 'abcd@gmail.com'
go
------------------------------------------------------
--Drop Procedure sp_UserLogin
go
Create Procedure sp_UserLogin (@Email varchar(50), @Pass varchar(50), @output int output)
As
Begin
	If Exists(Select*From Employee Where @Email=Employee.Emp_Email AND @Pass=Employee.Emp_Password)
		Begin
					set @output=1
					Select @Email=Employee.Emp_Email From Employee
					Where (@Email=Emp_Email AND @Pass=Employee.Emp_Password)
					Update Employee Set Emp_LoginStatus ='1' Where Emp_Email=@Email
					Print 'Login Successful'
				
		End
	Else
		Begin
			set @output=0
			Print 'Login Failed: Email Or Password doesnt match'
		End
End
go
declare @out int
Exec sp_UserLogin 'abcd@gmail.com', 'mankindangel',@output=@out out
go

---------------------------------------------------------------------
--Drop Procedure sp_UserLogout
go
Create Procedure sp_UserLogout (@Email varchar (50),@output int output)
As
Begin
	If Exists(Select*From Employee Where @Email=Employee.Emp_Email)
		Begin
			Update Employee Set Emp_LoginStatus='0' Where Employee.Emp_Email=@Email
			set @output=1
			Print 'Logout of '+@Email+' was successful!'
		End
	Else
		Begin
			set @output=0
			Print 'Logout Failed: Email was not found!'
		End
End
go
declare @out int
Exec sp_UserLogout @Email='ijk@gmail.com', @output=@out out
go

-----------------------------------------------------------------------
--Drop Procedure sp_MasterEmployeeInsertDeleteUpdate
go
Create Procedure sp_MasterEmployeeInsert(

	@Name varchar(100),
	@Address varchar(500),
	@DOB Date,
	@ContactNo varchar(20),
	@PGrade int,
	@Email varchar(50),
	@pass varchar(50),
	@output int output
)
As
Begin
	if exists(select * from Employee where Emp_Email=@Email)
	begin
		set @output=0
	end
	else 
	begin
		
		Insert Into Employee (EmployeeName,EmployeeAddress,EmployeeDOB,Emp_ContactNo,PayGrade,Emp_Email,Emp_Password,Emp_LoginStatus) values
		(@Name,@Address,@DOB,@ContactNo,@PGrade,@Email,@pass,0)
		set @output=1
		Print 'Insertion of '+@Name+' successful!'
	END
End
declare @out int
exec sp_MasterEmployeeInsert @Name='Noyan Aziz', @Address='120 B dha eme', @DOB='1999-04-20',@ContactNo='033333333',@pass='12345678',@Email ='noyan@gmail.com',@PGrade=14,@output=@out out

Create Procedure sp_MasterEmployeeDelete
(	
@Email varchar(50),
@output int output)
AS
Begin
	if exists(select * From Employee Where Emp_Email=@Email)
	Begin
		delete from Employee Where Emp_Email=@Email
		set @output=1
		Print 'Deletion successful!'
	end
	else 
	begin
		set @output=0
	end
End
go
--drop procedure sp_MasterEmployeeUpdate
Create Procedure sp_MasterEmployeeUpdate
(
	@Name varchar(100),
	@Address varchar(500),
	@DOB Date,
	@ContactNo varchar(20),
	@PGrade int,
	@Email varchar(50),
	@pass varchar(50),
	@output int output
)
As
Begin
	if exists(select * from Employee where Emp_Email=@Email)
	begin
		update Employee set EmployeeName=@Name, EmployeeAddress=@Address,EmployeeDOB=@DOB,Emp_ContactNo=@ContactNo,PayGrade=@PGrade,Emp_Password=@pass 
		where Emp_Email=@Email
	
		Print 'Insertion of '+@Name+' successful!'
			set @output=1
	end
	else 
	begin
		set @output=0
	END
End

declare @out int
exec sp_MasterEmployeeUpdate @Name='Noyan Aziz', @Address='120 B dha eme', @DOB='1999-04-20',@ContactNo='033333333',@pass='12345678',@Email ='noyan@gmail.com',@PGrade=14,@output=@out out

select* from Employee
go
--Exec sp_MasterEmployeeInsertDeleteUpdate @ID=140,@Name='Umar Azam',@Address='212-H, Bahria Town, Lahore',@DOB='1998-06-02',@ContactNo=31801,@PGrade=20,@Email='umarazam497@gmail.com',@StatementType='Insert'
go
--Exec sp_MasterEmployeeInsertDeleteUpdate @ID=100,@Name='Umar Azam',@Address='212-H, Bahria Town, Lahore',@DOB='1998-06-02',@ContactNo=31801,@PGrade=20,@Email='umarazam497@gmail.com',@StatementType='Delete'
go
--Exec sp_MasterEmployeeInsertDeleteUpdate @ID=100,@Name='Umar Azam',@Address='212-H, Bahria Town, Lahore',@DOB='1998-06-02',@ContactNo=31801,@PGrade=20,@Email='umarazam497@gmail.com',@StatementType='Update'
go
--------------------------------------------------------------------------------------------------------
--Drop Procedure sp_SignUp
go
Create Procedure sp_SignUp(
	@Name varchar(50),
	@Email varchar (50),
	@Address varchar (250),
	@ContactNo Numeric,
	@Password varchar(50),
	@DOB Date,
	@output int output
)
As
Begin
	If Exists(Select*From Employee Where Emp_Email=@Email)
		Begin
			Print 'Error! The Email'+@Email+' is already taken! Use another one!'
			set @output=0
		End
	Else
		Begin
			
			
			Insert Into  Employee (EmployeeName,EmployeeDOB,Emp_ContactNo,Emp_Email,EmployeeAddress,Emp_Password,Emp_LoginStatus) values (@Name,@DOB,@ContactNo,@Email,@Address,@Password,'1')
			set @output=1
			
			
			print 'SignUp successful of'+@Name
		End
End
go
declare @out int
Exec sp_SignUp @Name='Gilfoyle',@Email='CanadianNibba@hotmail.com',@Address='111-A, Suite city, SV',@ContactNo=03331114555,@Password='DineshSucksAtCoding',@DOB='1990-02-14',@output=@out out

-----------------------------------------------------------------------
--Drop Proc sp_AdminLogin
select* from admin
select * from Employee


go
create Procedure sp_AdminLogin (@Email varchar(50),@Pass varchar(50),@output int output)
As 
Begin
	
	If Exists(Select*From Admin Where @Email=Admin.admin_Email)
		Begin
			Select @Email=Admin.admin_Email From Admin
			Where (@Email=admin_Email AND @Pass=Admin.admin_Password)
			Update Admin Set admin_LoginStatus ='1' Where admin_Email=@Email
			SET @output=1
			Print 'Admin Login Successful'
		End
	Else
		Begin
			SET @output=0
			Print 'Login Failed: Email or Password doesnt match'
		End
End
declare @output44 int 
Exec sp_AdminLogin 'admin1@gmail.com','bigfastboi123',@output44 output
go

Select * From Admin

--------------------------------------------------------------------------
--Drop Proc sp_AdminLogout
go
create Procedure sp_AdminLogout (@Email varchar(50),@output int output)
As
Begin
	If Exists(Select*From Admin Where @Email=admin_Email)
		Begin
			Update Admin Set Admin.admin_LoginStatus='0' Where Admin.admin_Email=@Email
			Print 'Logout of '+@Email+' was successful!'
			SET @output=1
		End
	Else
		Begin
			Print 'Logout Failed: Email was not found!'
			SET @output=0
		End
End

Exec sp_AdminLogout 'admin1@gmail.com'

--Select * from Admin

-----------------------------------------------------------------------
--Drop Proc sp_AdminSignUp
go
Create Procedure sp_AdminSignUp(
	@Name varchar(100),
	@Email varchar(100),
	@Password varchar(100),
	@Status char(1),
	@Phone varchar(50)
)
As
Begin
	If Exists(Select*From Admin Where @Email=Admin.admin_Email)
		Begin
			Print 'Error! The Email '+@Email+' is already taken! Use another one!'
		End
	Else
		Begin
			
			
			Insert Into  Admin (admin_Name,admin_Email,admin_Password,admin_LoginStatus,admin_ContactNo) values (@Name,@Email,@Password,@Status,@Phone)			
			print 'SignUp successful of '+@Name
		End
End


Exec sp_AdminSignUp 'Ali Zafar','naya_admin2@gmail.com','singerfastboi123','1','03134422777'
go
--Select * From Admin
go
---------------------------------------------------------------------------------------------

