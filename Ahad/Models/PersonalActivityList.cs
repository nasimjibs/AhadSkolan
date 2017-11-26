using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class PersonalActivityList
    {
        [Key]
        public int PersonalActivityListId { get; set; }
        [Required]
        public string ActivityTitle { get; set; }
        public int TypeId { get; set; }

        public virtual List<PersonalActivity> PersonalActivitys { get; set; }
        public virtual ActivityType ActivityTypes { get; set; }


    }
}