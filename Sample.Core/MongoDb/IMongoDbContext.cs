using MongoDB.Driver;
using Sample.Core.Models;
using System;
namespace Sample.Core.MongoDb
{
    /// <summary>
    /// Defines the context for usage of the underlying MongoDb driver.
    /// </summary>
    public interface IMongoDbContext
    {
        /// <summary>
        /// Gets a MongoCollection for Note entries.
        /// </summary>
        MongoCollection<Note> Notes { get; }

        /// <summary>
        /// Gets a MongoCollection to access values for the generic type T.
        /// </summary>
        /// <typeparam name="T">The object type to retrieve from the collection.</typeparam>
        /// <param name="collectionName">The name of the collection within the Mongo Database associated to the context from which to retrieve values.</param>
        /// <returns>A MongoCollection for accessing values of the specified type.</returns>
        MongoCollection<T> GetMongoCollection<T>(string collectionName);
    }
}
