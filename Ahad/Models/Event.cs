using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? EventDate { get; set; }
        public int EventCategoryId { get; set; }
        public int EventListId { get; set; }
        public int UnitId { get; set; }
        public int? ParticipantNumber {get; set;}
        public virtual EventCategory EventCategorys { get; set; }

        public virtual EventList EventLists { get; set; }

        public virtual Unit Units { get; set; }
       
    }
}