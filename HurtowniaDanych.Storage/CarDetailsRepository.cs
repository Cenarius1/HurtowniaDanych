using HurtowniaDanych.Advertisement.Models;
using System;
using System.Collections.Generic;
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
            //advert.Make = 


            context.Add(advert);
            return advert;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
