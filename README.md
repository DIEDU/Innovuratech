# Innovuratech
Interview Question System Test of innovuratech.com Ahemdabad
 Project Description:
Build a web-based task manager application using ASP.NET MVC and C#. This application should allow users to perform the following tasks:

* User Registration and Authentication:

    * Users should be able to register with a username and password.

    * Implement user authentication to secure the application.


* Task Management:

    * Authenticated users should be able to create, edit, delete, and mark tasks as completed.

    * Each task should have fields like title, description, due date, and status.

* Task Filtering:

    * Users should be able to filter tasks based on their status (e.g., All, In Progress, Completed).


* User Profile:

    * Users should have a profile page displaying their username and basic information.

    * They should be able to edit their profile information.

* Dashboard:

    * Users should have a dashboard displaying their tasks, including the number of tasks completed and in progress.

Requirements:

* Use ASP.NET MVC for the web application structure.

* Implement database storage for user accounts and tasks (e.g., SQL Server, Entity Framework).

* Implement client-side validation for task creation and editing (e.g., JavaScript/jQuery).

* Use ASP.NET Identity for user registration and authentication.

* Utilize Razor views for rendering HTML.

* Implement proper routing and navigation within the application.

* Implement error handling and display meaningful error messages.

* Ensure the application is responsive and user-friendly.
=======================================================================================
 Solution:-
**Web.Config**
<connectionStrings>
		<add name="DefaultConnection" connectionString="Data Source=DESKTOP-JJDFFJA\SQLEXPRESS;Integrated Security=true;Initial Catalog=POC_DB" providerName="System.Data.SqlClient" />
	</connectionStrings>

 <system.web>
    <compilation debug="true" targetFramework="4.7.2" />
    <httpRuntime targetFramework="4.7.2" />
	  <authentication mode="Forms">
		  <forms loginUrl="~/home/Login" timeout="2880" />
	  </authentication>
	  <authorization>
		  <deny users="?" />
	  </authorization>
  </system.web>
**Model**
public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
    }
    
** Add Data Folder->** 
  public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
    

 
