using RequestManagementSystem.Application.Interfaces;
using RequestManagementSystem.Domain.Entities;
using RequestManagementSystem.Domain.Repositories.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestManagementSystem.Application.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public void Add(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Add(refreshToken);
        }

        public RefreshToken GetByToken(string token)
        {
            return _refreshTokenRepository.Find(rt => rt.Token == token).FirstOrDefault();
        }

        public RefreshToken GetByUserId(int userId)
        {
            return _refreshTokenRepository.Find(r => r.UserId == userId).FirstOrDefault();
        }

        public void Update(RefreshToken refreshToken)
        {
            _refreshTokenRepository.Update(refreshToken);
        }
    }
}
