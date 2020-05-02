using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class SujectMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 31, "Rəqəmsal  sistemlər" },
                    { 32, "Verilənlərin strukturu və verilənlər bazası sistemləri" },
                    { 33, "Mobil və paralel kompüter sistemləri" },
                    { 34, "Neyron şəbəkələri" },
                    { 35, "Mobil qurğuların proqramlaşdırılması" },
                    { 36, "Obyektyönlü layihələndirmə proqramlaşdırma " },
                    { 37, "Əməliyyatların tədqiqi" },
                    { 38, "Kompüter sxemotexnikası və mikroprosessor sistemləri " },
                    { 39, "Həyat fəaliyyətinin təhlükəsizliyi" },
                    { 40, "Proqram mühəndisliyinin əsasları və layihələndirmə" },
                    { 41, "Süni intellekt" },
                    { 42, "Kompüter riyaziyyatı" },
                    { 43, "Kompüter qrafikası" },
                    { 44, "İdarəetmənin əsasları" },
                    { 45, "Kompüter mühəndisliyində siqnalların işlənməsi" },
                    { 46, "Kompüter sistemlərinin təhlükəsizliyi" },
                    { 47, "Sistemlərin simulyasiyası" },
                    { 48, "İnternet texnologiyaları" },
                    { 49, "Mülki müdafiə" },
                    { 50, "Qərar qəbuletmə sistemlərinin əsasları" },
                    { 51, "Verilənlərdən biliklərin əldə edilməsi" },
                    { 52, "Elektron sxemlərin kompüter modelləşdirilməsi" },
                    { 53, "Telekommunikasiya sistemləri və naqilsiz şəbəkələr" },
                    { 54, "Texniki xarici dil" },
                    { 29, "Elektronikanın əsasları" },
                    { 28, "Istehsalın iqtisadiyyatı və menecment" },
                    { 27, "Qeyri-səlis sistemlər" },
                    { 26, "Qeyri - səlis məntiq" },
                    { 1, "Azərbaycan tarixi" },
                    { 2, "Xarici dil" },
                    { 3, "Xarici dil - 1" },
                    { 4, "Xarici dil - 2" },
                    { 5, "Riyaziyyat" },
                    { 6, "Riyaziyyat-1" },
                    { 7, "Riyaziyyat-2" },
                    { 8, "Riyaziyyat-3" },
                    { 9, "Fizika" },
                    { 10, "Fizika-1" },
                    { 11, "Fizika-2" },
                    { 12, "Kompüter mühəndisliyinin əsasları" },
                    { 13, "Azərbaycan dili və nitq mədəniyyəti" },
                    { 14, "Azərbaycan Respublikasının Konstitusiyası və hüququn əsasları	" },
                    { 15, "Proqramlaşdırmanın əsasları" },
                    { 16, "Multimediya texnologiyaları" },
                    { 17, "Ehtimal nəzəriyyəsi və statistika" },
                    { 18, "Dövrlər nəzəriyyəsi" },
                    { 19, "Kompüter arxitekturası" },
                    { 20, "Fəlsəfə" },
                    { 21, "Kompüter şəbəkələri" },
                    { 22, "Fəlsəfə" },
                    { 23, "Sistemli analiz və kompüterdə modelləşdirmə" },
                    { 24, "Kompüterlərin tətbiqi nəzəriyyəsinin əsasları" },
                    { 25, "Veb proqramlaması və layihələndirmə" },
                    { 55, "Təcrübə" },
                    { 56, "Yekun dövlət attestasiyası" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subject");

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
        }
    }
}
