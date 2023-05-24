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
        public static List<RequestType> SeedRequestType()
        {
            List<RequestType> requestTypes = new List<RequestType>()
            {
                new RequestType { Id = 1, Name = "APP Change" },
                new RequestType { Id = 2, Name = "APP Issue" },
                new RequestType { Id = 3, Name = "APP New Requirement" },
                new RequestType { Id = 4, Name = "Change the Report" },
                new RequestType { Id = 5, Name = "Crate Custom Report" },
                new RequestType { Id = 6, Name = "Create New Rrport" },
                new RequestType { Id = 7, Name = "Incident" },
                new RequestType { Id = 8, Name = "Master Data Change" },
                new RequestType { Id = 9, Name = "Service Request" }
            };

            return requestTypes;
        }
    }
}
