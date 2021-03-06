﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;

namespace HurtowniaDanych.Advertisement
{
    public class Details
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("offer_seek")]
        public string OfferSeek { get; set; }
        [JsonProperty("private_business")]
        public string PrivateBusiness { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("subregion")]
        public string Subregion { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("engine_code")]
        public string EngineCode { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("mileage")]
        public int Mileage { get; set; }
        [JsonProperty("engine_capacity")]
        public string EngineCapacity { get; set; }        
        [JsonProperty("vin")]
        public string Vin { get; set; }
        [JsonProperty("fuel_type")]
        public string FuelType { get; set; }
        [JsonProperty("engine_power")]
        public string EnginePower { get; set; }
        [JsonProperty("gearbox")]
        public string Gearbox { get; set; }
        [JsonProperty("transmission")]
        public string Transmission { get; set; }
        [JsonProperty("body_type")]        
        public string BodyType { get; set; }        
        [JsonProperty("door_count")]
        public string DoorCount { get; set; }
        [JsonProperty("nr_seats")]
        public string NrSeats { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [NotMapped]
        [JsonProperty("features")]
        public Features Features { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("price_raw")]
        public string PriceRaw { get; set; }
        [JsonProperty("country_origin")]
        public string CountryOrigin { get; set; }
        [JsonProperty("registration")]
        public string Registration { get; set; }
        [JsonProperty("user_status")]
        public int UserStatus { get; set; }
        [JsonProperty("env")]
        public string Env { get; set; }        
        public DateTime Inserted { get; set; }        

        public override string ToString()
        {
            var engine_code = (EngineCode?.Any() ?? false) ? string.Join(",", EngineCode) : "";
            var version = (Version?.Any() ?? false) ? string.Join(",", Version) : "";
            var engine_capacity = (EngineCapacity?.Any() ?? false) ? string.Join(",", EngineCapacity) : "";
            var vin = (Vin?.Any() ?? false) ? string.Join(",", Vin) : "";
            var engine_power = (EnginePower?.Any() ?? false) ? string.Join(",", EnginePower) : "";
            var gearbox = (Gearbox?.Any() ?? false) ? string.Join(",", Gearbox) : "";
            var transmission = (Transmission?.Any() ?? false) ? string.Join(",", Transmission) : "";
            var door_count = (DoorCount?.Any() ?? false) ? string.Join(",", DoorCount) : "";
            var nr_seats = (NrSeats?.Any() ?? false) ? string.Join(",", NrSeats) : "";
            var color = (Color?.Any() ?? false) ? string.Join(",", Color) : "";
            var registration = (Registration?.Any() ?? false) ? string.Join(",", Registration) : "";
            //var features = (Features?.Any() ?? false) ? string.Join(",", Features) : "";

            return string.Format("ID: " + AdId +
                "\nCena: " + PriceRaw +
                "\nTytul: " + Title +
                "\nOferta od: " + PrivateBusiness +
                "\nKategoria: " + Category +
                "\nWojewodztwo: " + Region +
                "\nMiasto: " + City +
                "\nMarka pojazdu: " + Make +
                "\nModel pojazdu: " + Model +
                "\nKod silnika: " + engine_code +
                "\nWersja: " + version +
                "\nRok produkcji: " + Year +
                "\nPrzebieg: " + Mileage +
                "\nPojemnosc skokowa: " + engine_capacity +
                "\nVin: " + vin +
                "\nRodzaj paliwa: " + FuelType +
                "\nMoc: " + engine_power +
                "\nSkrzynia biegow: " + gearbox +
                "\nNaped: " + transmission +                
                "\nTyp: " + BodyType +
                "\nLiczba drzwi: " + door_count +
                "\nLiczba miejsc: " + nr_seats +
                "\nKolor: " + color +
                "\nNumer rejestracyjny pojazdu: " + registration //+
                //"\nWyposazenie: " + features
            );
        }       

    }
}
