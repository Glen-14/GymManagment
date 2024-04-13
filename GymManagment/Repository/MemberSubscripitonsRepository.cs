using GymManagment.Models;

namespace GymManagment.Repository
{
    public class MemberSubscripitonsRepository
    {
        private readonly GymContext _context;

        public MemberSubscripitonsRepository(GymContext context)
        {
            _context = context;
        }
        public void CreateMemberSubscripiton(MemberSubscription memberSubscripiton)
        {
            _context.MemberSubscriptions.Add(memberSubscripiton);
            _context.SaveChanges();
        }
        public List<MemberSubscription> GetMemberSubscription()
        {
            return _context.MemberSubscriptions.ToList();
        }
        public void UpdateMemberSubscription(MemberSubscription memberSubscription)
        {
            if (memberSubscription == null)
            {
                throw new ArgumentNullException("This member has no Subscription");
            }
            var existingMemberSubscription = _context.MemberSubscriptions.FirstOrDefault(sub => sub.Id == memberSubscription.Id);
            if (existingMemberSubscription == null)
            {
                throw new ArgumentNullException("Subscription was not found");
            }
            existingMemberSubscription.OriginalPrice = memberSubscription.OriginalPrice;
            existingMemberSubscription.DiscountValue = memberSubscription.DiscountValue;
            existingMemberSubscription.PaidPrice = memberSubscription.PaidPrice;
            existingMemberSubscription.StartDate = memberSubscription.StartDate;
            existingMemberSubscription.EndDate = memberSubscription.EndDate;
            existingMemberSubscription.RemainingSessions = memberSubscription.RemainingSessions;
            _context.SaveChanges();
        }
        public void SoftDelete(int Id)
        {
            var memberSubscription = _context.MemberSubscriptions.FirstOrDefault(p => p.Id == Id);
            if (memberSubscription != null)
            {
                throw new ArgumentException(" not found.");
            }
            memberSubscription.IsDeleted = true;
            _context.SaveChanges();
        }
        public MemberSubscription GetMemberSubcriptionByID(int Id)
        {
            return _context.MemberSubscriptions.FirstOrDefault(memberSubscription => memberSubscription.Id == Id);
        }

    }
}
