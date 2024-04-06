using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GymManagment.Models
{
    public class GymContext: DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        { }

        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Discounts> Dsicounts { get; set; }
        public virtual DbSet<MemberSubscription> MemberSubscriptions { get; set; }
        public virtual DbSet<DiscountedMemberSubscription> DiscountedMemberSubscriptions { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
    }
}
