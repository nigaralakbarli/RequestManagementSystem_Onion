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
        public static List<Priority> SeedPriority()
        {
            List<Priority> priorities = new List<Priority>()
            {
                new Priority { Id = 1, Level = "Low" },
                new Priority { Id = 2, Level = "Medium" },
                new Priority { Id = 3, Level = "High" }
            };

            return priorities;
        }
    }
}
