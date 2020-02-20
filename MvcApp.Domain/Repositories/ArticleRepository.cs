using MvcApp.Domain.Data;
using MvcApp.Domain.Interfaces;
using MvcApp.Domain.ViewModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApp.Domain.Repositories
{
//    public class ArticleRepository : IDisposable, IArticleRepository
//    {
//        private Db db = new Db();
        
//        public Article AddArticle(ArticleVM model)
//        {
//                Article art = new Article();
//                art.Title = model.Title;
//                art.Slug = model.Slug;
//                art.Time = DateTime.Now;
//                art.Tag = model.Tag;
//                db.Articles.Add(art);
//                db.SaveChanges();
//            return (art);
//        }
//        protected void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                if (db != null)
//                {
//                    db.Dispose();
//                    db = null;
//                }
//            }
//        }
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
}
