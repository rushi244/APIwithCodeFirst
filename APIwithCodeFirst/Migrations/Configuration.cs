namespace APIwithCodeFirst.Migrations
{
    using APIwithCodeFirst.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<APIwithCodeFirst.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(APIwithCodeFirst.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var lstEmployee = new List<Employee>
            {
                new Employee{FirstName="Rushikesh",LastName="Bhor",Gender="Male",City="Mumbai"},
                new Employee{FirstName="Rahul",LastName="Padol",Gender="Male",City="Mumbai"},
                new Employee{FirstName="Poonam",LastName="Gaikwad",Gender="Female",City="Mumbai"},
                new Employee{FirstName="Shruti",LastName="Seth",Gender="Female",City="Mumbai"},
                new Employee{FirstName="Ankita",LastName="Nimbalkar",Gender="Female",City="Mumbai"}
            };
            lstEmployee.ForEach(e => context.Employees.AddOrUpdate(e));
            context.SaveChanges();
        }
    }
}
