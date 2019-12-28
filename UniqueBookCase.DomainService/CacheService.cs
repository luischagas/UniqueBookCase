using System.Threading.Tasks;
using UniqueBookCase.DomainModel.Interfaces.Repositories;
using UniqueBookCase.DomainModel.Interfaces.Services;

namespace UniqueBookCase.DomainService
{
   public class CacheService : ICacheService
    {
        private ICacheRepository _cacheRepository;

        public CacheService(ICacheRepository cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public async Task<T> Get<T>(string key)
        {
          return await _cacheRepository.Get<T>(key);
        }

        public async Task Save<T>(T obj, string key, int expirationTimeInMinutes)
        {
            await _cacheRepository.Save(obj, key, expirationTimeInMinutes);
        }

        public async Task Remove(string key)
        {
            await _cacheRepository.Remove(key);
        }
    }
}
