using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimaFarmTaskCore.Models;
using OptimaFarmTaskCore.Repositories;

namespace OptimaFarmTaskCore.Controllers
{
    public class OptimaFarmController : Controller
    {

        public OptimaFarmController()
        {
        }

        public IActionResult Index()
        {
            return View(EmployeeRepository.Employees);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEmployee([Bind("Id,Name,Surname,Salary")]EmployeeModel employee)
        {
            Add(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            return View(FindById(id));
        }

        public IActionResult Statistics()
        {
            int max = 0, min = 0;
            int avg = 0;
            EmployeeModel minEmployee = new EmployeeModel(), maxEmployee = new EmployeeModel();

            foreach (var employee in EmployeeRepository.Employees)
            {
                if (employee.Salary > max)
                {
                    max = employee.Salary;
                    maxEmployee = employee;
                }
                else if(employee.Salary < min)
                {
                    min = employee.Salary;
                    minEmployee = employee;
                }

                avg += employee.Salary;
            }

            ViewData["max"] = max;
            ViewData["min"] = min;

            ViewData["employeeCount"] = EmployeeRepository.Employees.Count;
            ViewData["avg"] = avg / EmployeeRepository.Employees.Count;

            ViewData["minEmployee"] = minEmployee;
            ViewData["maxEmployee"] = maxEmployee;

            return View();
        }

        [HttpPost]
        public IActionResult Search(string searchString)
        {
            return View(Find(searchString));
        }


        //Employee Actions
        private List<EmployeeModel> Find(string nameOrSurname)
        {
            return EmployeeRepository.Employees
                .Where(e => e.Name.Contains(nameOrSurname) || e.Surname.Contains(nameOrSurname))
                .ToList();
        }

        private EmployeeModel FindById(int? id)
        {
            return EmployeeRepository.Employees.FirstOrDefault(e => e.Id == id);
        }

        private bool Add(EmployeeModel employee)
        {
            if (FindById(employee.Id) != null)
            {
                return false;
            }
            EmployeeRepository.Employees.Add(employee);
            return true;
        }

        private bool Remove(int? id)
        {
            EmployeeRepository.Employees.Remove(EmployeeRepository.Employees.First(e => e.Id == id));
            return true;
        }
    }
}