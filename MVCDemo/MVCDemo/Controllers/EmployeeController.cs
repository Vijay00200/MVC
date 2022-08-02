using MVCDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(e => e.EmployeeId == id);

            return View(employee);
        }

        public ActionResult Index(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(e => e.DepartmentId == departmentId).ToList();

            return View(employees);
        }
    }
}