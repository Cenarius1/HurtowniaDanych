using HurtowniaDanych.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaDanych
{
    public class DataWarehouseManager
    {
        public List<string> LinkList;
        public void Launch()
        {
            ManageDB();
            ManageLinks();
            ManageParse();
            //ManageDB();
        }

        private void ManageLinks()
        {
            SearchCarLinkHandler searchCarLinkHandler = new SearchCarLinkHandler();
            LinkList = searchCarLinkHandler.GetLinks();
        }

        private void ManageParse()
        {

        }

        private void ManageDB()
        {
            var carTopicRepository = new CarTopicRepository(new DataWarehouseContext());

            var car = new HurtowaniaDanych.Domain.CarTopic() {
                ABS = true,
                AddDate = "23.10.2018 21:21",
                Brand = "Ford",
                Model = "Focus Mk3",
                AlloyWheels = true,
                Hook = true,
                Mileage = 230000,
                Description = "Awesome car to sell, so awesome car, nobady have better"
            };

            carTopicRepository.Insert(new HurtowaniaDanych.Domain.CarTopic());
            carTopicRepository.Insert(new HurtowaniaDanych.Domain.CarTopic());
            carTopicRepository.Insert(new HurtowaniaDanych.Domain.CarTopic());

            carTopicRepository.SaveChanges();
        }
    }
}
