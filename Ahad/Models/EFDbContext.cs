using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ahad.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Position> Positions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Useer> Useers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<PersonalBM> PersonalBMs { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventList> EventLists { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PersonalActivityList> PersonalActivityLists { get; set; }

        public DbSet<PersonalActivity> PersonalActivitys { get; set; }

        public DbSet<ActivityType> ActivityTypes { get; set; }

    
    }
}