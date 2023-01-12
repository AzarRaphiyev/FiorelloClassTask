﻿using System.ComponentModel.DataAnnotations.Schema;

namespace fieroolle.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
