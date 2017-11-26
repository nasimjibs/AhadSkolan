using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class EventList
    {

        [Key]
        public int EventListId { get; set; }
        public string Name { get; set; }
        public int? EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }
        public virtual List<Event> Events { get; set; }
    }
}