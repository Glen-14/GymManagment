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

    }
}
