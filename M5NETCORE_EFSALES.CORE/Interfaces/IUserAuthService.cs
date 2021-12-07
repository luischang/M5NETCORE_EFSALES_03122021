using M5NETCORE_EFSALES.CORE.Entities;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.CORE.Interfaces
{
    public interface IUserAuthService
    {
        Task<UserAuth> ValidateUser(string username, string password);
    }
}