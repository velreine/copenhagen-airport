using System;

namespace Entity_Framework_6_Database_first
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            // Package manager console (does not work on Mac)
            //Scaffold-DbContext "Server=.\SQLExpress;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            
            // Same command with EF Core Tools CLI
            //dotnet ef dbcontext Scaffold "Server=<servername>,1433;Initial Catalog=<dbName>;Persist Security Info=False;User ID=<userID>;Password=<password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"Microsoft.EntityFrameworkCore.SqlServer -o <directory name>
            
        }
    }
}
