using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class Role
    {
          [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
     
        public virtual List<Useer> Useers { get; set; }
    }
}