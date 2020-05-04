using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ComSciDep.Utility
{
    public static class CsResultConst
    {
        #region Global
        public const string InvalidEmail = "Düzgün email formasını daxil edin";
        public const string RequiredProperty = "Bu məlumat daxil edilməlidir!";
        public const string NoChanges = "Heç bir dəyişiklik olunmadı";
        public const string Maxlength100 = "Ən çox 100 simvol daxil edilə bilər";
        public const string Maxlength250 = "Ən çox 250 simvol daxil edilə bilər";
        public const string Maxlength50 = "Ən çox 50 simvol daxil edilə bilər";
        public const string Maxlength75 = "Ən çox 75 simvol daxil edilə bilər";

        public const string Minlength3 = "Ən az 3 simvol daxil edilməlidir";
        public const string Minlength2 = "Ən az 2 simvol daxil edilməlidir";
        public const string Minlength10 = "Ən az 10 simvol daxil edilməlidir";

        public const string OperationSuccessed = "Əməliyyat uğurla başa çatdı.!";
        public const string Error = "Xəta baş verdi.!";

        public const string ModelNotValid = "Zəhmət olmasa bütün xanaları doldurun!";

        public const string AddSuccess = "Uğurla əlavə edildi.!";
        public const string EditSuccess = "Uğurla redaktə edildi.!";
        public const string DeleteSuccess = "Uğurla silindi.!";
        #endregion

        #region Personel Crud Error
        public const string MaxlengthPinCode = "Ən çox 7 simvol daxil edilə bilər";
        public const string MinlengthPinCode = "Ən az 7 simvol daxil edilməlidir";

        public const string MaxlengthSerialNumber = "Ən çox 10 simvol daxil edilə bilər";
        public const string MinlengthSerialNumber = "Ən az 10 simvol daxil edilməlidir";

        public const string NotFoundPersonel = "Axtardığınız şəxs sistemdə mövcud deyil!";
        public const string AddPersonelOK = "Məlumatlar sistemə əlavə edildi! \n zəhmət olmasa 2-ci taba keçərək İşciyə aid sənədləri daxil edin";

        public const string AleadyTakenPin = "Daxil etdiyiniz Fin kod artiq sistemde mövcuddur.!";

        public const string AleadyHaveSerialNumber = "Daxil etdiyiniz Seria nömrəsi artiq sistemde mövcuddur.!";
        public const string AleadyHaveFinNumber = "Daxil etdiyiniz Fin kod artiq sistemde mövcuddur.!";
        public const string NotFoundDeleteFile = "Silmək istədiyiniz fayl mövcud deyil.!";
        public const string NotFoundFile = "Endirmək istədiyiniz fayl mövcud deyil.!";

        #endregion

        #region DepartmentPosition
        public const string AleadyExistedPersonPosition = "Bu işçiyə artiq vəzifə təyin edilib!";
        public const string AleadyExistedDepartmentChief = "Kafedra müdiri vəzifəsi artiq təyin edilib!";
        #endregion

        #region Login

        public const string MinlengthLogin = "Ən az 6 simvol daxil edilməlidir";
        public const string UserNull = " Hörmətli istifadəçi Daxil edilən məlumatlar düz deyil!";
        public const string LockedOut = "Hörmətli istifadəçi daxil etdiyiniz məlumatlar düz deyil, hesabınız 5 dəqiqəlik bloklanıb!";
        public const string Blocked = "Hörmətli istifadəçi  hesabınız  bloklanıb!";
        public const string UsernameorPassWrong = "İstifadəçi Adı və ya Şifrə düz deyil!";

        #endregion

        #region Registration
        public const string Minlength6 = "Ən az 6 simvol daxil edilməlidir";


        #endregion

 
        #region User Crud Error
        public const string AleadyTakenUsername = "Daxil etdiyiniz istifadəçi adı artiq sistemde mövcuddur.!";

        public const string NotFoundUser = "Axtardığınız istifadəçi sistemdə mövcud deyil!";

        #endregion

        #region Language
        public const string AleadyExistedLanguage = "Bu dil artıq əlavə edilib!";
        #endregion

        #region KnownProgram
        public const string AleadyExistedKnownProgram = "Bu proqram artıq əlavə edilib!";
        #endregion

        #region PersonDocument
        public const string NoFile = "Heç bir fayl seçilməyib!";
        public const string AleadyExistedDocument = "Bu sənəd artıq əlavə edilib!";
        #endregion

        #region SpecialitySubject
        public const string AleadyExistedSubject = "Bu fənn artıq əlavə edilib!";
        public const string NoAnySubject = "Bu ixtisas üçün heç bir fənn tapilmadi!";

        #endregion
    }
}
