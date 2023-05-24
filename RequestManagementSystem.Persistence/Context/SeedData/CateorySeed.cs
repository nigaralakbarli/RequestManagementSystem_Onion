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
        public static List<Category> SeedCateory()
        {
            List<Category> categories = new List<Category>()
            {
                new Category { Id = 1, Name = "3E - AGIS"},
                new Category { Id = 2, Name = "3E - dəstək" },
                new Category { Id = 3, Name = "3rd Party" },
                new Category { Id = 4, Name = "abc web site" },
                new Category { Id = 5, Name = "AGIS - Debitor" },
                new Category { Id = 6, Name = "AD SOCAR Romania" },
                new Category { Id = 7, Name = "Agis - Proqram təminatı" },
                new Category { Id = 8, Name = "ailem.socar.az" },
                new Category { Id = 9, Name = "ant.socar.az" },
                new Category { Id = 10, Name = "ASAN web service" },
                new Category { Id = 11, Name = "Azeriqaz sms" },
                new Category { Id = 12, Name = "azkob.az" },
                new Category { Id = 13, Name = "Call Center" },
                new Category { Id = 14, Name = "CIC web site" },
                new Category { Id = 15, Name = "CVS web site" },
                new Category { Id = 16, Name = "AD SOCAR Romania" },
                new Category { Id = 17, Name = "ailem.socar.az" }
            };

            return categories;
        }
    }
}
