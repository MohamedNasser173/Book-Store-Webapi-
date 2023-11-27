using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }

        public String Description { get; set; }
    }
}
