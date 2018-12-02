using DWH.Domain;
using DWH.ETL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DWH.ETL.Transform {
    public class TransformProcess : IETLProcess<ExtractCarDetail, LoadCarDetail> {
        private Dictionary<string, bool> features;

        public LoadCarDetail Process(ExtractCarDetail input) {
            features = ConvertFeaturesListToDictionary(input.Features);

            var loadCarDetail = new LoadCarDetail() {
                //DETAILS
                BodyType = input.BodyType,
                Category = input.Category,
                City = input.City,
                Color = input.City,
                CountryOrigin = input.CountryOrigin,
                DoorCount = input.DoorCount,
                EngineCapacity = input.EngineCapacity,
                EngineCode = input.EngineCode,
                EnginePower = input.EnginePower,
                Env = input.Env,
                FuelType = input.FuelType,
                Gearbox = input.Gearbox,
                Make = input.Make,
                Mileage = input.Mileage,
                Model = input.Model,
                NrSeats = input.NrSeats,
                OfferSeek = input.OfferSeek,
                Price = input.Price,
                PriceRaw = input.PriceRaw,
                PrivateBusiness = input.PrivateBusiness,
                Region = input.Region,
                Registration = input.Registration,
                Subregion = input.Subregion,
                Title = input.Title,
                Transmission = input.Transmission,
                UserId = input.UserId,
                UserStatus = input.UserStatus,
                Version = input.Version,
                Vin = input.Vin,
                Year = input.Year,
                //FEATURES
                Abs = ResolveFeature("abs"),
                Cd = ResolveFeature("cd"),
                CentralLock = ResolveFeature("central-lock"),
                FrontElectricWindows = ResolveFeature("front-electric-windows"),
                ElectronicRearviewMirrors = ResolveFeature("electronic-rearview-mirrors"),
                ElectronicImmobiliser = ResolveFeature("electronic-immobiliser"),
                FrontAirbags = ResolveFeature("front-airbags"),
                FrontPassengerAirbags = ResolveFeature("front-passenger-airbags"),
                OriginalRadio = ResolveFeature("original-radio"),
                AssistedSteering = ResolveFeature("assisted-steering"),
                Alarm = ResolveFeature("alarm"),
                AlloyWheels = ResolveFeature("alloy-wheels"),
                Asr = ResolveFeature("asr"),
                ParkAssist = ResolveFeature("park-assist"),
                LaneAssist = ResolveFeature("lane-assist"),
                Bluetooth = ResolveFeature("bluetooth"),
                AutomaticWipers = ResolveFeature("automatic-wipers"),
                BlindSpotSensor = ResolveFeature("blind-spot-sensor"),
                AutomaticLights = ResolveFeature("automatic-lights"),
                BothParkingSensors = ResolveFeature("both-parking-sensors"),
                RearParkingSensors = ResolveFeature("rear-parking-sensors"),
                PanoramicSunroof = ResolveFeature("panoramic-sunroof"),
                ElectricExteriorMirror = ResolveFeature("electric-exterior-mirror"),
                ElectricInteriorMirror = ResolveFeature("electric-interior-mirror"),
                RearElectricWindows = ResolveFeature("rear-electric-windows"),
                ElectricAdjustableSeats = ResolveFeature("electric-adjustable-seats"),
                Esp = ResolveFeature("esp"),
                AuxIn = ResolveFeature("aux-in"),
                SdSocket = ResolveFeature("sd-socket"),
                UsbSocket = ResolveFeature("usb-socket"),
                TowingHook = ResolveFeature("towing-hook"),
                HeadDisplay = ResolveFeature("head-display"),
                Isofix = ResolveFeature("isofix"),
                RearviewCamera = ResolveFeature("rearview-camera"),
                AutomaticAirConditioning = ResolveFeature("automatic-air-conditioning"),
                QuadAirConditioning = ResolveFeature("quad-air-conditioning"),
                DualAirConditioning = ResolveFeature("dual-air-conditioning"),
                OnboardComputer = ResolveFeature("onboard-computer"),
                SideWindowAirbags = ResolveFeature("side-window-airbags"),
                ShiftPaddles = ResolveFeature("shift-paddles"),
                Mp3 = ResolveFeature("mp3"),
                Gps = ResolveFeature("gps"),
                Dvd = ResolveFeature("dvd"),
                SpeedLimiter = ResolveFeature("speed-limiter"),
                HeatedWindshield = ResolveFeature("heated-windshield"),
                AuxiliaryHeating = ResolveFeature("auxiliary-heating"),
                HeatedRearviewMirrors = ResolveFeature("heated-rearview-mirrors"),
                DriverKneeAirbag = ResolveFeature("driver-knee-airbag"),
                FrontSideAirbags = ResolveFeature("front-side-airbags"),
                RearPassengerAirbags = ResolveFeature("rear-passenger-airbags"),
                TintedWindows = ResolveFeature("tinted-windows"),
                RoofBars = ResolveFeature("roof-bars"),
                Sunroof = ResolveFeature("sunroof"),
                DaytimeLights = ResolveFeature("daytime-lights"),
                SystemStartStop = ResolveFeature("system-start-stop"),
                Leds = ResolveFeature("leds"),
                FogLights = ResolveFeature("fog-lights"),
                XenonLights = ResolveFeature("xenon-lights"),
                LeatherInterior = ResolveFeature("leather-interior"),
                VelourInterior = ResolveFeature("velour-interior"),
                CruiseControl = ResolveFeature("cruise - control"),
                SteeringWhellComands = ResolveFeature("steering-whell-comands"),
                CdChanger = ResolveFeature("cd-changer")
            };

            return loadCarDetail;
        }

        private bool ResolveFeature(string featureName) {
            features.TryGetValue(featureName, out bool value);
            return value;
        }

        private Dictionary<string, bool> ConvertFeaturesListToDictionary(List<string> features) {
            return features.ToDictionary(x => x, x => true);
        }
    }
}
