namespace GymManagment.Models
{
    public class DiscountedMemberSubscription
    {
        public int ID { get; set; }
        public int MemberSubscriptionId { get; set; }
        public int DiscountId { get; set; }
    }
}
