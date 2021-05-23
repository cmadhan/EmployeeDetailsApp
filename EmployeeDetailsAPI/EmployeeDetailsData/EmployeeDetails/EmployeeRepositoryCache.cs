using System.Collections.Generic;
using System.Linq;

namespace EmployeeDetailsData.EmployeeDetails
{
    public class EmployeeRepositoryCache
    {
        private IEmployeeRepository employeeRepository { get; }
        private IDictionary<int, EmployeeDetailsEF> allEmployees;
        public EmployeeRepositoryCache(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;           
        }

        /// <summary>
        /// This method returns an in-memory copy of Employee Data. This method would not return
        /// updated data. If you need up to date / updated data  from the database make sure to hit
        /// the refresh method before hitting this method.
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, EmployeeDetailsEF> GetEmployeeLookupByEmployeeId()
        {
            if(allEmployees == null)
            {
                allEmployees = employeeRepository.QueryAll().ToDictionary(e => e.EmployeeId);
            }

            return allEmployees;
        }

       public void Refresh()
       {
            if(allEmployees != null)
            {
                allEmployees.Clear();
            }            
            allEmployees = employeeRepository.QueryAll().ToDictionary(e => e.EmployeeId);
       }
    }
}
