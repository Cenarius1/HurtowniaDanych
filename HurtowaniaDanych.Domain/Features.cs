using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HurtowniaDanych.Advertisement
{
    //PascalCase
    public class Features
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //[ForeignKey("Details")]
        [JsonProperty("ad_id")]
        public long AdvertId { get; set; }
        [JsonProperty(PropertyName = "abs")]
        public bool Abs { get; set; }
        [JsonProperty("cd")]
        public bool Cd { get; set; }
        [JsonProperty("central-lock")]
        public bool CentralLock { get; set; }
        [JsonProperty("front-electric-windows")]
        public bool FrontElectricWindows { get; set; }
        [JsonProperty("electronic-rearview-mirrors")]
        public bool ElectronicRearviewMirrors { get; set; }
        [JsonProperty("electronic-immobiliser")]
        public bool ElectronicImmobiliser { get; set; }
        [JsonProperty("front-airbags")]
        public bool FrontAirbags { get; set; }
        [JsonProperty("front-passenger-airbags")]
        public bool FrontPassengerAirbags { get; set; }
        [JsonProperty("original-radio")]
        public bool OriginalRadio { get; set; }
        [JsonProperty("assisted-steering")]
        public bool AssistedSteering { get; set; }
        [JsonProperty("alarm")]
        public bool Alarm { get; set; }
        [JsonProperty("alloy-wheels")]
        public bool AlloyWheels { get; set; }
        [JsonProperty("asr")]
        public bool Asr { get; set; }
        [JsonProperty("park-assist")]
        public bool ParkAssist { get; set; }
        [JsonProperty("lane-assist")]
        public bool LaneAssist { get; set; }
        [JsonProperty("bluetooth")]
        public bool Bluetooth { get; set; }
        [JsonProperty("automatic-wipers")]
        public bool AutomaticWipers { get; set; }        
        [JsonProperty("blind-spot-sensor")]
        public bool BlindSpotSensor { get; set; }
        [JsonProperty("automatic-lights")]
        public bool AutomaticLights { get; set; }
        [JsonProperty("both-parking-sensors")]
        public bool BothParkingSensors { get; set; }
        [JsonProperty("rear-parking-sensors")]
        public bool RearParkingSensors { get; set; }
        [JsonProperty("panoramic-sunroof")]
        public bool PanoramicSunroof { get; set; }
        [JsonProperty("electric-exterior-mirror")]
        public bool ElectricExteriorMirror { get; set; }
        [JsonProperty("electric-interior-mirror")]
        public bool ElectricInteriorMirror { get; set; }
        [JsonProperty("rear-electric-windows")]
        public bool RearElectricWindows { get; set; }
        [JsonProperty("electric-adjustable-seats")]
        public bool ElectricAdjustableSeats { get; set; }
        [JsonProperty("esp")]
        public bool Esp { get; set; }
        [JsonProperty("aux-in")]
        public bool AuxIn { get; set; }
        [JsonProperty("sd-socket")]
        public bool SdSocket { get; set; }
        [JsonProperty("usb-socket")]
        public bool UsbSocket { get; set; }
        [JsonProperty("towing-hook")]
        public bool TowingHook { get; set; }
        [JsonProperty("head-display")]
        public bool HeadDisplay { get; set; }
        [JsonProperty("isofix")]
        public bool Isofix { get; set; }
        [JsonProperty("rearview-camera")]
        public bool RearviewCamera { get; set; }
        [JsonProperty("automatic-air-conditioning")]
        public bool AutomaticAirConditioning { get; set; }
        [JsonProperty("quad-air-conditioning")]
        public bool QuadAirConditioning { get; set; }
        [JsonProperty("dual-air-conditioning")]
        public bool DualAirConditioning { get; set; }
        [JsonProperty("onboard-computer")]
        public bool OnboardComputer { get; set; }
        [JsonProperty("side-window-airbags")]
        public bool SideWindowAirbags { get; set; }
        [JsonProperty("shift-paddles")]
        public bool ShiftPaddles { get; set; }
        [JsonProperty("mp3")]
        public bool Mp3 { get; set; }
        [JsonProperty("gps")]
        public bool Gps { get; set; }
        [JsonProperty("dvd")]
        public bool Dvd { get; set; }
        [JsonProperty("speed-limiter")]
        public bool SpeedLimiter { get; set; }
        [JsonProperty("heated-windshield")]
        public bool HeatedWindshield { get; set; }
        [JsonProperty("auxiliary-heating")]
        public bool AuxiliaryHeating { get; set; }
        [JsonProperty("heated-rearview-mirrors")]
        public bool HeatedRearviewMirrors { get; set; }
        [JsonProperty("driver-knee-airbag")]
        public bool DriverKneeAirbag { get; set; }
        [JsonProperty("front-side-airbags")]
        public bool FrontSideAirbags { get; set; }
        [JsonProperty("rear-passenger-airbags")]
        public bool RearPassengerAirbags { get; set; }
        [JsonProperty("tinted-windows")]
        public bool TintedWindows { get; set; }
        [JsonProperty("roof-bars")]
        public bool RoofBars { get; set; }
        [JsonProperty("sunroof")]
        public bool Sunroof { get; set; }
        [JsonProperty("daytime-lights")]
        public bool DaytimeLights { get; set; }
        [JsonProperty("system-start-stop")]
        public bool SystemStartStop { get; set; }
        [JsonProperty("leds")]
        public bool Leds { get; set; }
        [JsonProperty("fog-lights")]
        public bool FogLights { get; set; }
        [JsonProperty("xenon-lights")]
        public bool XenonLights { get; set; }
        [JsonProperty("leather-interior")]
        public bool LeatherInterior { get; set; }
        [JsonProperty("velour-interior")]
        public bool VelourInterior { get; set; }
        [JsonProperty("cruise-control")]
        public bool CruiseControl { get; set; }
        [JsonProperty("steering-whell-comands")]
        public bool SteeringWhellComands { get; set; }
        [JsonProperty("cd-changer")]
        public bool CdChanger { get; set; }       
        public DateTime Inserted { get; set; }
        //public virtual Details Details { get; set; }
    }
}
