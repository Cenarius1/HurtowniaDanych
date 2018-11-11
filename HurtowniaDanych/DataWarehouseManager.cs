using HurtowniaDanych.Advertisement.Classes;
using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement.Models;
using HurtowniaDanych.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HurtowniaDanych
{
    public class DataWarehouseManager
    {
        public List<string> LinkList;
        IAdFactory<Details> adFactory = new AdDetailsFactory();

        public void Launch()
        {
            ManageLinks();
            ManageParse();
            //ManageDB();
        }

        private void ManageLinks()
        {
            SearchCarLinkHandler searchCarLinkHandler = new SearchCarLinkHandler();
            LinkList = searchCarLinkHandler.GetLinksFromEachPage();
        }

        private void ManageParse()
        {
            // process only first two urls - only for test purposes
            var firstTwoItems = LinkList.Take(2);
            foreach(var url in firstTwoItems)
            {
                IAd<Details> advertisment = adFactory.MakeAd(url);
                //Console.WriteLine("Print Add\n" + advertisment.RetrieveAd() + "\n");
            }
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
