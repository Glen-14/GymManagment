using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    
        [ApiController]
        [Route("api/Members")]
        public class MembersController : ControllerBase
        {
            private readonly MembersRepository _membersRepository;

            public MembersController(MembersRepository membersRepository)
            {
                _membersRepository = membersRepository;
            }

            [HttpGet("activeCount")]
            public IActionResult GetActiveMembersCount()
            {
                var count = _membersRepository.GetActiveMembersCount();
                return Ok(count);
            }

            [HttpGet]
            public IActionResult GetAllMembers()
            {
                var members = _membersRepository.GetAllMembers();
                return Ok(members);
            }

            [HttpGet("{ID}")]
            public IActionResult GetMembersByID(int ID)
            {
                var members = _membersRepository.GetMembersByID(ID);
                if (members == null)
                    return NotFound();

                return Ok(members);
            }

            [HttpPost]
            public IActionResult CreateMembers(Members newMembers)
            {
                try
                {
                    _membersRepository.CreateMembers(newMembers);
                    return CreatedAtAction(nameof(GetMembersByID), new { ID = newMembers.ID }, newMembers);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPut("{ID}")]
            public IActionResult UpdateMembers(int ID, Members updatedMembers)
            {
                if (ID != updatedMembers.ID)
                    return BadRequest("ID mismatch");

                try
                {
                    _membersRepository.UpdateMembers(updatedMembers);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("{ID}")]
            public IActionResult SoftDeleteMembers(int ID)
            {
                try
                {
                    _membersRepository.SoftDeleteMembers(ID);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

}
