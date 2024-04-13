using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{

    [ApiController]
    [Route("api/MemberSubscriptions")]
    public class MemberSubscriptionController : ControllerBase
    {
        private readonly MemberSubscripitonsRepository _memberSubscripitonsRepository;

        public MemberSubscriptionController(MemberSubscripitonsRepository memberSubscripitonsRepository)
        {
            _memberSubscripitonsRepository = memberSubscripitonsRepository;
        }
        [HttpGet]
        public IActionResult GetAllMembers()
        {
            var members = _memberSubscripitonsRepository.GetMemberSubscription();
            return Ok(members);
        }
        [HttpPost]
        public IActionResult CreateMemberSubscripiton(MemberSubscription newMemberSubcription)
        {
            try
            {
                _memberSubscripitonsRepository.CreateMemberSubscripiton(newMemberSubcription);
                return CreatedAtAction(nameof(CreateMemberSubscripiton), new { ID = newMemberSubcription.Id }, newMemberSubcription);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdateMemberSubscription(int Id, MemberSubscription UpdatedMemberSubcription)
        {
            if (Id != UpdatedMemberSubcription.Id)
                return BadRequest("ID mismatch");

            try
            {
                _memberSubscripitonsRepository.UpdateMemberSubscription(UpdatedMemberSubcription);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult SoftDeleteMembers(int Id)
        {
            try
            {
                _memberSubscripitonsRepository.SoftDelete(Id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}