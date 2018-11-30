using HurtowniaDanych.Advertisement;
using System;

namespace HurtowniaDanych.Storage
{
    public class AdSchemaRepository : IDataWarehouseTopicRepository<Schema>
    {
        private readonly DataWarehouseContext context;
        public AdSchemaRepository(DataWarehouseContext context)
        {
            this.context = context;
        }
        public Schema Insert(Schema topic)
        {
            topic.Inserted = DateTime.Now;
            context.Add(topic);
            return topic;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
