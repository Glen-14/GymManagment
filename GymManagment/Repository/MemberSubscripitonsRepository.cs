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
    }
}
