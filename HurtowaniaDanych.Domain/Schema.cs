﻿using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaDanych.Advertisement
{
    public class Schema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        [JsonProperty("@context")]
        public string Context { get; set; }
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("bodyType")]
        public string BodyType { get; set; }
        [JsonProperty("fuelType")]
        public string FuelType { get; set; }
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("numberOfDoors")]
        public int? NumberOfDoors { get; set; }
        [JsonProperty("itemCondition")]
        public string ItemCondition { get; set; }
        [JsonProperty("vehicleSeatingCapacity")]
        public string VehicleSeatingCapacity { get; set; }
        [JsonProperty("vehicleIdentificationNumber")]
        public string VehicleIdentificationNumber { get; set; }
        [JsonProperty("dateVehicleFirstRegistered")]
        public string DateVehicleFirstRegistered { get; set; }
        [JsonProperty("vehicleEngine")]
        public VehicleEng VehicleEngine { get; set; }
        [JsonProperty("mileageFromOdometer")]
        public Mileages MileageFromOdometer { get; set; }
        [JsonProperty("offers")]
        public Offers Offers { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        public DateTime Inserted { get; set; }

        public override string ToString()
        {
            return string.Format("Url: " + Url +
                "\nNazwa: " + Name +
                "\nTyp: " + BodyType +
                "\nRodzaj paliwa: " + FuelType +
                "\nMarka pojazdu: " + Brand +
                "\nModel pojazdu: " + Model +
                "\nKolor: " + Color +
                "\nLiczba drzwi: " + NumberOfDoors +
                "\nStan: " + ItemCondition +
                "\nLiczba miejsc: " + VehicleSeatingCapacity +
                "\nVIN: " + VehicleIdentificationNumber +
                "\nPierwsza rejestracja: " + DateVehicleFirstRegistered +
                //"\nPojemnosc skokowa: " + VehicleEngine.EngineDisplacement +
                "\nPrzebieg: " + MileageFromOdometer.Value + " " + MileageFromOdometer.UnitCode +
                //"\nCena: " + Offers.Price + " " + Offers.PriceCurrency +
                "\nOpis: " + Description
                );
        }
    }

    public class VehicleEng
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("engineDisplacement")]
        public string EngineDisplacement { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        public Schema Schema { get; set; }
    }

    public class Mileages
    {       
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("unitCode")]
        public string UnitCode { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        public Schema Schema { get; set; }
    }

    public class Offers
    {
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("priceCurrency")]
        public string PriceCurrency { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
        public Schema Schema { get; set; }
    }
}
