using GymManagment.Models;

namespace GymManagment.Repository
{
    public class DiscountsRepository
    {
        private readonly GymContext _context;

        public DiscountsRepository(GymContext context)
        {
            _context = context;
        }
        public void CreateDiscounts(Discounts  newDiscounts)
        {
            bool exists = _context.Dsicounts.Any(Discounts => Discounts.ID == newDiscounts.ID && Discounts.Code == newDiscounts.Code);

            if (exists)
            {
                throw new Exception("this discount already exists");
            }
            else
            {
                _context.Dsicounts.Add(newDiscounts);
                _context.SaveChanges();
            }
        }
        public List<Discounts> GetDiscounts()
        {
            return _context.Dsicounts.ToList();
        }
        public void Updatediscounts(Discounts discounts)
        {
            if (discounts == null)
            {
                throw new ArgumentNullException("This member has no Discounts");
            }
            var existingDiscounts = _context.Dsicounts.FirstOrDefault(sub => sub.ID == discounts.ID);
            if (existingDiscounts == null)
            {
                throw new ArgumentNullException("no Discounts");
            }
            existingDiscounts.Code = discounts.Code;
            existingDiscounts.DeactivationDate = discounts.DeactivationDate;
            existingDiscounts.Value = discounts.Value;
            existingDiscounts.EndDate = discounts.EndDate;
            existingDiscounts.StartDate = discounts.StartDate;

            _context.SaveChanges();
        }
        public void SoftDeleteDiscounts(int ID)
        {
            var discounts = _context.Dsicounts.FirstOrDefault(mem => mem.ID == ID);
            if (discounts != null)
            {
                discounts.isDeleted = true;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Member not found.");
            }

        }
    }
}
