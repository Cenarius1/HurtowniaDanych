using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement.Models;

namespace HurtowniaDanych.Advertisement.Classes
{
    public class AdDetailsFactory : IAdFactory<Details>
    {
        public override IAd<Details> CreateAd()
        {
            //Create AdDetails
            return new AdDetails();
        }
    }
}
