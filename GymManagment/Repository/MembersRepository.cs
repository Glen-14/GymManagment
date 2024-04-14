using GymManagment.Models;

namespace GymManagment.Repository
{
    public class MembersRepository 
    {
        private readonly GymContext _context;

        public MembersRepository(GymContext context)
        {
            _context = context;
        }
        public int GetActiveMembersCount()
        {
            return _context.Members.Count(members => !members.isDeleted);
        }
        public void CreateMembers(Members newMembers)
        {
            bool exists = _context.Members.Any(s => s.ID == newMembers.ID);

            if (exists)
            {
                throw new Exception("A member with the same Id number already exists");
            }
            else
            {
                _context.Members.Add(newMembers);
                _context.SaveChanges();
            }
           
        }
        public List<Members> GetMembers()
        {
            return _context.Members.ToList();
        }
        public void UpdateMembers(Members updatedMembers)
        {
            var existingMembers = _context.Members.FirstOrDefault(members => members.CardNumber == updatedMembers.CardNumber);
            if (existingMembers != null)
            {

                throw new Exception("Members not found");
            }
            existingMembers.FirstName = updatedMembers.FirstName;
            existingMembers.LastName = updatedMembers.LastName;
            existingMembers.Email = updatedMembers.Email;
            existingMembers.CardNumber = updatedMembers.CardNumber;
            existingMembers.isDeleted = updatedMembers.isDeleted;
            _context.SaveChanges();
        }
        public Members GetMembersByID(int CardNumber)
        {
            return _context.Members.FirstOrDefault(members => members.CardNumber == CardNumber);
        }
        public void SoftDeleteMembers(int Id)
        {
            var members = _context.Members.FirstOrDefault(mem => mem.ID == Id);
            if (members != null)
            {
                members.isDeleted = true;
                _context.SaveChanges();
            }
            else 
            {
                throw new Exception("Member not found.");
            }


        }
        public IEnumerable<Members> GetAllMembers()
        {
            return _context.Members.ToList();
        }
    }
}
