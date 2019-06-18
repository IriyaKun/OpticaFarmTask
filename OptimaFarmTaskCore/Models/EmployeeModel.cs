using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptimaFarmTaskCore.Repositories;

namespace OptimaFarmTaskCore.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            Id = IdGenerator.Generate();
        }

        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }

        public int Salary { get; set; }
    }
}
