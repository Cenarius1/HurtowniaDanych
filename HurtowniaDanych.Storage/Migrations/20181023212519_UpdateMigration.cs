﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HurtowniaDanych.Storage.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ABS = table.Column<bool>(nullable: false),
                    CD = table.Column<bool>(nullable: false),
                    CentralLock = table.Column<bool>(nullable: false),
                    ElectricFrontWindows = table.Column<bool>(nullable: false),
                    ElectricRearWindows = table.Column<bool>(nullable: false),
                    Immobilizer = table.Column<bool>(nullable: false),
                    DriverAirbag = table.Column<bool>(nullable: false),
                    PassengerAirbag = table.Column<bool>(nullable: false),
                    FactoryRadio = table.Column<bool>(nullable: false),
                    PowerSteering = table.Column<bool>(nullable: false),
                    Alarm = table.Column<bool>(nullable: false),
                    AlloyWheels = table.Column<bool>(nullable: false),
                    TractionControl = table.Column<bool>(nullable: false),
                    ParkingAssistant = table.Column<bool>(nullable: false),
                    LaneAssistant = table.Column<bool>(nullable: false),
                    Bluetooth = table.Column<bool>(nullable: false),
                    RainSensor = table.Column<bool>(nullable: false),
                    DeadZoneSensor = table.Column<bool>(nullable: false),
                    TwilightSensor = table.Column<bool>(nullable: false),
                    FrontParkingSensors = table.Column<bool>(nullable: false),
                    RearParkingSensors = table.Column<bool>(nullable: false),
                    PanoramicRoof = table.Column<bool>(nullable: false),
                    ElectricSideMirros = table.Column<bool>(nullable: false),
                    ElectricRearMirror = table.Column<bool>(nullable: false),
                    ElectricallyAdjustableSeats = table.Column<bool>(nullable: false),
                    ESP = table.Column<bool>(nullable: false),
                    AUX = table.Column<bool>(nullable: false),
                    SDCard = table.Column<bool>(nullable: false),
                    USBPort = table.Column<bool>(nullable: false),
                    Hook = table.Column<bool>(nullable: false),
                    HUD = table.Column<bool>(nullable: false),
                    Isofix = table.Column<bool>(nullable: false),
                    ReversingCamera = table.Column<bool>(nullable: false),
                    AirConditioningAutomatic = table.Column<bool>(nullable: false),
                    AirConditioningFourZone = table.Column<bool>(nullable: false),
                    AirConditioningTwoZone = table.Column<bool>(nullable: false),
                    AirConditioningManual = table.Column<bool>(nullable: false),
                    OnBoardComputer = table.Column<bool>(nullable: false),
                    AirCurtains = table.Column<bool>(nullable: false),
                    ShiftingPaddles = table.Column<bool>(nullable: false),
                    MP3 = table.Column<bool>(nullable: false),
                    GPS = table.Column<bool>(nullable: false),
                    DVD = table.Column<bool>(nullable: false),
                    SpeedLimiter = table.Column<bool>(nullable: false),
                    ParkingHeater = table.Column<bool>(nullable: false),
                    HeatedFrontMirror = table.Column<bool>(nullable: false),
                    HeatedSiteMirrors = table.Column<bool>(nullable: false),
                    HeatedFrontSeats = table.Column<bool>(nullable: false),
                    HeatedRearSeats = table.Column<bool>(nullable: false),
                    KneesAirbag = table.Column<bool>(nullable: false),
                    FrontSideAirbags = table.Column<bool>(nullable: false),
                    RearSideAirbags = table.Column<bool>(nullable: false),
                    TintedWindows = table.Column<bool>(nullable: false),
                    NotFactoryRadio = table.Column<bool>(nullable: false),
                    AdjustableSuspension = table.Column<bool>(nullable: false),
                    RoofRails = table.Column<bool>(nullable: false),
                    StartStopSystem = table.Column<bool>(nullable: false),
                    SunRoof = table.Column<bool>(nullable: false),
                    DaytimeLights = table.Column<bool>(nullable: false),
                    LED = table.Column<bool>(nullable: false),
                    AntiFogLights = table.Column<bool>(nullable: false),
                    XenonLights = table.Column<bool>(nullable: false),
                    LeatherUpholstery = table.Column<bool>(nullable: false),
                    VelorUpholstery = table.Column<bool>(nullable: false),
                    CruiseControl = table.Column<bool>(nullable: false),
                    ActiveCruiseControl = table.Column<bool>(nullable: false),
                    TVTuner = table.Column<bool>(nullable: false),
                    MultifunctionSteeringWheel = table.Column<bool>(nullable: false),
                    CDChanger = table.Column<bool>(nullable: false),
                    OfferType = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    YearManufacture = table.Column<int>(nullable: false),
                    Mileage = table.Column<int>(nullable: false),
                    EngineDisplacement = table.Column<int>(nullable: false),
                    VIN = table.Column<string>(nullable: true),
                    Fueltype = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false),
                    TransmisionType = table.Column<string>(nullable: true),
                    BodyType = table.Column<string>(nullable: true),
                    DoorsCount = table.Column<int>(nullable: false),
                    PlacesCount = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    IsMetalic = table.Column<bool>(nullable: false),
                    IsPearly = table.Column<bool>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    FirstRegistration = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    IsRegisteredInPoland = table.Column<bool>(nullable: false),
                    IsFirstOwner = table.Column<bool>(nullable: false),
                    IsServicedInAuthorizedService = table.Column<bool>(nullable: false),
                    IsBrandNew = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Cost = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    AddDate = table.Column<string>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    LayerDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
