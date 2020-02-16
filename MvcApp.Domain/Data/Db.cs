using MvcApp.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Data
{
    public class Db : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ProfDTO> Profs { get; set; }
        public DbSet<Person> People { get; set; }
        
    }
   
}