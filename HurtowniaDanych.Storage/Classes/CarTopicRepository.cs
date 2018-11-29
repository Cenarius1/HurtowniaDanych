using HurtowaniaDanych.Domain;
using System;

namespace HurtowniaDanych.Storage {
    public class CarTopicRepository : IDataWarehouseTopicRepository<CarTopic>{
        private readonly DataWarehouseContext context;
        private DateTime layerDate;

        public CarTopicRepository(DataWarehouseContext context) {
            this.context = context;

            layerDate = DateTime.Now;
        }

        public CarTopic Insert(CarTopic car) {
            car.Id = Guid.NewGuid();
            car.LayerDate = layerDate;

            context.Add(car);

            return car;
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
