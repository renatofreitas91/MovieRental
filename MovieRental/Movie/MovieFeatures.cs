using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public Movie Save(Movie movie)
		{
			_movieRentalDb.Movies.Add(movie);
			_movieRentalDb.SaveChanges();
			return movie;
		}

        // TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?
        /*
		 --> Leaking EF entities outside the data layer.

		--> No AsNoTracking() for read-only queries.

		-->No paging/filtering, which can cause performance and memory issues.
		 
		 */

        // improved using paging or filtering:
        public List<Movie> GetAll()
		{
          return   _movieRentalDb.Movies
    .AsNoTracking()
    .OrderBy(m => m.Title)
    .Take(100)
    .ToList();
        }


	}
}
