using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_project.Models
{
    public class login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}