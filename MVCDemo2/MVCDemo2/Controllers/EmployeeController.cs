using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVCDemo2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.Employees.ToList();

            return View(employees);
        }

        [HttpGet, ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create_Post()
        {


            Employee employee = new Employee();
            TryUpdateModel(employee);
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet, ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(e => e.ID == id);

            return View(employee);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.Employees.Single(e => e.ID == id);
            //include property
            //UpdateModel(employee, new string[] { "ID", "Gender", "City", "DateOfBirth" });
            //exclude property
            //UpdateModel(employee, null, null, new string[] { "Name" });
            //using interface
            UpdateModel<IEmployee>(employee);

            if (ModelState.IsValid)
            {
                employeeBusinessLayer.SaveEmployee(employee);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);

            return RedirectToAction("Index");
        }
    }
}