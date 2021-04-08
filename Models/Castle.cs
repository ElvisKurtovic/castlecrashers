using System;
using System.ComponentModel.DataAnnotations;

namespace castlecrashers.Models
{
    public class Castle
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int Id { get; set; }


    }
}