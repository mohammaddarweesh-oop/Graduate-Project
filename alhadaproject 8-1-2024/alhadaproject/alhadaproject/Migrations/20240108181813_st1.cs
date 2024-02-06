using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alhadaproject.Migrations
{
    public partial class st1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Srl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitorTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Archeive = table.Column<bool>(type: "bit", nullable: false),
                    Buy = table.Column<bool>(type: "bit", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandDir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasinNo = table.Column<int>(type: "int", nullable: false),
                    BasinName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandNo = table.Column<int>(type: "int", nullable: false),
                    TotalArea = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNo = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estateImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ref = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandArea = table.Column<double>(type: "float", nullable: false),
                    BuildYear = table.Column<int>(type: "int", nullable: false),
                    ApartNo = table.Column<int>(type: "int", nullable: false),
                    stateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateArea = table.Column<double>(type: "float", nullable: false),
                    StateStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomNo = table.Column<int>(type: "int", nullable: false),
                    MasterNo = table.Column<int>(type: "int", nullable: false),
                    BalconyNo = table.Column<int>(type: "int", nullable: false),
                    PathNo = table.Column<int>(type: "int", nullable: false),
                    KitchNo = table.Column<int>(type: "int", nullable: false),
                    LiveRoomNo = table.Column<int>(type: "int", nullable: false),
                    SaloonNo = table.Column<int>(type: "int", nullable: false),
                    LaundryRoom = table.Column<bool>(type: "bit", nullable: false),
                    Guard = table.Column<bool>(type: "bit", nullable: false),
                    Furnished = table.Column<bool>(type: "bit", nullable: false),
                    SolarHeater = table.Column<bool>(type: "bit", nullable: false),
                    ElectricBlind = table.Column<bool>(type: "bit", nullable: false),
                    MaidRoom = table.Column<bool>(type: "bit", nullable: false),
                    PrivateGarage = table.Column<bool>(type: "bit", nullable: false),
                    Haunted = table.Column<bool>(type: "bit", nullable: false),
                    Jacozzi = table.Column<bool>(type: "bit", nullable: false),
                    Parquet = table.Column<bool>(type: "bit", nullable: false),
                    Heating = table.Column<bool>(type: "bit", nullable: false),
                    Garage = table.Column<bool>(type: "bit", nullable: false),
                    NeverLive = table.Column<bool>(type: "bit", nullable: false),
                    ShowerBox = table.Column<bool>(type: "bit", nullable: false),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    EstablishHeat = table.Column<bool>(type: "bit", nullable: false),
                    Garden = table.Column<bool>(type: "bit", nullable: false),
                    Geezer = table.Column<bool>(type: "bit", nullable: false),
                    DoubleGlass = table.Column<bool>(type: "bit", nullable: false),
                    Installment = table.Column<bool>(type: "bit", nullable: false),
                    Conditioning = table.Column<bool>(type: "bit", nullable: false),
                    Taras = table.Column<bool>(type: "bit", nullable: false),
                    FirePlace = table.Column<bool>(type: "bit", nullable: false),
                    Ceramic = table.Column<bool>(type: "bit", nullable: false),
                    Elevator = table.Column<bool>(type: "bit", nullable: false),
                    Entrance = table.Column<bool>(type: "bit", nullable: false),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: false),
                    Marble = table.Column<bool>(type: "bit", nullable: false),
                    StateView = table.Column<bool>(type: "bit", nullable: false),
                    trading = table.Column<bool>(type: "bit", nullable: false),
                    NeedDate = table.Column<bool>(type: "bit", nullable: false),
                    GuardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GradMobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LandTarasArea = table.Column<double>(type: "float", nullable: false),
                    TarasArea = table.Column<double>(type: "float", nullable: false),
                    GardenArea = table.Column<double>(type: "float", nullable: false),
                    Commision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sold = table.Column<bool>(type: "bit", nullable: false),
                    HomePage = table.Column<bool>(type: "bit", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromoNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Inboxes");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "StateImages");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
