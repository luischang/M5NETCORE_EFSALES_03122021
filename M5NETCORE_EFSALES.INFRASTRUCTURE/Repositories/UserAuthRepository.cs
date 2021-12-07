using M5NETCORE_EFSALES.CORE.Entities;
using M5NETCORE_EFSALES.CORE.Interfaces;
using M5NETCORE_EFSALES.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.INFRASTRUCTURE.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly SalesDB2021Context _context;

        public UserAuthRepository(SalesDB2021Context context)
        {
            _context = context;
        }

        public async Task<UserAuth> Authentication(string username, string password)
        {
            return await _context
                    .UserAuth
                    .Where(x => x.Username == username && x.Password == password)
                    .FirstOrDefaultAsync();
        }



    }
}
