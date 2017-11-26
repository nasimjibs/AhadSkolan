using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class EventCategory
    {
        [Key]
        public int EventCategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<EventList> EventLists { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}