using RequestManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        RefreshToken GetByUserId(int userId);
        RefreshToken GetByToken(string token);
        void Add(RefreshToken refreshToken);
        void Update(RefreshToken refreshToken);
    }
}
