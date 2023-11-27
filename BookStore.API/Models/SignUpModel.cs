using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class SignUpModel
    {
        [Required]
        public String FristName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public String Password { get; set; }
        [Required]
        public String ConfirmPassword { get; set; }
    }   

}
