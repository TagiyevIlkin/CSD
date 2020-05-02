using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class SecondMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PersonDocument",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Major = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 18, 15, 28, 9, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 18, 15, 28, 12, DateTimeKind.Local).AddTicks(7826));

            migrationBuilder.InsertData(
                table: "Specialty",
                columns: new[] { "Id", "Code", "Major" },
                values: new object[,]
                {
                    { 1, "050631", "Kompüter mühəndisliyi" },
                    { 2, "050655", "İnformasiya texnologiyaları" },
                    { 3, "050656", "Sistem mühəndisliyi" },
                    { 4, "050629", "Mexatronika və robototexnika mühəndisliyi" },
                    { 5, "XTB 050106", "İnformasiya təhlükəsizliyi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PersonDocument",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 4, 18, 21, 14, 44, 600, DateTimeKind.Local).AddTicks(8096));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 4, 18, 21, 14, 44, 603, DateTimeKind.Local).AddTicks(5184));
        }
    }
}
