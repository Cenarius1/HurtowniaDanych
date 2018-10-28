using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;

namespace HurtowniaDanych.Advertisement.Models
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
        [JsonProperty("ad_id")]
        public string AdId { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("make")]
        public string[] Make { get; set; }
        [JsonProperty("model")]
        public string[] Model { get; set; }
        [JsonProperty("engine_code")]
        public IList<string> EngineCode { get; set; }
        [JsonProperty("version")]
        public IList<string> Version { get; set; }
        [JsonProperty("year")]
        public string[] Year { get; set; }
        [JsonProperty("mileage")]
        public string[] Mileage { get; set; }
        [JsonProperty("engine_capacity")]
        public IList<string> EngineCapacity { get; set; }
        [JsonProperty("fuel_type")]
        public string[] FuelType { get; set; }
        [JsonProperty("engine_power")]
        public string[] EnginePower { get; set; }
        [JsonProperty("gearbox")]
        public string[] Gearbox { get; set; }
        [JsonProperty("transmission")]
        public IList<string> Transmission { get; set; }
        [JsonProperty("body_type")]
        public string[] BodyType { get; set; }
        [DefaultValue(default(IList<string>))]
        [JsonProperty("door_count")]
        public IList<string> DoorCount { get; set; }
        [JsonProperty("nr_seats")]
        public IList<string> NrSeats { get; set; }
        [JsonProperty("color")]
        public string[] Color { get; set; }
        [JsonProperty("features")]
        public IList<string> Features { get; set; }
        [JsonProperty("price")]
        public string[] Price { get; set; }
        [JsonProperty("price_raw")]
        public string PriceRaw { get; set; }
        [JsonProperty("country_origin")]
        public List<string> CountryOrigin { get; set; }
        [JsonProperty("user_status")]
        public int UserStatus { get; set; }
        [JsonProperty("env")]

        public string Env { get; set; }

        public override string ToString()
        {

            //sample json received and processed
            //{"title":"bmw seria 5","offer_seek":"offer","private_business":"private",
            //"category":"osobowe","region":"pomorskie","subregion":"gdansk","ad_id":"6049965958",
            //"city":"gdansk","make":["bmw"],"model":["seria-5"],"engine_code":["550"],"version":["f10-2009"],
            //"year":["2012"],"mileage":["81500"],"engine_capacity":["4400"],"vin":["WBAFU91050C955034"],
            //"fuel_type":["petrol"],"engine_power":["407"],"gearbox":["dual-clutch"],"transmission":["all-wheel-auto"],
            //"body_type":["sedan"],"color":["grey"],"features":["abs","central-lock","front-electric-windows",
            //"electronic-rearview-mirrors","electronic-immobiliser","front-airbags","front-passenger-airbags",
            //"original-radio","assisted-steering","alloy-wheels","both-parking-sensors","rear-parking-sensors","electric-exterior-mirror","electric-interior-mirror","rear-electric-windows","electric-adjustable-seats","aux-in","usb-socket","rearview-camera","automatic-air-conditioning","quad-air-conditioning","onboard-computer","shift-paddles","heated-windshield","heated-rearview-mirrors","front-heated-seats"],"price":["100000-200000"],"price_raw":"120000","country_origin":["d"],"user_status":0,"env":"prod"}

            var engine_code = (EngineCode?.Any() ?? false) ? string.Join(",", EngineCode) : "";
            var version = (Version?.Any() ?? false) ? string.Join(",", Version) : "";
            var engine_capacity = (EngineCapacity?.Any() ?? false) ? string.Join(",", EngineCapacity) : "";
            var transmission = (Transmission?.Any() ?? false) ? string.Join(",", Transmission) : "";
            var door_count = (DoorCount?.Any() ?? false) ? string.Join(",", DoorCount) : "";
            var nr_seats = (NrSeats?.Any() ?? false) ? string.Join(",", NrSeats) : "";

            return string.Format("ID: " + AdId +
                "\nTytul: " + Title +
                "\nOferta od: " + PrivateBusiness +
                "\nKategoria: " + Category +
                "\nWojewodztwo: " + Region +
                "\nMiasto: " + City +
                "\nMarka pojazdu: " + Make.GetValue(0) +
                "\nModel pojazdu: " + Model.GetValue(0) +
                "\nKod silnika: " + engine_code +
                "\nWersja: " + version +
                "\nRok produkcji: " + Year.GetValue(0) +
                "\nPrzebieg: " + Mileage.GetValue(0) +
                "\nPojemnosc skokowa: " + engine_capacity +
                "\nRodzaj paliwa: " + FuelType.GetValue(0) +
                "\nMoc: " + EnginePower.GetValue(0) +
                "\nSkrzynia biegow:" + Gearbox.GetValue(0) +
                "\nNaped: " + transmission +
                "\nTyp: " + BodyType.GetValue(0) +
                "\nLiczba drzwi: " + door_count +
                "\nLiczba miejsc: " + nr_seats +
                "\nKolor: " + Color.GetValue(0) +
                "\nWyposazenie: " + string.Join(",", Features)
            );
        }       

    }
}
