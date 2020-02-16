using MvcApp.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApp.Models.ViewModels.Profiles
{
    public class PersonVM
    {
        public PersonVM()
        {

        }
        public PersonVM(Person pers)
        {
            Id = pers.Id;
            Name = pers.Name;
            Text = pers.Text;
           
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длинна строки должна быть от 3 до 30 символов")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Комментарий")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Длинна строки должна быть не менее 1 и не более 200 символов")]
        public string Text { get; set; }
      
    }
}