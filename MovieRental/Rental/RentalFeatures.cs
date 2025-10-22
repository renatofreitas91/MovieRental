using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		//TODO: make me async :)
		public async Task<Rental> SaveAsync(Rental rental)
		{
				await _movieRentalDb.Rentals.AddAsync(rental);
				await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it
		public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		{
            return  _movieRentalDb.Rentals
       .Where(r => r.Customer.Name == customerName)
       .ToList();
        }

	}
}
