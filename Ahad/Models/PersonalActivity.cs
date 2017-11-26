using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Ahad.Models
{
    public class PersonalActivity
    {
        [Key]
        public int PersonalActivityId { get; set; }
        public int UserId { get; set; }
        public int PersonalActivityListId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Details { get; set; }
        public virtual PersonalActivityList PersonalActivitiLists { get; set; }
        public virtual Useer Useers { get; set; }

    }
}
