using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBasketball.Models
{
    public class Player
    {
        [Required]
        public Guid Id { get; set; }
        public string Dorsal { get; set; }
        public string Name { get; set; }

        public Guid SeasonId { get; set; }
        public Season Season { get; set; }
    }
}
