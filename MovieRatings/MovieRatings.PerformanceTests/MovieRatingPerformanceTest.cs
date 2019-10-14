using System.Diagnostics;
using Xunit;
using MovieRatings.PerformanceTests.Fixtures;

namespace MovieRatings.PerformanceTests
{
	public class MovieRatingPerformanceTest : IClassFixture<MovieRatingFixture>
	{
		private readonly MovieRatingFixture _movieRatingFixture;


		public MovieRatingPerformanceTest(MovieRatingFixture movieRatingFixture)
		{
			_movieRatingFixture = movieRatingFixture;
		}

		[Fact]
		public void GetCountOfReviewsByReviewer_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetCountOfReviewsByReviewer(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void AverageRatingByReviewer_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.AverageRatingByReviewer(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetCountOfGradesByReviewer_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetCountOfGradesByReviewer(1, 1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}
		
		[Fact]
		public void GetCountOfMovieReviews_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetCountOfMovieReviews(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void AverageRatingOnMovie_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.AverageRatingOnMovie(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetCountOfMoviesByGrade_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetCountOfMovieByGrade(1, 1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetTopGradedMovies_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetTopGradedMovies();
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetTopReviewers_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetTopReviewers();
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetTopMovies_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetTopMovies(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetMoviesByReviewer_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetMoviesByReviewer(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}

		[Fact]
		public void GetReviewersByMovie_LessThanFourSeconds()
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			_movieRatingFixture.MovieRatingService.GetReviewersByMovie(1);
			stopwatch.Stop();

			Assert.True(stopwatch.Elapsed.TotalSeconds < 4);
		}
	}
}
