using System.Linq;

namespace EmployeeDetailsData.EmployeeDetails
{
    public interface IEmployeeRepository
    {
        IQueryable<EmployeeDetailsEF> QueryAll();

        void Upsert(EmployeeDetailsEF employeeDetail);
        void Delete(int employeeId);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext context { get; }
        public EmployeeRepository(EmployeeDbContext context)
        {
            this.context = context;
        }                

        public IQueryable<EmployeeDetailsEF> QueryAll()
        {
            return context.EmployeeDetails;
        }

        public void Upsert(EmployeeDetailsEF employeeDetail)
        {
            var employee = QueryAll().FirstOrDefault(e => e.EmployeeId == employeeDetail.EmployeeId);
            if(employee == null)
            {
                context.EmployeeDetails.Add(employeeDetail);
            }
            else
            {
                employee.FullName = employeeDetail.FullName;
                employee.Address = employeeDetail.Address;
                employee.Position = employeeDetail.Position;
                employee.PhoneNumber = employeeDetail.PhoneNumber;
            }

            context.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = QueryAll().First(e => e.EmployeeId == employeeId);
            context.EmployeeDetails.Remove(employee);
            context.SaveChanges();
        }
    }
}
