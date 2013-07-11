using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Sample.Core.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.Models
{
    public class Note: IMongoModel
    {
        /// <summary>
        /// Gets or sets the id('_id') which is auto-assigned to newly inserted documents.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        public string DateCreated { get; set; }
    }
}
