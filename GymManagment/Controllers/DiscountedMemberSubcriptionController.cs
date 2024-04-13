using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    [ApiController]
    [Route("api/DiscountedMemberSubscription")]
    public class DiscountedMemberSubcriptionController : ControllerBase
    {
        private readonly DiscountedMemberSubscriptionRepository _discountedMemberSubscriptionRepository;

        public DiscountedMemberSubcriptionController(DiscountedMemberSubscriptionRepository discountedMemberSubscriptionRepository)
        {
            _discountedMemberSubscriptionRepository = discountedMemberSubscriptionRepository;
        }

        [HttpPost]
        public IActionResult CreateDiscountedMemberSubscriptions(DiscountedMemberSubscription newDiscountedMemberSubscription)
        {
            try
            {
                _discountedMemberSubscriptionRepository.CreateDiscountedMemberSubscriptions(newDiscountedMemberSubscription);
                return CreatedAtAction(nameof(CreateDiscountedMemberSubscriptions), new { ID = newDiscountedMemberSubscription.ID }, newDiscountedMemberSubscription);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var members = _discountedMemberSubscriptionRepository.GetDiscounts();
            return Ok(members);
        }
        [HttpPut("{ID}")]
        public IActionResult UpdateDiscountedMemberSubscription(int ID, DiscountedMemberSubscription updatedDiscounts)
        {

            try
            {
                _discountedMemberSubscriptionRepository.UpdateDiscountedMemberSubscription(updatedDiscounts);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{ID}")]
        public IActionResult SoftDeleteDiscounts(int ID)
        {
            try
            {

                _discountedMemberSubscriptionRepository.SoftDiscountedMemberSubscriptions(ID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

