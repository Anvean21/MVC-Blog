using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApp.Models.Data
{
    [Table("Articles")]
    public class Article
    {
        [Key] //первичный ключ, для безопасности, мвс сам реагирует на Id
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime Time { get; set; }
    }
}