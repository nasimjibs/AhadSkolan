using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class ActivityType
    {
        [Key]
        public int TypeId { get; set; }
        public string Type { get; set; }

        public virtual List<PersonalActivityList> PersonalActivitiLists { get; set; }

    }
}