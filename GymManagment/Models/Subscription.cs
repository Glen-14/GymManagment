namespace GymManagment.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int NumberOfMonths { get; set; }
        public string WeekFrequency { get; set; }
        public int TotalNumberOfSessions { get; set; }
        public int TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<MemberSubscriptions> MemberSubscriptions { get; set; }
    }
}
