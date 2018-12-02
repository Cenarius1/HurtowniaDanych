namespace DWH.Storage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        OfferSeek = c.String(),
                        PrivateBusiness = c.String(),
                        Category = c.String(),
                        Region = c.String(),
                        Subregion = c.String(),
                        UserId = c.String(),
                        City = c.String(),
                        Make = c.String(),
                        Model = c.String(),
                        EngineCode = c.String(),
                        Version = c.String(),
                        Year = c.String(),
                        Mileage = c.Int(nullable: false),
                        EngineCapacity = c.String(),
                        Vin = c.String(),
                        FuelType = c.String(),
                        EnginePower = c.String(),
                        Gearbox = c.String(),
                        Transmission = c.String(),
                        BodyType = c.String(),
                        DoorCount = c.String(),
                        NrSeats = c.String(),
                        Color = c.String(),
                        Price = c.String(),
                        PriceRaw = c.String(),
                        CountryOrigin = c.String(),
                        Registration = c.String(),
                        UserStatus = c.Int(nullable: false),
                        Env = c.String(),
                        Abs = c.Boolean(nullable: false),
                        Cd = c.Boolean(nullable: false),
                        CentralLock = c.Boolean(nullable: false),
                        FrontElectricWindows = c.Boolean(nullable: false),
                        ElectronicRearviewMirrors = c.Boolean(nullable: false),
                        ElectronicImmobiliser = c.Boolean(nullable: false),
                        FrontAirbags = c.Boolean(nullable: false),
                        FrontPassengerAirbags = c.Boolean(nullable: false),
                        OriginalRadio = c.Boolean(nullable: false),
                        AssistedSteering = c.Boolean(nullable: false),
                        Alarm = c.Boolean(nullable: false),
                        AlloyWheels = c.Boolean(nullable: false),
                        Asr = c.Boolean(nullable: false),
                        ParkAssist = c.Boolean(nullable: false),
                        LaneAssist = c.Boolean(nullable: false),
                        Bluetooth = c.Boolean(nullable: false),
                        AutomaticWipers = c.Boolean(nullable: false),
                        BlindSpotSensor = c.Boolean(nullable: false),
                        AutomaticLights = c.Boolean(nullable: false),
                        BothParkingSensors = c.Boolean(nullable: false),
                        RearParkingSensors = c.Boolean(nullable: false),
                        PanoramicSunroof = c.Boolean(nullable: false),
                        ElectricExteriorMirror = c.Boolean(nullable: false),
                        ElectricInteriorMirror = c.Boolean(nullable: false),
                        RearElectricWindows = c.Boolean(nullable: false),
                        ElectricAdjustableSeats = c.Boolean(nullable: false),
                        Esp = c.Boolean(nullable: false),
                        AuxIn = c.Boolean(nullable: false),
                        SdSocket = c.Boolean(nullable: false),
                        UsbSocket = c.Boolean(nullable: false),
                        TowingHook = c.Boolean(nullable: false),
                        HeadDisplay = c.Boolean(nullable: false),
                        Isofix = c.Boolean(nullable: false),
                        RearviewCamera = c.Boolean(nullable: false),
                        AutomaticAirConditioning = c.Boolean(nullable: false),
                        QuadAirConditioning = c.Boolean(nullable: false),
                        DualAirConditioning = c.Boolean(nullable: false),
                        OnboardComputer = c.Boolean(nullable: false),
                        SideWindowAirbags = c.Boolean(nullable: false),
                        ShiftPaddles = c.Boolean(nullable: false),
                        Mp3 = c.Boolean(nullable: false),
                        Gps = c.Boolean(nullable: false),
                        Dvd = c.Boolean(nullable: false),
                        SpeedLimiter = c.Boolean(nullable: false),
                        HeatedWindshield = c.Boolean(nullable: false),
                        AuxiliaryHeating = c.Boolean(nullable: false),
                        HeatedRearviewMirrors = c.Boolean(nullable: false),
                        DriverKneeAirbag = c.Boolean(nullable: false),
                        FrontSideAirbags = c.Boolean(nullable: false),
                        RearPassengerAirbags = c.Boolean(nullable: false),
                        TintedWindows = c.Boolean(nullable: false),
                        RoofBars = c.Boolean(nullable: false),
                        Sunroof = c.Boolean(nullable: false),
                        DaytimeLights = c.Boolean(nullable: false),
                        SystemStartStop = c.Boolean(nullable: false),
                        Leds = c.Boolean(nullable: false),
                        FogLights = c.Boolean(nullable: false),
                        XenonLights = c.Boolean(nullable: false),
                        LeatherInterior = c.Boolean(nullable: false),
                        VelourInterior = c.Boolean(nullable: false),
                        CruiseControl = c.Boolean(nullable: false),
                        SteeringWhellComands = c.Boolean(nullable: false),
                        CdChanger = c.Boolean(nullable: false),
                        InsertedDttm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarDetails");
        }
    }
}
