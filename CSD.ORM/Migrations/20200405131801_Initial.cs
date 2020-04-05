using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD.ORM.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicDegree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    NumCode = table.Column<string>(nullable: true),
                    Phonecode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumetType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumetType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationDegree",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationDegree", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 50, nullable: false),
                    Lastname = table.Column<string>(maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(maxLength: 50, nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    Residence = table.Column<string>(maxLength: 100, nullable: false),
                    FinCode = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    FamilyStatusId = table.Column<int>(nullable: false),
                    AcademicDegreeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personel_AcademicDegree_AcademicDegreeId",
                        column: x => x.AcademicDegreeId,
                        principalTable: "AcademicDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_FamilyStatus_FamilyStatusId",
                        column: x => x.FamilyStatusId,
                        principalTable: "FamilyStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personel_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PersonelId = table.Column<int>(nullable: false),
                    ReceivedTime = table.Column<DateTime>(nullable: false),
                    ExpiredTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    EducationalInstitution = table.Column<string>(maxLength: 100, nullable: false),
                    Specialty = table.Column<string>(maxLength: 60, nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    EducationDegreeId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_EducationDegree_EducationDegreeId",
                        column: x => x.EducationDegreeId,
                        principalTable: "EducationDegree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Education_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnownProgram",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownProgram_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnownProgram_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnownProgram_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LevelOfLanguage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<int>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelOfLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelOfLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelOfLanguage_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelOfLanguage_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDocument",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Path = table.Column<string>(nullable: true),
                    DocumentTypeId = table.Column<int>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDocument_DocumetType_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumetType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonDocument_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPhone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonelId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false),
                    PhoneTypeId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPhone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPhone_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhone_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPhone_PhoneType_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "PhoneType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkExperience",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 250, nullable: false),
                    Position = table.Column<string>(maxLength: 60, nullable: false),
                    JobResponsibilities = table.Column<string>(maxLength: 500, nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    EndTme = table.Column<DateTime>(nullable: false),
                    PersonelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperience_Personel_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicDegree",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Peşə təhsili" },
                    { 2, "Orta təhsil" },
                    { 3, "İbtidai təhsil" },
                    { 4, "Doktrantura təhsili" },
                    { 5, "Magistratura təhsili" },
                    { 6, "Bakalavr təhsili" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name", "NumCode", "Phonecode" },
                values: new object[,]
                {
                    { 1, "Azərbaycan", "222", "+994" },
                    { 2, "Turkiyə", "333", "+122" }
                });

            migrationBuilder.InsertData(
                table: "FamilyStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Evli" },
                    { 2, "Subay" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 2, "Qadın" },
                    { 1, "Kişi" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Azərbaycan" },
                    { 2, "İngilis" },
                    { 3, "Rus" },
                    { 4, "Çin" }
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Zəif" },
                    { 2, "Kafi" },
                    { 3, "Orta" },
                    { 4, "Yaxşı" },
                    { 5, "Əla" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name", "Status" },
                values: new object[] { 1, 1, "Bakı", true });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "Name", "Status" },
                values: new object[] { 2, 1, "Gəncə", true });

            migrationBuilder.InsertData(
                table: "Personel",
                columns: new[] { "Id", "AcademicDegreeId", "Birthdate", "CityId", "Email", "FamilyStatusId", "FatherName", "FinCode", "Firstname", "GenderId", "Lastname", "Residence", "SerialNumber" },
                values: new object[] { 1, 6, new DateTime(2020, 4, 5, 6, 18, 1, 263, DateTimeKind.Local).AddTicks(8575), 1, "ilkintagiyev06@gmail.com", 2, "Rafiq", "111111", "Ilkin", 1, "Tağıyev", "Oktay Veliyev", "09876543" });

            migrationBuilder.InsertData(
                table: "Personel",
                columns: new[] { "Id", "AcademicDegreeId", "Birthdate", "CityId", "Email", "FamilyStatusId", "FatherName", "FinCode", "Firstname", "GenderId", "Lastname", "Residence", "SerialNumber" },
                values: new object[] { 2, 4, new DateTime(2020, 4, 5, 6, 18, 1, 268, DateTimeKind.Local).AddTicks(1040), 1, "ilkintagiyev06@gmail.com", 2, "Rafiq", "111111", "Eltac", 1, "Tağıyev", "Oktay Veliyev", "09876543" });

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_PersonelId",
                table: "Certificate",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CityId",
                table: "Education",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_DocumentId",
                table: "Education",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_EducationDegreeId",
                table: "Education",
                column: "EducationDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_PersonelId",
                table: "Education",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownProgram_LevelId",
                table: "KnownProgram",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownProgram_PersonelId",
                table: "KnownProgram",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownProgram_ProgramId",
                table: "KnownProgram",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOfLanguage_LanguageId",
                table: "LevelOfLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOfLanguage_LevelId",
                table: "LevelOfLanguage",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelOfLanguage_PersonelId",
                table: "LevelOfLanguage",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_DocumentTypeId",
                table: "PersonDocument",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDocument_PersonelId",
                table: "PersonDocument",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_AcademicDegreeId",
                table: "Personel",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_CityId",
                table: "Personel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_FamilyStatusId",
                table: "Personel",
                column: "FamilyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Personel_GenderId",
                table: "Personel",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_CountryId",
                table: "PersonPhone",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PersonelId",
                table: "PersonPhone",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPhone_PhoneTypeId",
                table: "PersonPhone",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_PersonelId",
                table: "WorkExperience",
                column: "PersonelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "KnownProgram");

            migrationBuilder.DropTable(
                name: "LevelOfLanguage");

            migrationBuilder.DropTable(
                name: "PersonDocument");

            migrationBuilder.DropTable(
                name: "PersonPhone");

            migrationBuilder.DropTable(
                name: "WorkExperience");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "EducationDegree");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "DocumetType");

            migrationBuilder.DropTable(
                name: "PhoneType");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "FamilyStatus");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
