using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class SpecialitySubjectMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialitySubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SpecialityId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    CreditId = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialitySubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialitySubject_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialitySubject_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialitySubject_Specialty_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialitySubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Credit",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 9, "9" },
                    { 8, "8" },
                    { 7, "7" },
                    { 6, "6" },
                    { 10, "21" },
                    { 4, "4" },
                    { 3, "3" },
                    { 2, "2" },
                    { 5, "5" }
                });

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

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "VII semestr" },
                    { 1, "I semestr" },
                    { 2, "II semestr" },
                    { 3, "III semestr" },
                    { 4, "IV semestr" },
                    { 5, "V semestr" },
                    { 6, "VI semestr" },
                    { 8, "VIII semestr" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitySubject_CreditId",
                table: "SpecialitySubject",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitySubject_SemesterId",
                table: "SpecialitySubject",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitySubject_SpecialityId",
                table: "SpecialitySubject",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialitySubject_SubjectId",
                table: "SpecialitySubject",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialitySubject");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 1,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 18, 52, 13, 882, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "Personel",
                keyColumn: "Id",
                keyValue: 2,
                column: "Birthdate",
                value: new DateTime(2020, 5, 1, 18, 52, 13, 885, DateTimeKind.Local).AddTicks(5280));
        }
    }
}
