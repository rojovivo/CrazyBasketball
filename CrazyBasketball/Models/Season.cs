using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyBasketball.Models
{
    public class Season
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int InitalYear { get; set; }

        [Required]
        public int FinishYear { get; set; }


        public Guid CategoryId { get; set; }
        
        public Category Category { get; set; }

        public Guid TeamId { get; set; }
        
        public Team Team { get; set; }

        
    }
}
