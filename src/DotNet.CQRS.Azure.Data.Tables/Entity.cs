using System;
using System.Runtime.Serialization;
using Azure;
using Azure.Data.Tables;
using Newtonsoft.Json;

namespace DotNet.CQRS.Azure.Data.Tables
{
    public class Entity<T> : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        [IgnoreDataMember]
        public T Value
        {
            get => JsonConvert.DeserializeObject<T>(Json);
            set => Json = JsonConvert.SerializeObject(value);
        }

        public string Json { get; set; }

        public ETag ETag { get; set; } = default;
        public DateTimeOffset? Timestamp { get; set; } = default;
    }
}