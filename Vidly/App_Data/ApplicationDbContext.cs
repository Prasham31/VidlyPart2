using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext():base("DefaultConnection")
        {
                
        }
    }
}