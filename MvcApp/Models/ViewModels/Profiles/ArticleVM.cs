using MvcApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models.ViewModels.Profiles
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

        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Заголовок")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длинна строки должна быть от 3 до 30 символов")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Текст")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Длинна строки должна быть от 50 до 1000 символов")]
        public string Slug { get; set; }
        public DateTime Time { get; set; }
    }
}