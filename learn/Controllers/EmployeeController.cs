using Microsoft.AspNetCore.Mvc;
using learn.Models;
using System.Reflection.Metadata.Ecma335;

namespace learn.Controllers
{
    public class EmployeeController : Controller
    {
        HRDatabaseContext dbContext;
            
        public EmployeeController()
        {   
            dbContext = new HRDatabaseContext();
        }


        public IActionResult Index(string SortField,string CurrentSortField,string SortDirection)
        {
            //  List<Employee> employees = dbContext.Employees.ToList();
            var employees = GetEmployees();
            return View(this.SortEmployees(employees, SortField, CurrentSortField, SortDirection));
        }

        private List<Employee> GetEmployees()
        {
            var employees = (
                            from employee in dbContext.Employees
                            join department in dbContext.Departments on employee.DepartmentId equals department.DepartmentId
                            select new Employee
                            {
                             
                            }).ToList();



            return employees;
        }

        public IActionResult Create()
        {
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("DepartmentId");
            ModelState.Remove("EmployeeId");
            ModelState.Remove("DepartmentName");


            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();

        }
        public IActionResult Edit(int ID)
        {

            Employee data = this.dbContext.Employees.Where(e => e.EmployeeId == ID).FirstOrDefault();
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create", data);
        }
        
        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("DepartmentId");
            ModelState.Remove("EmployeeId");
              ModelState.Remove("DepartmentName");


            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
              
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Edit", model);
        }
        public IActionResult Delete( int ID)
        {
            Employee data = this.dbContext.Employees.Where(e => e.EmployeeId == ID).FirstOrDefault();
           if(data!= null)
            {
                dbContext.Employees.Remove(data);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private List<Employee> SortEmployees(List<Employee>employees,string sortField,string currentSortField,string sortDirection)
        { 
            if(string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "EmployeeNumber";
                ViewBag.SortDirection = " Asc"; 
            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.SortDirection = sortDirection == "Asc" ? "Desc" : "Asc";
                else
                    ViewBag.SortDirection = "Asc";
                ViewBag.SortField = sortField;
            }
            var propertyInfo=typeof(Employee).GetProperty(ViewBag.sortField);
            if(ViewBag.SortDirection=="Asc")
                employees=employees.OrderBy(e=>propertyInfo.GetValue(e,null)).ToList();
            else
                employees=employees.OrderByDescending(e => propertyInfo.GetValue(e, null)).ToList();

            return employees;
        }
       


    }
}
