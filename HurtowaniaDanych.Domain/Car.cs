using System;

namespace HurtowaniaDanych.Domain {
    public class Car : CarEquipment { 
        public string OfferType { get; set; } //Oferta od
        public string Category { get; set; } //Kategoria
        public string Brand { get; set; } //Marka pojazdu 
        public string Model { get; set; } //Model pojazdu
        public int YearManufacture { get; set; }  //Rok produkcji
        public int Mileage { get; set; } //Przebieg
        public int EngineDisplacement { get; set; } //Pojemność skokowa silnika
        public string VIN { get; set; } //VIN...
        public string Fueltype { get; set; } //FuelType
        public int Power { get; set; } //Moc silnika
        public string TransmisionType { get; set; } //Typ skrzyni biegów
        public string BodyType { get; set; } //Typ nadwozia
        public int DoorsCount { get; set; } //Ilość drzwi
        public int PlacesCount { get; set; } //Ilość miejsc
        public string Color { get; set; } //Kolor nadwozia
        public bool IsMetalic { get; set; } //Czy Metalik
        public bool IsPearly { get; set; } //Czy perłowy
        public string Country { get; set; } //Kraj pochodzenia
        public string FirstRegistration { get; set; } //Data Pierwszej rejestracji
        public string RegistrationNumber { get; set; } //Numer rejestracyjny
        public bool IsRegisteredInPoland { get; set; } //Czy zarejestrowany w polsce
        public bool IsFirstOwner { get; set; } //Czy pierwszy właściciel
        public bool IsServicedInAuthorizedService { get; set; } //Czy serwisowany w ASO
        public bool IsBrandNew { get; set; } //Czy używany
        public string Description { get; set; } //Opis
        public string Cost { get; set; } //Cena
        public string City { get; set; } //Miasto
        public string AddDate { get; set; } //Data Dodania
    }
}