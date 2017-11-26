using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class Unit
    {
          [Key]
        public int UnitId { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal? FixedAmount { get; set; }
        public virtual List<Useer> Useers { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}