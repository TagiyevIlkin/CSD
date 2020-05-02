using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class SpecialitySubjectMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 19, 32, 46, 892, DateTimeKind.Local).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 19, 32, 46, 895, DateTimeKind.Local).AddTicks(4991));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 19, 29, 29, 838, DateTimeKind.Local).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 19, 29, 29, 840, DateTimeKind.Local).AddTicks(6975));
        }
    }
}
