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
                new Category { Id = 1, Name = "test1"},
                new Category { Id = 2, Name = "test2" },
                new Category { Id = 3, Name = "test3" },
                new Category { Id = 4, Name = "test4" },
                new Category { Id = 5, Name = "test5" },
                new Category { Id = 6, Name = "test6" },
                new Category { Id = 7, Name = "test7" },
                new Category { Id = 8, Name = "test8" },
                new Category { Id = 9, Name = "test9" },
                new Category { Id = 10, Name = "test10" },
                new Category { Id = 11, Name = "test11" },
                new Category { Id = 12, Name = "test12" },
                new Category { Id = 13, Name = "test13" },
                new Category { Id = 14, Name = "test14" },
                new Category { Id = 15, Name = "test15" },
                new Category { Id = 16, Name = "test16" },
                new Category { Id = 17, Name = "test17" }
            };

            return categories;
        }
    }
}
