﻿// <auto-generated />
using System;
using CSD.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSD.ORM.Migrations
{
    [DbContext(typeof(CSDContext))]
    [Migration("20200406144049_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSD.Entities.Computer_Engineering.KnownProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LevelId");

                    b.Property<int>("PersonelId");

                    b.Property<int>("ProgramId");

                    b.HasKey("Id");

                    b.HasIndex("LevelId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("ProgramId");

                    b.ToTable("KnownProgram");
                });

            modelBuilder.Entity("CSD.Entities.Computer_Engineering.LevelOfLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LanguageId");

                    b.Property<int>("LevelId");

                    b.Property<int>("PersonelId");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LevelId");

                    b.HasIndex("PersonelId");

                    b.ToTable("LevelOfLanguage");
                });

            modelBuilder.Entity("CSD.Entities.Computer_Engineering.Program", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Program");
                });

            modelBuilder.Entity("CSD.Entities.Shared.AcademicDegree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("AcademicDegree");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Peşə təhsili"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Orta təhsil"
                        },
                        new
                        {
                            Id = 3,
                            Name = "İbtidai təhsil"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Doktrantura təhsili"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Magistratura təhsili"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Bakalavr təhsili"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiredTime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PersonelId");

                    b.Property<DateTime>("ReceivedTime");

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("CSD.Entities.Shared.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Bakı",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Gəncə",
                            Status = true
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NumCode");

                    b.Property<string>("Phonecode");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Azərbaycan",
                            NumCode = "222",
                            Phonecode = "+994"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Turkiyə",
                            NumCode = "333",
                            Phonecode = "+122"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("CSD.Entities.Shared.DocumetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("DocumetType");
                });

            modelBuilder.Entity("CSD.Entities.Shared.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginTime");

                    b.Property<int>("CityId");

                    b.Property<int>("DocumentId");

                    b.Property<int>("EducationDegreeId");

                    b.Property<string>("EducationalInstitution")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("PersonelId");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("EducationDegreeId");

                    b.HasIndex("PersonelId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("CSD.Entities.Shared.EducationDegree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("EducationDegree");
                });

            modelBuilder.Entity("CSD.Entities.Shared.FamilyStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("FamilyStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Evli"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Subay"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Gender");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Kişi"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Qadın"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Azərbaycan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "İngilis"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Rus"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Çin"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Level");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Zəif"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kafi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Orta"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Yaxşı"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Əla"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.PersonDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocumentTypeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Path");

                    b.Property<int>("PersonelId");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("PersonelId");

                    b.ToTable("PersonDocument");
                });

            modelBuilder.Entity("CSD.Entities.Shared.PersonPhone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PersonelId");

                    b.Property<int>("PhoneTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PersonelId");

                    b.HasIndex("PhoneTypeId");

                    b.ToTable("PersonPhone");
                });

            modelBuilder.Entity("CSD.Entities.Shared.Personel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademicDegreeId");

                    b.Property<DateTime>("Birthdate");

                    b.Property<int>("CityId");

                    b.Property<string>("Email");

                    b.Property<int>("FamilyStatusId");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FinCode");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("GenderId");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Residence")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("SerialNumber");

                    b.HasKey("Id");

                    b.HasIndex("AcademicDegreeId");

                    b.HasIndex("CityId");

                    b.HasIndex("FamilyStatusId");

                    b.HasIndex("GenderId");

                    b.ToTable("Personel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AcademicDegreeId = 6,
                            Birthdate = new DateTime(2020, 4, 6, 7, 40, 49, 475, DateTimeKind.Local).AddTicks(4488),
                            CityId = 1,
                            Email = "ilkintagiyev06@gmail.com",
                            FamilyStatusId = 2,
                            FatherName = "Rafiq",
                            FinCode = "111111",
                            Firstname = "Ilkin",
                            GenderId = 1,
                            Lastname = "Tağıyev",
                            Residence = "Oktay Veliyev",
                            SerialNumber = "09876543"
                        },
                        new
                        {
                            Id = 2,
                            AcademicDegreeId = 4,
                            Birthdate = new DateTime(2020, 4, 6, 7, 40, 49, 477, DateTimeKind.Local).AddTicks(8709),
                            CityId = 1,
                            Email = "ilkintagiyev06@gmail.com",
                            FamilyStatusId = 2,
                            FatherName = "Rafiq",
                            FinCode = "111111",
                            Firstname = "Eltac",
                            GenderId = 1,
                            Lastname = "Tağıyev",
                            Residence = "Oktay Veliyev",
                            SerialNumber = "09876543"
                        });
                });

            modelBuilder.Entity("CSD.Entities.Shared.PhoneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PhoneType");
                });

            modelBuilder.Entity("CSD.Entities.Shared.UserApp", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<int?>("PersonelId");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PersonelId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CSD.Entities.Shared.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BeginDate");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<DateTime>("EndTme");

                    b.Property<string>("JobResponsibilities")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<int>("PersonelId");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("PersonelId");

                    b.ToTable("WorkExperience");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserRole<string>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CSD.Entities.Shared.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<string>("Description");

                    b.HasDiscriminator().HasValue("ApplicationRole");
                });

            modelBuilder.Entity("CSD.Entities.Shared.ApplicationUserRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserRole<string>");

                    b.Property<string>("RoleId1");

                    b.Property<string>("UserId1");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.HasDiscriminator().HasValue("ApplicationUserRole");
                });

            modelBuilder.Entity("CSD.Entities.Computer_Engineering.KnownProgram", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Level", "Level")
                        .WithMany("KnownProgram")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("KnownProgram")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Computer_Engineering.Program", "Proqram")
                        .WithMany("KnownProgram")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Computer_Engineering.LevelOfLanguage", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Language", "Language")
                        .WithMany("LevelOfLanguage")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Level", "Level")
                        .WithMany("LevelOfLanguage")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("LevelOfLanguage")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.Certificate", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("Certificate")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.City", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CSD.Entities.Shared.Education", b =>
                {
                    b.HasOne("CSD.Entities.Shared.City", "City")
                        .WithMany("Education")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Document", "Document")
                        .WithMany("Education")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.EducationDegree", "EducationDegree")
                        .WithMany("Education")
                        .HasForeignKey("EducationDegreeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("Education")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CSD.Entities.Shared.PersonDocument", b =>
                {
                    b.HasOne("CSD.Entities.Shared.DocumetType", "DocumetType")
                        .WithMany("PersonDocument")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("PersonDocument")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.PersonPhone", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Country", "Country")
                        .WithMany("PersonPhone")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("PersonPhone")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.PhoneType", "PhoneType")
                        .WithMany("PersonPhone")
                        .HasForeignKey("PhoneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.Personel", b =>
                {
                    b.HasOne("CSD.Entities.Shared.AcademicDegree", "AcademicDegree")
                        .WithMany("Personel")
                        .HasForeignKey("AcademicDegreeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.City", "City")
                        .WithMany("Personel")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.FamilyStatus", "FamilyStatus")
                        .WithMany("Personel")
                        .HasForeignKey("FamilyStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.Gender", "Gender")
                        .WithMany("Personel")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.UserApp", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("UserApp")
                        .HasForeignKey("PersonelId");
                });

            modelBuilder.Entity("CSD.Entities.Shared.WorkExperience", b =>
                {
                    b.HasOne("CSD.Entities.Shared.Personel", "Personel")
                        .WithMany("WorkExperience")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CSD.Entities.Shared.UserApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CSD.Entities.Shared.UserApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSD.Entities.Shared.UserApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CSD.Entities.Shared.UserApp")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSD.Entities.Shared.ApplicationUserRole", b =>
                {
                    b.HasOne("CSD.Entities.Shared.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId1");

                    b.HasOne("CSD.Entities.Shared.UserApp", "User")
                        .WithMany()
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
