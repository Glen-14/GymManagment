using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    [ApiController]
    [Route("api/Subscriptions")]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionRepository _subscriptionRepository;

        public SubscriptionController(SubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }


        [HttpPost]
        public IActionResult CreateSubscription([FromBody] Subscription subsriptions)
        {
            try
            {
                _subscriptionRepository.CreateSubscription(subsriptions);
                return Ok("Subscriptions created ssuccessfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create subscripitons:{ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult GetAllSubscriptions()
        {
            var subscriptions = _subscriptionRepository.GetAllSubscriptions();
            return Ok(subscriptions);
        }

        [HttpGet("filtered")]
        public IActionResult GetSubscriptionBy(string Code, string description, int numberOfMonths, string weekfrequency)
        {
            var subscriptions = _subscriptionRepository.GetSubscriptionBy(Code, description, numberOfMonths, weekfrequency);
            if (subscriptions == null)
                return NotFound();

            return Ok(subscriptions);
        }

        [HttpPut("{id}")]
        public ActionResult<Subscription> UpdateSubscription(int id, Subscription updatedSubscription)
        {
            if (id != updatedSubscription.Id)
                return BadRequest("ID mismatch");

            try
            {
                return Ok (_subscriptionRepository.UpdateSubscription(updatedSubscription));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{ID}")]
        public IActionResult SoftDeleteSubscription(int ID)
        {
            try
            {
                _subscriptionRepository.SoftDelete(ID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}