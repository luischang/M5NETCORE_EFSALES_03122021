using M5NETCORE_EFSALES.CORE.Entities;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.CORE.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<UserAuth> Authentication(string username, string password);
    }
}