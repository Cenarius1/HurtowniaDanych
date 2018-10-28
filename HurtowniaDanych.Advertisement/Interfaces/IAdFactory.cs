using System;

namespace HurtowniaDanych.Advertisement.Interfaces
{
    public abstract class IAdFactory<T>
    {

        public IAd<T> MakeAd(string url)
        {
            IAd<T> ad = CreateAd();
            ad.ProcessUrl(url);
            return ad;
        }

        public abstract IAd<T> CreateAd();
    }
}
