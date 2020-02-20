using MvcApp.Domain.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApp.Domain.Data
{
    public class Db : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ProfDTO> Profs { get; set; }
        public DbSet<Person> People { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Article>().HasMany(c => c.Marks)
        //        .WithMany(s => s.Articles)
        //        .Map(t => t.MapLeftKey("ArticleId")
        //        .MapRightKey("MarkId")
        //        .ToTable("ArticleMark"));
        //}
    }
   

}