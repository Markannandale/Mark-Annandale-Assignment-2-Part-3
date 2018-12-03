using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2Part3.Models
{
    [Table("Movie")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int BookId { get; set; }
        public string MovieTitle { get; set; }
        public string Director { get; set; }
        public int Theatrical_Release_Year { get; set; }
    }
}
