using System.Threading.Tasks;

namespace UniqueBookCase.DomainModel.Interfaces.Repositories
{
    public interface ICacheRepository
    {
        Task Save<T>(T obj, string key, int expirationTimeInMinutes);
        Task<T> Get<T>(string key);
        Task Remove(string key);
    }
}
