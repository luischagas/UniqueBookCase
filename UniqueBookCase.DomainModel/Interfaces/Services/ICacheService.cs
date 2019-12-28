using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.Services
{
    public interface ICacheService
    {
        Task Save<T>(T obj, string key, int expirationTimeInMinutes = 5);
        Task<T> Get<T>(string key);
        Task Remove(string key);
    }
}
