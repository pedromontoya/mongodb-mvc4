using Sample.Core.Models;
using Sample.Core.MongoDb;
using System.Collections.Generic;

namespace Sample.Core.Repositories
{
    /// <summary>
    /// Defines a generic interface for CRUD operations on a collection.
    /// </summary>
    /// <typeparam name="T">The type of the documents in the collection.</typeparam>
    public interface IGenericMongoRepository<T> where T : IMongoModel
    {
        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAllDocuments();

        /// <summary>
        /// Adds the document.
        /// </summary>
        /// <param name="document">The document.</param>
        void AddDocument(T document);

        /// <summary>
        /// Updates the document.
        /// </summary>
        /// <param name="document">The document.</param>
        void UpdateDocument(T document);

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <param name="document">The document.</param>
        void DeleteDocument(T document);
    }
}
