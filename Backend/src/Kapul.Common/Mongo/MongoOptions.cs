using System;
using System.Collections.Generic;
using System.Text;

namespace Kapul.Common.Mongo
{
    class MongoOptions
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool Seed { get; set; }
    }
}
