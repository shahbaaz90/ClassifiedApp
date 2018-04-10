using System;
using System.Threading.Tasks;

namespace ClassifiedApp2.Common.Services
{
    public interface ICacheService
    {
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetObject<T>(string key);

        /// <summary>
        /// Gets the and fetch object by key.
        /// </summary>
        /// <returns>The and fetch object by key.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        IObservable<T> GetAndFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc);

        /// <summary>
        /// Inserts the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="value">The Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task InsertObject<T>(string key, T value);

        /// <summary>
        /// Removes the object.
        /// </summary>
        /// <returns>The object.</returns>
        /// <param name="key">The Key.</param>
        Task RemoveObject(string key);

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="value">The Value.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task SaveSettings<T>(string key, T value);

        /// <summary>
        /// Retrieves the settings.
        /// </summary>
        /// <returns>The settings.</returns>
        /// <param name="key">The Key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> RetrieveSettings<T>(string key);

        /// <summary>
        /// Gets the or fetch object by key.
        /// </summary>
        /// <returns>The or fetch object by key.</returns>
        /// <param name="key">The Key.</param>
        /// <param name="fetchFunc">Fetch func.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        Task<T> GetOrFetchObjectByKey<T>(string key, Func<Task<T>> fetchFunc);

        /// <summary>
        /// Invalidates all.
        /// </summary>
        /// <returns>The all.</returns>
        Task InvalidateAll();
    }
}
