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
        public static List<DetailType> SeedDetailType()
        {
            List<DetailType> detailTypes = new List<DetailType>()
            {
                new DetailType { Id = 1, Name = "Application Maintenance" },
                new DetailType { Id = 2, Name = "Application Development" }
            };

            return detailTypes;
        }
    }
}
