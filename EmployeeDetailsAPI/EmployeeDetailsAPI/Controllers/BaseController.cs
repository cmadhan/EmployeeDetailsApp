using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeDetailsAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected static string EmployeeDbConnectionString => WebApiApplication.ConnectionString;
    }
}