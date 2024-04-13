using GymManagment.Models;
using GymManagment.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Controllers
{
    public class DiscountController : ControllerBase
    {
        private readonly DiscountsRepository _discountsRepository;

        public DiscountController(DiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;
        }
        [HttpPost]
        public IActionResult CreateDiscounts(Discounts newdiscounts)
        {
            try
            {
                _discountsRepository.CreateDiscounts(newdiscounts);
                return CreatedAtAction(nameof(CreateDiscounts), new { ID = newdiscounts.ID }, newdiscounts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetDiscounts()
        {
            var members = _discountsRepository.GetDiscounts();
            return Ok(members);
        }
        [HttpPut("{ID}")]
        public IActionResult Updatediscounts(int ID, Discounts updatedDiscounts)
        {
            
            try
            {
                _discountsRepository.Updatediscounts(updatedDiscounts);
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
                _discountsRepository.SoftDeleteDiscounts(ID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
