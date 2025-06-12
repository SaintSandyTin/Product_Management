Product_Management

An ASP.NET Core MVC web application using Dapper for database operations.

---

Getting Started

Prerequisites

Make sure you have the following installed on your machine:

- .NET 8.0 SDK : https://dotnet.microsoft.com/en-us/download
- SQL Server or any compatible database: https://www.microsoft.com/en-us/sql-server
- Git: https://git-scm.com/

Installation

1. Clone the repository:

git clone https://github.com/SaintSandyTin/Product_Management.git
cd your-repo

2. Restore NuGet packages:

dotnet restore

3. Update your database connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}

---

Running the Project

Run the application with:

dotnet run

Open your browser and navigate to:

https://localhost:7011


---

Project Structure

- Controllers/ - MVC controllers handling HTTP requests
- Views/ - Razor views for UI
- Models/ - Data models
- Repositories/ - Dapper data access classes and SQL queries

---

SQL Query for create "Product" table

create table Product (
	product_id INT IDENTITY (1, 1) PRIMARY KEY,
	product_name varchar(255) NOT NULL,
	product_desc varchar(500),
	product_price decimal,
	createdDate dateTime NOT NULL
)
