using HurtowniaDanych.Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HurtowniaDanych.Storage
{
    public class CarFeaturesRepository : IDataWarehouseTopicRepository<Features>
    {
        private readonly DataWarehouseContext context;

        public CarFeaturesRepository(DataWarehouseContext context)
        {
            this.context = context;
        }

        public Features Insert(Features advert)
        {
            //context.CarFeatures
            if (context.CarFeatures.Any(i => i.AdvertId == advert.AdvertId))
            {
                return null;
            };

            advert.Inserted = DateTime.Now;
            context.Add(advert);
            return advert;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
