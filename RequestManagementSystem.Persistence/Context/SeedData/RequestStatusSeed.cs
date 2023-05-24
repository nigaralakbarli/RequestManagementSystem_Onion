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
        public static List<RequestStatus> SeedRequestStatus()
        {
            List<RequestStatus> requestStatuses = new List<RequestStatus>()
            {
                new RequestStatus { Id = 1, Name = "Open"} ,
                new RequestStatus { Id = 2, Name = "In Execution" },
                new RequestStatus { Id = 3, Name = "Rejected" },
                new RequestStatus { Id = 4, Name = "Waiting" },
                new RequestStatus { Id = 5, Name = "Approved" },
                new RequestStatus { Id = 6, Name = "Close" }
            };

            return requestStatuses;
        }
    }
}
