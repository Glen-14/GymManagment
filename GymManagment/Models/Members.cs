namespace GymManagment.Models
{
    public class Members
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int CardNumber { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<MemberSubscription>? MemberSubscriptions { get; set; }

    }
}
