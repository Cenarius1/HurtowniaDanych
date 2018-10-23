namespace HurtowaniaDanych.Domain {
    public abstract class CarEquipment {
        public bool ABS { get; set; }
        public bool CD{ get; set; }
        public bool CentralLock{ get; set; }
        public bool ElectricFrontWindows{ get; set; }
        public bool ElectricRearWindows{ get; set; }
        public bool Immobilizer{ get; set; }
        public bool DriverAirbag{ get; set; }
        public bool PassengerAirbag{ get; set; }
        public bool FactoryRadio{ get; set; }
        public bool PowerSteering{ get; set; }
        public bool Alarm{ get; set; }
        public bool AlloyWheels{ get; set; }
        public bool TractionControl{ get; set; }
        public bool ParkingAssistant{ get; set; }
        public bool LaneAssistant{ get; set; }
        public bool Bluetooth{ get; set; }
        public bool RainSensor{ get; set; }
        public bool DeadZoneSensor{ get; set; }
        public bool TwilightSensor{ get; set; }
        public bool FrontParkingSensors{ get; set; }
        public bool RearParkingSensors{ get; set; }
        public bool PanoramicRoof{ get; set; }
        public bool ElectricSideMirros{ get; set; }
        public bool ElectricRearMirror{ get; set; }
        public bool ElectricallyAdjustableSeats{ get; set; }
        public bool ESP{ get; set; }
        public bool AUX{ get; set; }
        public bool SDCard{ get; set; }
        public bool USBPort{ get; set; }
        public bool Hook{ get; set; }
        public bool HUD{ get; set; }
        public bool Isofix{ get; set; }
        public bool ReversingCamera{ get; set; }
        public bool AirConditioningAutomatic{ get; set; }
        public bool AirConditioningFourZone{ get; set; }
        public bool AirConditioningTwoZone{ get; set; }
        public bool AirConditioningManual{ get; set; }
        public bool OnBoardComputer{ get; set; }
        public bool AirCurtains{ get; set; }
        public bool ShiftingPaddles{ get; set; } //Łopatki zmiany biegów ?!
        public bool MP3{ get; set; }
        public bool GPS{ get; set; }
        public bool DVD{ get; set; }
        public bool SpeedLimiter{ get; set; }
        public bool ParkingHeater{ get; set; } //ogrzewanie postojowe
        public bool HeatedFrontMirror{ get; set; }
        public bool HeatedSiteMirrors{ get; set; }
        public bool HeatedFrontSeats{ get; set; }
        public bool HeatedRearSeats{ get; set; }
        public bool KneesAirbag{ get; set; }
        public bool FrontSideAirbags{ get; set; }
        public bool RearSideAirbags{ get; set; }
        public bool TintedWindows{ get; set; }
        public bool NotFactoryRadio{ get; set; }
        public bool AdjustableSuspension{ get; set; }
        public bool RoofRails{ get; set; }
        public bool StartStopSystem{ get; set; }
        public bool SunRoof{ get; set; }
        public bool DaytimeLights{ get; set; } //światłą do jazdy dziennej
        public bool LED{ get; set; }
        public bool AntiFogLights{ get; set; }
        public bool XenonLights{ get; set; }
        public bool LeatherUpholstery{ get; set; } //Skóżana tabicerka
        public bool VelorUpholstery{ get; set; } //Welurowa tabicerka
        public bool CruiseControl{ get; set; } //Tempomat
        public bool ActiveCruiseControl{ get; set; } //Aktywny tempomat
        public bool TVTuner{ get; set; } //Tuner TV
        public bool MultifunctionSteeringWheel{ get; set; }
        public bool CDChanger{ get; set; }
    }
}
