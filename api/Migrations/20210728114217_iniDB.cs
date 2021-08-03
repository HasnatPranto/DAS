using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class iniDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appoinments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppoinmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoinments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "ee32b23f-bf74-46c3-b995-499e46d3dfec", new byte[] { 31, 222, 62, 70, 179, 220, 247, 8, 216, 129, 207, 55, 102, 137, 222, 219, 33, 117, 170, 104, 54, 25, 222, 72, 124, 210, 78, 35, 204, 249, 53, 88, 231, 205, 122, 80, 41, 117, 208, 151, 178, 195, 177, 15, 224, 21, 60, 106, 189, 51, 92, 13, 250, 32, 70, 170, 178, 118, 194, 235, 76, 132, 37, 9 }, new byte[] { 46, 29, 253, 247, 67, 133, 135, 81, 162, 203, 3, 96, 202, 238, 197, 50, 221, 227, 202, 70, 118, 19, 110, 109, 130, 247, 131, 255, 63, 4, 75, 48, 244, 219, 194, 157, 55, 86, 202, 222, 27, 130, 86, 169, 253, 246, 178, 69, 218, 70, 116, 216, 22, 108, 92, 50, 193, 43, 101, 135, 120, 5, 242, 202, 93, 138, 140, 24, 152, 143, 69, 243, 238, 32, 157, 232, 93, 122, 246, 81, 27, 235, 246, 38, 95, 52, 18, 49, 196, 56, 39, 217, 186, 41, 217, 182, 62, 146, 119, 246, 242, 124, 12, 88, 111, 177, 155, 99, 0, 78, 0, 30, 16, 181, 63, 187, 242, 138, 136, 37, 31, 218, 105, 210, 87, 130, 95, 9 }, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Appoinments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
