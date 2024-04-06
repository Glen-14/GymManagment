namespace GymManagment.Models
{
    public class Discounts
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DeactivationDate { get; set; }
    }
}
