using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class USER
    {
        [Required]
        public string id { get; set; }

        [Required]
        public string fullname { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}
