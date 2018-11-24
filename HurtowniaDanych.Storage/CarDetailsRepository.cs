using HurtowniaDanych.Advertisement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HurtowniaDanych.Storage
{
    public class CarDetailsRepository : IDataWarehouseTopicRepository<Details>
    {
        private readonly DataWarehouseContext context;

        public CarDetailsRepository(DataWarehouseContext context)
        {
            this.context = context;
        }

        public Details Insert(Details advert)
        {
            if (context.CarDetails.Any(i => i.AdId == advert.AdId))
            {
                return null;
            };

            advert.Inserted = DateTime.Now;
            advert.LastUpdated = DateTime.Now;
            context.Add(advert);            
            return advert;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
