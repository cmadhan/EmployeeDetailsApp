using EmployeeDetailsData.EmployeeDetails;
using System.Collections.Generic;
using System.Data.Entity;

namespace EmployeeDetailsData.Initializer
{
    public class EmployeeDbInitializer : DropCreateDatabaseIfModelChanges<EmployeeDbContext>
    {
        protected override void Seed(EmployeeDbContext context)
        {
            IList<EmployeeDetailsEF> employees = new List<EmployeeDetailsEF>
            {
                new EmployeeDetailsEF { FullName = "FN1 LN1", Address = "123 Street", PhoneNumber="123-456-7890", Position = "Employee" },
                new EmployeeDetailsEF { FullName = "FN2 LN2", Address = "456 Street", PhoneNumber="123-456-7891", Position = "Employee" },
                new EmployeeDetailsEF { FullName = "FN3 LN3", Address = "789 Street", PhoneNumber="123-456-7892", Position = "Manager" },
                new EmployeeDetailsEF { FullName = "FN4 LN4", Address = "011 Street", PhoneNumber="123-456-7893", Position = "Senior Employee" },
                new EmployeeDetailsEF { FullName = "FN5 LN5", Address = "012 Street", PhoneNumber="123-456-7894", Position = "Senior Manager" }
            };

            context.EmployeeDetails.AddRange(employees);
            context.SaveChanges();
        }
    }
}
