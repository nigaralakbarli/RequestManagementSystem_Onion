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
        public static List<ContactMethod> SeedContactMethod()
        {
            List<ContactMethod> contactMethods = new List<ContactMethod>()
            {
                new ContactMethod { Id = 1, Name = "test1" },
                new ContactMethod { Id = 2, Name = "test2" },
                new ContactMethod { Id = 3, Name = "test3" },
                new ContactMethod { Id = 4, Name = "test4" }
            };
            return contactMethods;
        }
    }
}
