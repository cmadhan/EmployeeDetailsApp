using EmployeeDetailsData.EmployeeDetails;
using EmployeeDetailsData.Initializer;
using System;
using System.Data.Entity;

namespace EmployeeDetailsData
{
    public class EmployeeDbContext : DbContext, IDisposable
    {
        public EmployeeDbContext(string connectionStringName) : base(connectionStringName)
        {
            
        }

        public DbSet<EmployeeDetailsEF> EmployeeDetails { get; set; }
        public void Dispose()
        {
            
        }
    }
}
