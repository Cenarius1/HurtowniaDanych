namespace HurtowniaDanych.Advertisement.Interfaces
{
    public interface IAd<T>
    {
        void ProcessUrl(string url);
        T RetrieveAd();
    }
}
