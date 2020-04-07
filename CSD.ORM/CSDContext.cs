using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ORM
{
    public class CSDContext : IdentityDbContext<UserApp>
    {
        public CSDContext(DbContextOptions<CSDContext> options) : base(options)
        {

        }

        #region DbSEet



        #region Shared

        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<FamilyStatus> FamilyStatuses { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<EducationDegree> EducationDegrees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<PersonDocument> PersonDocuments { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<DepartmentPosition> DepartmentPosition { get; set; }
        public DbSet<DocumetType> DocumetTypes { get; set; }





        #endregion

        #region Computer_Engineering

        public DbSet<Program> Programs { get; set; }
        public DbSet<LevelOfLanguage> LevelOfLanguages { get; set; }
        public DbSet<KnownProgram> KnownPrograms { get; set; }

        #endregion


        #endregion


        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Azərbaycan", NumCode = "222", Phonecode = "+994" },
                new Country { Id = 2, Name = "Turkiyə", NumCode = "333", Phonecode = "+122" }
                );

            modelBuilder.Entity<City>().
                HasOne(x => x.Country).
                WithMany(x => x.City).
                OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Bakı", CountryId = 1, Status = true },
                new City { Id = 2, Name = "Gəncə", CountryId = 1, Status = true }
                );

            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Type = "Kişi" },
                new Gender { Id = 2, Type = "Qadın" }
                );

            modelBuilder.Entity<Level>().HasData(
               new Level { Id = 1, Name = "Zəif" },
               new Level { Id = 2, Name = "Kafi" },
               new Level { Id = 3, Name = "Orta" },
               new Level { Id = 4, Name = "Yaxşı" },
               new Level { Id = 5, Name = "Əla" }
               );

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, Name = "Azərbaycan" },
                new Language { Id = 2, Name = "İngilis" },
                new Language { Id = 3, Name = "Rus" },
                new Language { Id = 4, Name = "Çin" }
                );

            modelBuilder.Entity<FamilyStatus>().HasData(
               new FamilyStatus { Id = 1, Name = "Evli" },
               new FamilyStatus { Id = 2, Name = "Subay" }
               );

            modelBuilder.Entity<AcademicDegree>().HasData(
           new AcademicDegree { Id = 1, Name = "Dosent" },
           new AcademicDegree { Id = 2, Name = "Professor" }
           );

            modelBuilder.Entity<Education>().
               HasOne(x => x.Personel).
               WithMany(x => x.Education).
               OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Personel>().HasData(
               new Personel { Id = 1, Firstname = "Ilkin", Lastname = "Tağıyev", FatherName = "Rafiq", Birthdate = DateTime.Now, CityId = 1, Email = "ilkintagiyev06@gmail.com", FamilyStatusId = 2, FinCode = "111111", GenderId = 1, Residence = "Oktay Veliyev", SerialNumber = "09876543", },
               new Personel { Id = 2, Firstname = "Eltac", Lastname = "Tağıyev", FatherName = "Rafiq", Birthdate = DateTime.Now, CityId = 1, Email = "ilkintagiyev06@gmail.com", FamilyStatusId = 2, FinCode = "111111", GenderId = 1, Residence = "Oktay Veliyev", SerialNumber = "09876543", }
               );


            modelBuilder.Entity<Document>().HasData(
                     new Document { Id = 1, Name = "Diplom" },
                     new Document { Id = 2, Name = "Atestat" },
                     new Document { Id = 3, Name = "Şəhadətnamə" },
                     new Document { Id = 4, Name = "Vəsiqə" }
                     );
      
        }

        #endregion

    }
}
