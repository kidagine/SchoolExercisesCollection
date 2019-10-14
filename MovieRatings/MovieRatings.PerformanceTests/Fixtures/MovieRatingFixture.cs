using System;
using MovieRatings.Infrastructure.Data;
using MovieRatings.Core.ApplicationService.Services;
using MovieRatings.Infrastructure.Data.Repositories;

namespace MovieRatings.PerformanceTests.Fixtures
{
	public class MovieRatingFixture : IDisposable
	{
		public MovieRatingService MovieRatingService { get; private set; }

		public MovieRatingFixture()
		{
			JsonReader jsonReader = new JsonReader();
			MovieRatingRepository movieRatingRepository = new MovieRatingRepository(jsonReader);
			MovieRatingService = new MovieRatingService(movieRatingRepository);
		}

		public void Dispose()
		{
			MovieRatingService = null;
		}
	}
}
