using System.Collections.Generic;
using System.Linq;

namespace EmployeeDetailsData.EmployeeDetails
{
    public class EmployeeService
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IList<EmployeeDetailsEF> GetAllEmployees()
        {
            return employeeRepository.QueryAll().ToList();
        }
        
        public void AddOrUpdateEmployee(EmployeeDetailsEF employeeDetails)
        {
            employeeRepository.Upsert(employeeDetails);
        }

        public void Delete(int employeeId)
        {
            employeeRepository.Delete(employeeId);
        }
    }
}
