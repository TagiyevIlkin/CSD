using CSD.Entities.Computer_Engineering;
using CSD.Entities.Shared;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace CSD.ORM
{
    public class CSDContext : IdentityDbContext<UserApp, ApplicationRole, string,
                                                IdentityUserClaim<string>,
                                                ApplicationUserRole,
                                                IdentityUserLogin<string>,
                                                IdentityRoleClaim<string>,
                                                IdentityUserToken<string>>
    {
        public CSDContext()
        {
        }

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
        public DbSet<Specialty> Specialtie { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<SpecialitySubject> SpecialitySubject { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Laboratory> Laboratory { get; set; }
        public DbSet<Event> Event { get; set; }

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


            //#region Identity
            //modelBuilder.Entity<UserApp>(b =>
            //{
            //    // Each User can have many UserClaims
            //    b.HasMany(e => e.Claims)
            //        .WithOne()
            //        .HasForeignKey(uc => uc.UserId)
            //        .IsRequired();

            //    // Each User can have many UserLogins
            //    b.HasMany(e => e.Logins)
            //        .WithOne()
            //        .HasForeignKey(ul => ul.UserId)
            //        .IsRequired();

            //    // Each User can have many UserTokens
            //    b.HasMany(e => e.Tokens)
            //        .WithOne()
            //        .HasForeignKey(ut => ut.UserId)
            //        .IsRequired();

            //    // Each User can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.User)
            //        .HasForeignKey(ur => ur.UserId)
            //        .IsRequired();
            //});

            //modelBuilder.Entity<ApplicationRole>(b =>
            //{
            //    // Each Role can have many entries in the UserRole join table
            //    b.HasMany(e => e.UserRoles)
            //        .WithOne(e => e.Role)
            //        .HasForeignKey(ur => ur.RoleId)
            //        .IsRequired();
            //});


            //#endregion


            modelBuilder.Entity<WorkExperience>().
                  HasOne(x => x.Personel).
                  WithMany(x => x.WorkExperience).
                  OnDelete(DeleteBehavior.Restrict);

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

            modelBuilder.Entity<Specialty>().HasData(
                     new Specialty { Id = 1, Major = "Kompüter mühəndisliyi", Code = "050631" },
                     new Specialty { Id = 2, Major = "İnformasiya texnologiyaları", Code = "050655" },
                     new Specialty { Id = 3, Major = "Sistem mühəndisliyi", Code = "050656" },
                     new Specialty { Id = 4, Major = "Mexatronika və robototexnika mühəndisliyi", Code = "050629" },
                     new Specialty { Id = 5, Major = "İnformasiya təhlükəsizliyi", Code = "XTB 050106" }
                     );

            #region Subject
            modelBuilder.Entity<Subject>().HasData(
                   new Subject { Id = 1, Name = "Azərbaycan tarixi" },
                   new Subject { Id = 2, Name = "Xarici dil" },
                   new Subject { Id = 3, Name = "Xarici dil - 1" },
                   new Subject { Id = 4, Name = "Xarici dil - 2" },
                   new Subject { Id = 5, Name = "Riyaziyyat" },
                   new Subject { Id = 6, Name = "Riyaziyyat-1" },
                   new Subject { Id = 7, Name = "Riyaziyyat-2" },
                   new Subject { Id = 8, Name = "Riyaziyyat-3" },
                   new Subject { Id = 9, Name = "Fizika" },
                   new Subject { Id = 10, Name = "Fizika-1" },
                   new Subject { Id = 11, Name = "Fizika-2" },
                   new Subject { Id = 12, Name = "Kompüter mühəndisliyinin əsasları" },
                   new Subject { Id = 13, Name = "Azərbaycan dili və nitq mədəniyyəti" },
                   new Subject { Id = 14, Name = "Azərbaycan Respublikasının Konstitusiyası və hüququn əsasları	" },
                   new Subject { Id = 15, Name = "Proqramlaşdırmanın əsasları" },
                   new Subject { Id = 16, Name = "Multimediya texnologiyaları" },
                   new Subject { Id = 17, Name = "Ehtimal nəzəriyyəsi və statistika" },
                   new Subject { Id = 18, Name = "Dövrlər nəzəriyyəsi" },
                   new Subject { Id = 19, Name = "Kompüter arxitekturası" },
                   new Subject { Id = 20, Name = "Fəlsəfə" },
                   new Subject { Id = 21, Name = "Kompüter şəbəkələri" },
                   new Subject { Id = 22, Name = "Fəlsəfə" },
                   new Subject { Id = 23, Name = "Sistemli analiz və kompüterdə modelləşdirmə" },
                   new Subject { Id = 24, Name = "Kompüterlərin tətbiqi nəzəriyyəsinin əsasları" },
                   new Subject { Id = 25, Name = "Veb proqramlaması və layihələndirmə" },
                   new Subject { Id = 26, Name = "Qeyri - səlis məntiq" },
                   new Subject { Id = 27, Name = "Qeyri-səlis sistemlər" },
                   new Subject { Id = 28, Name = "Istehsalın iqtisadiyyatı və menecment" },
                   new Subject { Id = 29, Name = "Elektronikanın əsasları" },
                   new Subject { Id = 31, Name = "Rəqəmsal  sistemlər" },
                   new Subject { Id = 32, Name = "Verilənlərin strukturu və verilənlər bazası sistemləri" },
                   new Subject { Id = 33, Name = "Mobil və paralel kompüter sistemləri" },
                   new Subject { Id = 34, Name = "Neyron şəbəkələri" },
                   new Subject { Id = 35, Name = "Mobil qurğuların proqramlaşdırılması" },
                   new Subject { Id = 36, Name = "Obyektyönlü layihələndirmə proqramlaşdırma " },
                   new Subject { Id = 37, Name = "Əməliyyatların tədqiqi" },
                   new Subject { Id = 38, Name = "Kompüter sxemotexnikası və mikroprosessor sistemləri " },
                   new Subject { Id = 39, Name = "Həyat fəaliyyətinin təhlükəsizliyi" },
                   new Subject { Id = 40, Name = "Proqram mühəndisliyinin əsasları və layihələndirmə" },
                   new Subject { Id = 41, Name = "Süni intellekt" },
                   new Subject { Id = 42, Name = "Kompüter riyaziyyatı" },
                   new Subject { Id = 43, Name = "Kompüter qrafikası" },
                   new Subject { Id = 44, Name = "İdarəetmənin əsasları" },
                   new Subject { Id = 45, Name = "Kompüter mühəndisliyində siqnalların işlənməsi" },
                   new Subject { Id = 46, Name = "Kompüter sistemlərinin təhlükəsizliyi" },
                   new Subject { Id = 47, Name = "Sistemlərin simulyasiyası" },
                   new Subject { Id = 48, Name = "İnternet texnologiyaları" },
                   new Subject { Id = 49, Name = "Mülki müdafiə" },
                   new Subject { Id = 50, Name = "Qərar qəbuletmə sistemlərinin əsasları" },
                   new Subject { Id = 51, Name = "Verilənlərdən biliklərin əldə edilməsi" },
                   new Subject { Id = 52, Name = "Elektron sxemlərin kompüter modelləşdirilməsi" },
                   new Subject { Id = 53, Name = "Telekommunikasiya sistemləri və naqilsiz şəbəkələr" },
                   new Subject { Id = 54, Name = "Texniki xarici dil" },
                   new Subject { Id = 55, Name = "Təcrübə" },
                   new Subject { Id = 56, Name = "Yekun dövlət attestasiyası" }
                   );
            #endregion

            modelBuilder.Entity<Semester>().HasData(
                    new Semester { Id = 1, Name = "I semestr" },
                    new Semester { Id = 2, Name = "II semestr" },
                    new Semester { Id = 3, Name = "III semestr" },
                    new Semester { Id = 4, Name = "IV semestr" },
                    new Semester { Id = 5, Name = "V semestr" },
                    new Semester { Id = 6, Name = "VI semestr" },
                    new Semester { Id = 7, Name = "VII semestr" },
                    new Semester { Id = 8, Name = "VIII semestr" }
                    );


            for (int i = 1; i < 10; i++)
            {
                modelBuilder.Entity<Credit>().HasData(

                new Credit { Id = i, Name = i.ToString() }

                   );
            }

            modelBuilder.Entity<Credit>().HasData(

               new Credit { Id = 10, Name = "21" }

                  );
        }

        #endregion

    }
}
