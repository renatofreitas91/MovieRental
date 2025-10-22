using Microsoft.AspNetCore.Mvc;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {

        private readonly IRentalFeatures _features;

        public RentalController(IRentalFeatures features)
        {
            _features = features;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Rental.Rental rental)
        {
	        return Ok(_features.SaveAsync(rental));
        }
        [HttpGet("by-customer/{customerName}")]
    public async Task<IActionResult> GetByCustomerName(string customerName)
    {
        var rentals =  _features.GetRentalsByCustomerName(customerName);

        if (rentals == null || !rentals.Any())
            return NotFound($"No rentals found for customer '{customerName}'.");

        return Ok(rentals);
    }
}
	}