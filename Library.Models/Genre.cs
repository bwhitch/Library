using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string GenreType { get; set; }
    }
}
