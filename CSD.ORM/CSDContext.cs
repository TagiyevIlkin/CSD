using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ORM
{
    public class CSDContext : DbContext
    {
        public CSDContext(DbContextOptions<CSDContext> options) : base(options)
        {

        }

        #region DbSEet

        #region Shared

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
        public DbSet<DocumetType> DocumetTypes { get; set; }
        public DbSet<EducationDegree> EducationDegrees { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<PersonDocument> PersonDocuments { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }




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
                new Gender { Id = 1, Type="Kişi" },
                new Gender { Id = 1, Type="Qadın" }
                );



        }

        #endregion

    }
}
