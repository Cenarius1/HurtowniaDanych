using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HurtowniaDanych.Storage.Migrations
{
    public partial class HDProjectMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarDetails",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: true),
                    OfferSeek = table.Column<string>(nullable: true),
                    PrivateBusiness = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    Subregion = table.Column<string>(nullable: true),
                    AdId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    EngineCode = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    Mileage = table.Column<int>(nullable: false),
                    EngineCapacity = table.Column<string>(nullable: true),
                    Vin = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    EnginePower = table.Column<string>(nullable: true),
                    Gearbox = table.Column<string>(nullable: true),
                    Transmission = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    DoorCount = table.Column<string>(nullable: true),
                    NrSeats = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    PriceRaw = table.Column<string>(nullable: true),
                    CountryOrigin = table.Column<string>(nullable: true),
                    Registration = table.Column<string>(nullable: true),
                    UserStatus = table.Column<int>(nullable: false),
                    Env = table.Column<string>(nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDetails", x => x.AdId);
                });

            migrationBuilder.CreateTable(
                name: "CarFeatures",
                columns: table => new
                {
                    AdvertId = table.Column<long>(nullable: false),
                    Abs = table.Column<bool>(nullable: false),
                    Cd = table.Column<bool>(nullable: false),
                    CentralLock = table.Column<bool>(nullable: false),
                    FrontElectricWindows = table.Column<bool>(nullable: false),
                    ElectronicRearviewMirrors = table.Column<bool>(nullable: false),
                    ElectronicImmobiliser = table.Column<bool>(nullable: false),
                    FrontAirbags = table.Column<bool>(nullable: false),
                    FrontPassengerAirbags = table.Column<bool>(nullable: false),
                    OriginalRadio = table.Column<bool>(nullable: false),
                    AssistedSteering = table.Column<bool>(nullable: false),
                    Alarm = table.Column<bool>(nullable: false),
                    AlloyWheels = table.Column<bool>(nullable: false),
                    Asr = table.Column<bool>(nullable: false),
                    ParkAssist = table.Column<bool>(nullable: false),
                    LaneAssist = table.Column<bool>(nullable: false),
                    Bluetooth = table.Column<bool>(nullable: false),
                    AutomaticWipers = table.Column<bool>(nullable: false),
                    BlindSpotSensor = table.Column<bool>(nullable: false),
                    AutomaticLights = table.Column<bool>(nullable: false),
                    BothParkingSensors = table.Column<bool>(nullable: false),
                    RearParkingSensors = table.Column<bool>(nullable: false),
                    PanoramicSunroof = table.Column<bool>(nullable: false),
                    ElectricExteriorMirror = table.Column<bool>(nullable: false),
                    ElectricInteriorMirror = table.Column<bool>(nullable: false),
                    RearElectricWindows = table.Column<bool>(nullable: false),
                    ElectricAdjustableSeats = table.Column<bool>(nullable: false),
                    Esp = table.Column<bool>(nullable: false),
                    AuxIn = table.Column<bool>(nullable: false),
                    SdSocket = table.Column<bool>(nullable: false),
                    UsbSocket = table.Column<bool>(nullable: false),
                    TowingHook = table.Column<bool>(nullable: false),
                    HeadDisplay = table.Column<bool>(nullable: false),
                    Isofix = table.Column<bool>(nullable: false),
                    RearviewCamera = table.Column<bool>(nullable: false),
                    AutomaticAirConditioning = table.Column<bool>(nullable: false),
                    QuadAirConditioning = table.Column<bool>(nullable: false),
                    DualAirConditioning = table.Column<bool>(nullable: false),
                    OnboardComputer = table.Column<bool>(nullable: false),
                    SideWindowAirbags = table.Column<bool>(nullable: false),
                    ShiftPaddles = table.Column<bool>(nullable: false),
                    Mp3 = table.Column<bool>(nullable: false),
                    Gps = table.Column<bool>(nullable: false),
                    Dvd = table.Column<bool>(nullable: false),
                    SpeedLimiter = table.Column<bool>(nullable: false),
                    HeatedWindshield = table.Column<bool>(nullable: false),
                    AuxiliaryHeating = table.Column<bool>(nullable: false),
                    HeatedRearviewMirrors = table.Column<bool>(nullable: false),
                    DriverKneeAirbag = table.Column<bool>(nullable: false),
                    FrontSideAirbags = table.Column<bool>(nullable: false),
                    RearPassengerAirbags = table.Column<bool>(nullable: false),
                    TintedWindows = table.Column<bool>(nullable: false),
                    RoofBars = table.Column<bool>(nullable: false),
                    Sunroof = table.Column<bool>(nullable: false),
                    DaytimeLights = table.Column<bool>(nullable: false),
                    SystemStartStop = table.Column<bool>(nullable: false),
                    Leds = table.Column<bool>(nullable: false),
                    FogLights = table.Column<bool>(nullable: false),
                    XenonLights = table.Column<bool>(nullable: false),
                    LeatherInterior = table.Column<bool>(nullable: false),
                    VelourInterior = table.Column<bool>(nullable: false),
                    CruiseControl = table.Column<bool>(nullable: false),
                    SteeringWhellComands = table.Column<bool>(nullable: false),
                    CdChanger = table.Column<bool>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarFeatures", x => x.AdvertId);
                });

            migrationBuilder.CreateTable(
                name: "CarSchema",
                columns: table => new
                {
                    AdId = table.Column<long>(nullable: false),
                    Context = table.Column<string>(nullable: true),
                    Schema_Type = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    FuelType = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    NumberOfDoors = table.Column<int>(nullable: true),
                    ItemCondition = table.Column<string>(nullable: true),
                    VehicleSeatingCapacity = table.Column<string>(nullable: true),
                    VehicleIdentificationNumber = table.Column<string>(nullable: true),
                    DateVehicleFirstRegistered = table.Column<string>(nullable: true),
                    VehicleEng_Type = table.Column<string>(nullable: true),
                    EngineDisplacement = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UnitCode = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Offers_Type = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    PriceCurrency = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Inserted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSchema", x => x.AdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDetails");

            migrationBuilder.DropTable(
                name: "CarFeatures");

            migrationBuilder.DropTable(
                name: "CarSchema");
        }
    }
}
