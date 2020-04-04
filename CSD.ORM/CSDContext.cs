using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSD.ORM
{
    public class CSDContext:DbContext
    {
        public CSDContext(DbContextOptions<CSDContext> options):base(options)
        {

        }

        #region DbSEet

        #endregion
    }
}
