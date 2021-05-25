﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ozdilekteyim.Models
{
    public class ArapCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Seo { get; set; }
        public int? CategoryID { get; set; }
        public Category Category { get; set; }
        public string LanguageCode { get; set; } = "ar-ar";
        public bool State { get; set; }
  
    }
}
