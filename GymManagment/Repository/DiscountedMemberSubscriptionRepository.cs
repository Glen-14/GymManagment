using GymManagment.Models;

namespace GymManagment.Repository
{
    public class DiscountedMemberSubscriptionRepository
    {
        private readonly GymContext _context;

        public DiscountedMemberSubscriptionRepository(GymContext context)
        {
            _context = context;
        }
        public void CreateDiscountedMemberSubscriptions(DiscountedMemberSubscription newDiscountedMemberSubscription)
        {
            bool exists = _context.DiscountedMemberSubscriptions.Any(DiscountedMemberSubscription => DiscountedMemberSubscription.MemberSubscriptionId == newDiscountedMemberSubscription.MemberSubscriptionId);

            if (exists)
            {
                throw new Exception("A member can not have two active discounts");
            }
            else
            {
                _context.DiscountedMemberSubscriptions.Add(newDiscountedMemberSubscription);
                if(!_context.MemberSubscriptions.Any(i => i.Id == newDiscountedMemberSubscription.MemberSubscriptionId && i.DiscountValue != null)){
                    var membSub = _context.MemberSubscriptions.Where(i => i.Id == newDiscountedMemberSubscription.MemberSubscriptionId).FirstOrDefault();
                    membSub.DiscountValue = _context.Dsicounts.Where(i => i.ID == newDiscountedMemberSubscription.DiscountId).FirstOrDefault().Value;
                    
                }
                _context.SaveChanges();
            }

        }
        public List<DiscountedMemberSubscription> GetDiscounts()
        {
            return _context.DiscountedMemberSubscriptions.ToList();
        }
        public void UpdateDiscountedMemberSubscription(DiscountedMemberSubscription updatedDiscountedMemberSubscription)
        {
            var existingDiscountedMemberSubscription = _context.DiscountedMemberSubscriptions.FirstOrDefault(i => i.ID == i.ID);
            if (existingDiscountedMemberSubscription != null)
            {

                throw new Exception("Members not found");
            }
            
            _context.SaveChanges();
        }
        public void SoftDiscountedMemberSubscriptions(int Id)
        {
            var DiscountedMemberSubscriptions = _context.DiscountedMemberSubscriptions.FirstOrDefault(i => i.ID == Id);
            if (DiscountedMemberSubscriptions != null)
            {
                DiscountedMemberSubscriptions.Isdeleted = true;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }


        }
    }
}
