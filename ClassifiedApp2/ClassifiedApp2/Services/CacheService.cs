using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using ClassifiedApp2.Common;
using ClassifiedApp2.Common.Services;

namespace ClassifiedApp2.Services
{
    /// <summary>
    /// Cache service.
    /// </summary>
    public class CacheService : ICacheService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:GPK.Forms.Services.CacheService"/> class.
        /// </summary>
        public CacheService()
        {
            BlobCache.ApplicationName = "Classified";
        }

        /// <summary>
        /// Gets the and fetch object by key.
        /// </summary>
        /// <returns>The and fetch object by key.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public IObservable<T> GetAndFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc)
        {
            return BlobCache.LocalMachine.GetAndFetchLatest<T>(key, fetchFunc, null, null);
        }

        /// <summary>
        /// Gets the or fetch object by key.
        /// </summary>
        /// <returns>The or fetch object by key.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetOrFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc)
        {
            var result = await BlobCache.LocalMachine.GetOrFetchObject(key, fetchFunc);
            if (result == null)
            {
                await BlobCache.LocalMachine.InvalidateObject<T>(key);
            }

            return result;
        }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">The Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetObject<T>(string key)
        {
            if (await this.ContainsKey(key))
            {
                var result = await BlobCache.LocalMachine.GetObject<T>(key);
                if (result == null)
                {
                    await BlobCache.LocalMachine.InvalidateObject<T>(key);
                }

                return result;
            }

            return default(T);
        }

        /// <summary>
        /// Inserts the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="value">The Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task InsertObject<T>(string key, T value)
        {
            if (await this.ContainsKey(key))
            {
                await this.RemoveObject(key);
            }

            await BlobCache.LocalMachine.InsertObject(key, value);
        }

        /// <summary>
        /// Removes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">The Key.</param>
        public async Task RemoveObject(string key)
        {
            await BlobCache.LocalMachine.Invalidate(key);
        }

        /// <summary>
        /// Retrieves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">The Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> RetrieveSettings<T>(string key)
        {
            var result = default(T);

            if (await this.ContainsKeyForSettings(key))
            {
                result = await BlobCache.UserAccount.GetObject<T>(key);
                if (result == null)
                {
                    await BlobCache.UserAccount.InvalidateObject<T>(key);
                }
            }
            else if (key == Constants.LanguageSettingsKey)
            {
                result = (T)Convert.ChangeType("EN", typeof(T));
            }

            return result;
        }

        /// <summary>
        /// Saves the object in memory.
        /// </summary>
        /// <returns>The object in memory.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="value">The Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task SaveSettings<T>(string key, T value)
        {
            await BlobCache.UserAccount.InsertObject(key, value);
        }

        /// <summary>
        /// Invalidates all.
        /// </summary>
        /// <returns>The all.</returns>
        public async Task InvalidateAll()
        {
            await BlobCache.UserAccount.InvalidateAll();
            await BlobCache.LocalMachine.InvalidateAll();
        }

        /// <summary>
        /// Containses the key.
        /// </summary>
        /// <returns>The key.</returns>
        /// <param name="key">The Key.</param>
        private async Task<bool> ContainsKey(string key)
        {
            var keys = await BlobCache.LocalMachine.GetAllKeys();

            var result = keys.FirstOrDefault(x => x == key);

            return !string.IsNullOrEmpty(result);
        }

        /// <summary>
        /// Containses the key for settings.
        /// </summary>
        /// <returns>The key for settings.</returns>
        /// <param name="key">The Key.</param>
        private async Task<bool> ContainsKeyForSettings(string key)
        {
            var keys = await BlobCache.UserAccount.GetAllKeys();

            var result = keys.FirstOrDefault(x => x == key);

            return !string.IsNullOrEmpty(result);
        }
    }
}
