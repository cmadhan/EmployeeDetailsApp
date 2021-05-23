using EmployeeDetailsAPI.EmployeeLoader;
using EmployeeDetailsAPI.Models;
using EmployeeDetailsData;
using EmployeeDetailsData.EmployeeDetails;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EmployeeDetailsAPI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmployeesController : BaseController
    {
        [HttpGet]
        [ActionName("GetAllEmployees")]
        public IHttpActionResult GetEmployees()
        {
           using(var ctx = new EmployeeDbContext(EmployeeDbConnectionString))
           {
                try
                {
                    var employeeRepository = new EmployeeRepository(ctx);
                    var employeeSvc = new EmployeeService(employeeRepository);
                    var allEmployees = employeeSvc.GetAllEmployees();
                    var employeeLoader = new LoadEmployee();
                    var mapper = employeeLoader.CreateEFToDTOMapper();
                    return Ok(allEmployees.Select(employee => mapper.Map<EmployeeDetailsEF, EmployeeDTO>(employee)));
                }

                catch(SqlException ex1)
                {
                    return InternalServerError(ex1.InnerException);
                }

                catch(Exception ex)
                {
                    return InternalServerError(ex.InnerException);
                }                
           }
        }

        [HttpGet]
        [ActionName("GetEmployee")]
        public IHttpActionResult GetEmployeeById(int employeeId, bool shouldPullLatest = true)
        {
            using(var ctx = new EmployeeDbContext(EmployeeDbConnectionString))
            {
                try
                {
                    var employeeRepository = new EmployeeRepository(ctx);

                    /*
                     * This might not be an ideal use case scenario to use the inmemory version of data
                     * but still I just wanted to demonstrate a simple way to cache and not hit the database
                     * multiple times in the event of lookup
                     */
                    var employeeCache = new EmployeeRepositoryCache(employeeRepository);

                    if (shouldPullLatest)
                    {
                        employeeCache.Refresh();
                    }

                    var employeeLookup = employeeCache.GetEmployeeLookupByEmployeeId();
                    if (!employeeLookup.TryGetValue(employeeId, out var employeeDetails))
                    {
                        return NotFound();
                    }

                    return Ok(employeeDetails);
                }
                catch(Exception ex)
                {
                    return InternalServerError(ex.InnerException);
                }
            }
        }

        [HttpPost]
        [ActionName("Employee")]
        public IHttpActionResult PostEmployee([FromBody]EmployeeDTO employeeDetails)
        {
            try
            {
                AddOrUpdateEmployee(employeeDetails);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex.InnerException);
            }
        }

        [HttpPut]
        [ActionName("Employee")]
        public IHttpActionResult PutEmployee([FromBody]EmployeeDTO employeeDetails)
        {
            try
            {
                AddOrUpdateEmployee(employeeDetails);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex.InnerException);
            }
        }

        [HttpDelete]
        [ActionName("Employee")]
        public IHttpActionResult DeleteEmployee(int employeeId)
        {
            try
            {
                using (var ctx = new EmployeeDbContext(EmployeeDbConnectionString))
                {
                    var employeeRepository = new EmployeeRepository(ctx);
                    var employeeService = new EmployeeService(employeeRepository);
                    employeeService.Delete(employeeId);
                    return Ok();
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex.InnerException);
            }
        }

        private void AddOrUpdateEmployee(EmployeeDTO employeeDetails)
        {
            using (var ctx = new EmployeeDbContext(EmployeeDbConnectionString))
            {
                var employeeRepository = new EmployeeRepository(ctx);
                var employeeService = new EmployeeService(employeeRepository);
                var loadEmployee = new LoadEmployee();
                var mapper = loadEmployee.CreateDTOToEFMapper();
                employeeService.AddOrUpdateEmployee(mapper.Map<EmployeeDTO, EmployeeDetailsEF>(employeeDetails));
            }
        }
    }
}
