﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBasketball.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }        
    }
}
