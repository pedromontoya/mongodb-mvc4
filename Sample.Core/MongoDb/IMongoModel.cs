using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Core.MongoDb
{
    /// <summary>
    /// Defines the properties that should be present on a MongoDB model.
    /// </summary>
    public interface IMongoModel
    {
        /// <summary>
        /// Gets or sets the id('_id') which is auto-assigned to newly inserted documents.
        /// </summary>
        string Id { get; set; }
    }
}
