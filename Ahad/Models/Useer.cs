using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class Useer
    {
          [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int PositionId { get; set; }
        public int RoleId { get; set; }
        public int UnitId { get; set; }
        public double FixedAmount { get; set; }
        public Boolean Active { get; set; }
        public virtual Role Roles { get; set; }
        public virtual Position Positions { get; set; }
        public virtual Unit Units { get; set; }

        public virtual List<PersonalBM> PersonalBMs { get; set; }
    }
}