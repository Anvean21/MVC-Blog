using MvcApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApp.Models.ViewModels.Profiles
{
    public class ProfVM
    {
        public ProfVM()
        {
            //конструктор по умолчанию если не получится получить параметры PagesDTO

        }
        public ProfVM(ProfDTO row)
        {
            //передача данных
            Id = row.Id;
            Name = row.Name;
            Email = row.Email;
            Surname = row.Surname;
            Password = row.Password;
            Age = row.Age;
            // Gender = row.Gender;
        }
        
        public int Id { get; set; }
        // защита от дураков ВАЛИДАЦИЯ
        [Required]
        [Display(Name = "Имя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage ="Длинна строки должна быть от 3 до 20 символов")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длинна строки должна быть от 2 до 25 символов")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [StringLength(18, MinimumLength = 6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Возраст")]
        [Range(0,145, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        //[Display(Name = "Gender")]
        //  public bool Gender { get; set; }

    }
}