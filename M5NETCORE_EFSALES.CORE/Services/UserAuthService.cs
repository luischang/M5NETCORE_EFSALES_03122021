using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Exceptions;
using M5NETCORE_EFSALES.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.CORE.Services
{
    public class UserAuthService : IUserAuthService
    {
        private readonly IUserAuthRepository _userAuthRepository;

        public UserAuthService(IUserAuthRepository userAuthRepository)
        {
            _userAuthRepository = userAuthRepository;
        }

        public async Task<UserAuth> ValidateUser(string username, string password)
        {
            var user = await _userAuthRepository.Authentication(username, password);
            if (user == null)
                throw new GeneralException("Usuario y/o Clave inválida");
            return user;
        }



    }
}
