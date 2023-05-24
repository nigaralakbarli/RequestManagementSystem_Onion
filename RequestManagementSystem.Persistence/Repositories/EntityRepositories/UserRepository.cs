using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Persistence.Repositories.EntityRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

    }
}
