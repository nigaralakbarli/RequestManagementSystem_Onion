using Microsoft.EntityFrameworkCore;
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
        public static void Seeder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(SeedCateory());
            modelBuilder.Entity<ContactMethod>().HasData(SeedContactMethod());
            modelBuilder.Entity<Department>().HasData(SeedDepartment());
            modelBuilder.Entity<DetailType>().HasData(SeedDetailType());
            modelBuilder.Entity<Priority>().HasData(SeedPriority());
            modelBuilder.Entity<RequestStatus>().HasData(SeedRequestStatus());
            modelBuilder.Entity<RequestType>().HasData(SeedRequestType());
            modelBuilder.Entity<User>().HasData(SeedUser());
        }
    }
}
