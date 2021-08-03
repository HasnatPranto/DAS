using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientPhoneNumber",
                table: "Appoinments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "ee32b23f-bf74-46c3-b995-499e46d3dfec",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 182, 32, 32, 243, 128, 26, 59, 145, 206, 19, 252, 110, 213, 250, 26, 110, 73, 122, 202, 224, 184, 139, 131, 200, 19, 228, 212, 120, 217, 91, 161, 52, 45, 122, 102, 112, 102, 94, 152, 57, 221, 201, 206, 166, 204, 177, 119, 23, 3, 109, 202, 17, 185, 248, 29, 99, 164, 138, 251, 95, 3, 41, 191, 31 }, new byte[] { 148, 202, 38, 65, 212, 121, 229, 46, 34, 19, 223, 30, 45, 101, 121, 60, 34, 45, 152, 255, 27, 18, 204, 209, 169, 193, 132, 111, 251, 161, 47, 132, 9, 232, 227, 183, 0, 32, 237, 245, 101, 250, 21, 20, 88, 70, 73, 153, 168, 175, 61, 244, 124, 150, 5, 238, 20, 115, 122, 25, 250, 238, 74, 112, 232, 216, 174, 122, 136, 6, 98, 199, 77, 116, 237, 37, 16, 67, 209, 240, 89, 15, 251, 209, 106, 98, 81, 229, 99, 48, 92, 98, 156, 8, 8, 14, 74, 134, 73, 22, 117, 176, 17, 9, 101, 15, 86, 161, 191, 175, 244, 70, 99, 158, 133, 63, 89, 172, 161, 55, 130, 98, 217, 69, 173, 168, 12, 18 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientPhoneNumber",
                table: "Appoinments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: "ee32b23f-bf74-46c3-b995-499e46d3dfec",
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 116, 14, 159, 26, 173, 195, 1, 247, 170, 238, 143, 98, 206, 127, 231, 195, 155, 168, 190, 96, 191, 198, 211, 166, 230, 111, 250, 117, 216, 80, 167, 177, 122, 5, 181, 86, 167, 231, 62, 43, 86, 113, 127, 141, 103, 213, 11, 129, 169, 225, 74, 230, 87, 86, 92, 152, 195, 95, 231, 226, 45, 254, 54, 58 }, new byte[] { 210, 15, 22, 245, 179, 129, 49, 132, 224, 55, 154, 130, 172, 141, 236, 204, 11, 135, 199, 160, 72, 133, 1, 191, 13, 100, 43, 122, 199, 189, 102, 133, 164, 76, 175, 192, 237, 26, 38, 226, 41, 94, 250, 7, 9, 196, 1, 245, 132, 226, 104, 113, 152, 109, 214, 135, 100, 234, 9, 218, 251, 238, 32, 255, 154, 213, 162, 129, 25, 151, 88, 130, 213, 97, 141, 115, 247, 67, 249, 46, 194, 33, 35, 150, 146, 85, 245, 61, 235, 148, 223, 131, 27, 80, 17, 26, 92, 134, 207, 69, 32, 214, 66, 217, 90, 4, 5, 100, 125, 119, 252, 74, 125, 220, 95, 251, 172, 102, 72, 68, 180, 59, 246, 167, 79, 155, 217, 214 } });
        }
    }
}
