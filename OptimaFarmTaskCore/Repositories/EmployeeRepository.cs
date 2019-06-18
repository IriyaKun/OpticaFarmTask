using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptimaFarmTaskCore.Models;

namespace OptimaFarmTaskCore.Repositories
{
    //this class is static just for test purposes
    public static class EmployeeRepository
    {
        public static List<EmployeeModel> Employees { get; } = new List<EmployeeModel>();

        public static void Add(EmployeeModel e)
        {
            Employees.Add(e);
        }

        public static void Edit(int id, EmployeeModel employee)
        {
            Employees.FirstOrDefault(e => e.Id.Equals(id)).Name = employee.Name;
            Employees.FirstOrDefault(e => e.Id == id).Surname = employee.Surname;
            Employees.FirstOrDefault(e => e.Id == id).Salary = employee.Salary;
        }

        public static void Delete(int id)
        {
            Employees.Remove(Employees.FirstOrDefault(e => e.Id == id));
        }


    }
}
