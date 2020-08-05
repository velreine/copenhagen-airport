using System;
using Entity_Framework_6_Database_first.Models;

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
            //dotnet ef dbcontext Scaffold "Server=localhost,1433;Initial Catalog=copenhagen_airport;User ID=sa;Password=\!supercomplex12345;" Microsoft.EntityFrameworkCore.SqlServer -o Models

            using (var ctx = new copenhagen_airportContext())
            {
                foreach (Airport airport in ctx.Airport)
                {
                    Console.WriteLine($"IATA: {airport.Iata}, ID: {airport.Id}, Name: {airport.Name}");
                }
            }

            Console.ReadKey();


        }
    }
}
