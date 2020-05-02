using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.Utility
{
    public class Enum
    {

        #region ComSciDep
        public enum EPhoneType
        {
            Home = 1,
            Mobile = 2,
            Work = 3,
        }
         public enum ECountry
        {
            Aze = 1,
        }

        public enum EAcademicDegree
        {
            Docent=1,
            Professor=2,
            HeadTeacher=3,
            Assistant=4,
            TeacherAssistant=5
        }

        public enum EPosition
        {
            DepartmentChief=1
        }
        #endregion
    }
}
