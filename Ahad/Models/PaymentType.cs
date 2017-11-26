using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string Type { get; set; }
        public virtual List<PersonalBM> PersonalBMs { get; set; }
    }
}