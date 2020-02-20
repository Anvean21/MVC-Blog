using MvcApp.Domain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Domain.ViewModels.Profiles
{
    public class ArticleVM
    {
        public ArticleVM()
        {

        }
        public ArticleVM(Article row)
        {
            Id = row.Id;
            Slug = row.Slug;
            Title = row.Title;
            Time = row.Time;
            Tag = row.Tag;
            
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длинна строки должна быть от 3 до 50 символов")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Текст")]
        [StringLength(2000, MinimumLength = 20, ErrorMessage = "Длинна строки должна быть от 20 до 2000 символов")]
        public string Slug { get; set; }
        public DateTime Time { get; set; }
        public string Tag { get; set; }
        //public IEnumerable<Article> Articles { get; set; }
        //public PageInfo PageInfo { get; set; }

    }
}