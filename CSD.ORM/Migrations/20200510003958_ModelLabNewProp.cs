using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class ModelLabNewProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "Laboratory",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 9, 17, 39, 58, 225, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 9, 17, 39, 58, 227, DateTimeKind.Local).AddTicks(6122));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "Laboratory");

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 9, 15, 43, 52, 385, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 9, 15, 43, 52, 388, DateTimeKind.Local).AddTicks(4213));
        }
    }
}
