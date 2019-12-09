using System;
using System.ComponentModel.DataAnnotations;

namespace CentralErros.DTOs
{
    public class LogDTO
    {
        public int Id { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Environment { get; set; }
<<<<<<< HEAD
=======

        public bool Archived { get; set; }
>>>>>>> bbc9b386731dca1d405fb56b77c278a6ed19ac5d

        [Required]
        public int UserId { get; set; }
    }
}
