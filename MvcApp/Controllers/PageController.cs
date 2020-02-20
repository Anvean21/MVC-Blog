using MvcApp.Domain.Data;


using MvcApp.Domain.ViewModels.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcApp.Controllers
{
    public class PageController : Controller
    {
        //IArticleRepository repo;
        //public PageController(IArticleRepository r)
        //{
        //    repo = r;
        //}
        //public PageController()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    ninjectKernel.Bind<IArticleRepository>().To<ArticleRepository>();
        //    repo = ninjectKernel.Get<IArticleRepository>();
        //}
        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddArticle(ArticleVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using(Db db = new Db())
            {
            Article art = new Article();
                art.Title = model.Title;
                art.Slug = model.Slug;
                art.Time = DateTime.Now;
                art.Tag = model.Tag;
                db.Articles.Add(art);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteArticle(int id)
        {
            using (Db db = new Db())
            {
                //Получаем 
                Article art = db.Articles.Find(id);

                //Удаляем 
                db.Articles.Remove(art);

                //Сохраним изменения в базе
                db.SaveChanges();
            }
            //Добавляем сообщение об успешном удалении 
            TempData["SM"] = "You`ve deleted a Article";

            //Переадресация пользователя
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditArticle(int id)
        {

            //Обьявляем модель 
            ArticleVM model;

            using (Db db = new Db())
            {
                //Получаем Id 
                Article dto = db.Articles.Find(id);

                //(Валидация)
                if (dto == null)
                {
                    return Content("The article does not exist.");
                }

                // Инициализируем модель данными Article через конструктор в классе artilcleVM
                model = new ArticleVM(dto);
            }
            //Возвращаем модель в представление
            return View(model);
        }
        [HttpPost]
        public ActionResult EditArticle(ArticleVM model)
        {
            //Проверяем модель на валидность
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                //Получаем id страницы
                int id = model.Id;


                //Получаем страницу по Id
                Article dto = db.Articles.Find(id);
                //Присваиваем name из полученной модели в DTO


                //Проверяем email на уникальность
                if (db.Articles.Where(x => x.Id != id).Any(x => x.Title == model.Title))
                {
                    ModelState.AddModelError("", "That email already exist.");
                    return View(model);
                }


                //Присвоить остальные значения в класс DTO
                dto.Title = model.Title;

                dto.Slug = model.Slug;
                dto.Tag = model.Tag;
                dto.Time = DateTime.Now;

                //Сохраняем изменения в базу
                db.SaveChanges();
            }

            //Установить сообщение в TempData
            TempData["SM"] = "You have edited the article.";

            //Переадресация пользователя
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ViewArticle(int id)
        {
            ArticleVM artvm;
            using (Db db = new Db())
            {
                Article art = db.Articles.Find(id);
                if (art == null)
                {
                    return Content("The article is not valid.");
                }
                artvm = new ArticleVM(art);

            }
            return View(artvm);
        }
        
        public ActionResult TagSearch(string tag)
        {
            using (Db db = new Db())
            {

                var allarticles = db.Articles.Where(a => a.Tag.Contains(tag)).ToList();
                return PartialView(allarticles);
            }
        }

        ///////////////////////////////////////////////////////////////////

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            
            //List<ArticleVM> artlist;
            //using (Db db = new Db())
            //{
            //    artlist = db.Articles.ToArray().OrderByDescending(x => x.Id).Select(x => new ArticleVM(x)).ToList();
            //}
            //return View(artlist);
            List<Article> artlist ;
            using (Db db = new Db())
            {
                artlist = db.Articles.ToArray().ToList();

            }
            
            int pageSize = 3;
            IEnumerable<Article> articlesPerPages = artlist.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = artlist.Count };
            IndexViewModel avm = new IndexViewModel { PageInfo = pageInfo, Articles = articlesPerPages };
            return View(avm);
           

        }
        [HttpGet]
        public ActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Profile(ProfVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                

                ProfDTO dto = new ProfDTO();

                
                if (string.IsNullOrWhiteSpace(model.Name))
                {
                    dto.Name = model.Name.Replace(" ", "-").ToLower();
                }

                if (string.IsNullOrWhiteSpace(model.Surname))
                {
                    dto.Surname = model.Surname.Replace(" ", "-").ToLower();
                }
                
                if (db.Profs.Any(x => x.Email == model.Email))
                {
                    ModelState.AddModelError("", "That email already exist.");
                    return View(model);
                }
                if (dto.Age < 0 || dto.Age > 145)
                {
                    ModelState.AddModelError("", "That age unreal.");
                    return View(model);
                }
                dto.Name = model.Name;
                dto.Surname = model.Surname;

                dto.Password = model.Password;
                dto.Email = model.Email;
                dto.Age = model.Age;
                //  dto.Gender = model.Gender;
                
                db.Profs.Add(dto);
                db.SaveChanges();
            }
            return RedirectToAction("ShowProfile");
        }
        public ActionResult ShowProfile()
        {
            List<ProfVM> proflist;
            using (Db db = new Db())
            {
                proflist = db.Profs.ToArray().OrderByDescending(x => x.Id).Select(x => new ProfVM(x)).ToList();
            }
            return View(proflist);
        }
        
        ////////////////////////////////////////////////////////////////
      
        [HttpGet]
        public ActionResult Guest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Guest(PersonVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                Person per = new Person();
                per.Name = model.Name;
                per.Text = model.Text;
                db.People.Add(per);
                db.SaveChanges();
            }
            return RedirectToAction("ShowGuest");
        }
        [HttpGet]
        public ActionResult ShowGuest()
        {
            List<PersonVM> personlist;
            using (Db db = new Db())
            {
                personlist = db.People.ToArray().OrderByDescending(x => x.Id).Select(x => new PersonVM(x)).ToList();
            }
            return View(personlist);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {

            //Обьявляем модель PageVM
            ProfVM model;

            using (Db db = new Db())
            {
                //Получаем Id пользователя 
                ProfDTO dto = db.Profs.Find(id);

                //Проверяем доступен ли он (Валидация)
                if (dto == null)
                {
                    return Content("The page does not exist.");
                }

                // Инициализируем модель данными DTO через конструктор в классе pкщаVM
                model = new ProfVM(dto);
            }
            //Возвращаем модель в представление
            return View(model);
        }
        [HttpPost]
        public ActionResult EditUser(ProfVM model)
        {
            //Проверяем модель на валидность
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                //Получаем id страницы
                int id = model.Id;

                
                //Получаем страницу по Id
                ProfDTO dto = db.Profs.Find(id);
                //Присваиваем name из полученной модели в DTO
                dto.Name = model.Name;

                //Проверяем email на уникальность
                if (db.Profs.Where(x => x.Id != id).Any(x => x.Email == model.Email))
                {
                    ModelState.AddModelError("", "That email already exist.");
                    return View(model);
                }


                //Присвоить остальные значения в класс DTO
                dto.Surname = model.Surname;
               
                dto.Password = model.Password;
                dto.Email = model.Email;
                dto.Age = model.Age;

                //Сохраняем изменения в базу
                db.SaveChanges();
            }

            //Установить сообщение в TempData
            TempData["SM"] = "You have edited the user.";

            //Переадресация пользователя
            return RedirectToAction("ShowProfile");
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            using (Db db = new Db())
            {
                //Получаем user
                ProfDTO dto = db.Profs.Find(id);

                //Удаляем user
                db.Profs.Remove(dto);

                //Сохраним изменения в базе
                db.SaveChanges();
            }
            //Добавляем сообщение об успешном удалении user
            TempData["SM"] = "You`ve deleted a user";

            //Переадресация пользователя
            return RedirectToAction("ShowProfile");
        }
        
    }
}