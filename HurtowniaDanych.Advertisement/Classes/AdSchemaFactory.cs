using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement;

namespace HurtowniaDanych.Advertisement.Classes
{
    /// <summary>
    /// Not in use at the moment - work in progress
    /// </summary>
    public class AdSchemaFactory : IAdFactory<Schema>
    {
        public override IAd<Schema> CreateAd()
        {
            //Create AdSchema
            return new AdSchema();
        }
    }
}
