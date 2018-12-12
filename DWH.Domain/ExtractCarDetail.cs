using Newtonsoft.Json;
using System.Collections.Generic;

namespace DWH.Domain {
    public class ExtractCarDetail {
        [JsonProperty("ad_id")]
        public long AdId { get; set; }
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
        [JsonProperty("features")]
        public List<string> Features { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
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

        public ExtractCarDetail() {
            Features = new List<string>();
        }
    }
}
