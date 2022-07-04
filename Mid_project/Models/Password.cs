using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mid_project.Models
{
    public class Password
    {
      
        [Required][MaxLength(15)][MinLength(7)]
        public string password { get; set; }
        [Required] [MaxLength(15)] [MinLength(7)]
        public string password1 { get; set; }

        [Required] [MaxLength(15)][MinLength(7)]
        public string password2 { get; set; }
    }
}