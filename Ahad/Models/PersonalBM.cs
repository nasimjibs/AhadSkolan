using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class PersonalBM
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal CollectedAmount { get; set; }
        [DataType(DataType.Date)]
        public DateTime? PaymentDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? InsertedDate { get; set; }
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentTypes { get; set; }

        public virtual Useer Useers { get; set; }


    }
}