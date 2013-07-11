using Sample.Core.Models;
using Sample.Core.MongoDb;
using Sample.Core.Repositories;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Linq.Expressions;
using System;

namespace Sample.Core.Implementation.Repositories
{
    /// <summary>
    /// Concrete implementation of a generic repository for performing CRUD operations on a MongoDB collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericMongoRepository<T>: IGenericMongoRepository<T> where T : IMongoModel
    {
        private IMongoDbContext _mongoContext;
        private string _collectionName;

        /// <summary>
        /// This generic repository constructor will retrieve documents from a Mongo collection matching the class name represented by T.
        /// </summary>
        /// <param name="mongoContext">The mongo context.</param>
        public GenericMongoRepository(IMongoDbContext mongoContext)
        {
            _mongoContext = mongoContext;

            //Set the underlying collection name to the name of type T.
            _collectionName = typeof(T).Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericMongoRepository{T}"/> class. All subsequent operations will be performed against
        /// the collection name provided.
        /// </summary>
        /// <param name="mongoContext">The mongo context.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public GenericMongoRepository(IMongoDbContext mongoContext, string collectionName)
        {
            _mongoContext = mongoContext;
            _collectionName = collectionName;
        }

        /// <summary>
        /// Gets all documents.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAllDocuments()
        {
            //Retrieve all entities in the underlying mongo collection.
            return _mongoContext.GetMongoCollection<T>(_collectionName).FindAll();
        }

        /// <summary>
        /// Adds the document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void AddDocument(T document)
        {
            //Insert a document into the underlying collection of T. The object id('_id') will be auto-assigned.
            _mongoContext.GetMongoCollection<T>(_collectionName).Insert(document);
        }

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void DeleteDocument(T document)
        {
            //Query based on equality of the document id('_id').
            var query = Query.EQ("_id", new BsonObjectId(new ObjectId(document.Id)));

            //Execute query and delete document.
            var result = _mongoContext.GetMongoCollection<T>(_collectionName).Remove(query);
        }

        /// <summary>
        /// Updates the document.
        /// </summary>
        /// <param name="document">The document.</param>
        public void UpdateDocument(T document)
        {
            //Query based on equality of the document id('_id').
            var query = Query.EQ("_id", new BsonObjectId(new ObjectId(document.Id)));

            //Define update behavior.
            var update = Update.Replace<T>(document);

            //Execute query and update document.
            var result = _mongoContext.GetMongoCollection<T>(_collectionName).Update(query, update);
        }
    }
}
