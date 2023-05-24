using RequestManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Persistence.Context.SeedData
{
    public static partial class DataSeeder
    {
        public static List<Department> SeedDepartment()
        {
            List<Department> departments = new List<Department>()
            {
                new Department { Id = 1, Name = "Information Technologies" },
                new Department { Id = 2, Name = "Human Resources" },
                new Department { Id = 3, Name = "Data Analysis" }
            };

            return departments;
        }
    }
}
