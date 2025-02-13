using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tracker.WebAPIClient;

namespace DataModel
{
    internal class CustomerDbContext
    {
        public class CustomerDBContext : DbContext
        {
            public DbSet<Customer> Customers { get; set; }

            public CustomerDBContext() { }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var myconnectionstring = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=CustomerCoreDB";
                optionsBuilder.UseSqlServer(myconnectionstring)
                    .LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        LogLevel.Information);

                // Commented out as per the request
                /*
                ActivityAPIClient.Track(
                    StudentID: "s00236260",
                    StudentName: "James McCafferty Devers",
                    activityName: "Rad302 Week 3 Lab 1",
                    Task: "Creating Customer DB Schema"
                );
                */
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                ActivityAPIClient.Track(
                   StudentID: "s00236260",
                   StudentName: "James McCafferty Devers",
                   activityName: "Rad302 Week 3 Lab 1",
                   Task: "Creating Customer DB Schema"
               );

                modelBuilder.Entity<Customer>().HasData(
                    new Customer { ID = 1, Name = "Patricia McKenna", Address = "8 Johnstown Road, Cork", CreditRating = 200.00f },
                    new Customer { ID = 2, Name = "Helen Bennett", Address = "Garden House Crowther Way, Dublin", CreditRating = 400.00f },
                    new Customer { ID = 3, Name = "Yoshi Tanami", Address = "1900 Oak St., Vancouver", CreditRating = 2000.00f },
                    new Customer { ID = 4, Name = "John Steel", Address = "12 Orchestra Terrace, Dublin 20", CreditRating = 800.00f },
                    new Customer { ID = 5, Name = "Catherine Dewey", Address = "Rue Joseph-Bens 532, Brussels", CreditRating = 600.00f }
                );

                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
