using MovieRatings.Core.ApplicationService.Services;
using MovieRatings.Infrastructure.Data.Repositories;
using System;
using System.Diagnostics;

namespace MovieRatings.Performance
{
	class MovieRatingPerformance
	{
		static void Main(string[] args)
		{
				Console.WriteLine("-Setting up-");
			Stopwatch stopwatch = new Stopwatch();
			MovieRatingRepository movieRatingRepository = new MovieRatingRepository();
			MovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);
   
			Console.WriteLine("-Starting performance tests-");
			Console.WriteLine();
			Console.WriteLine("GetReviewsByReviewer");
			PrintTimeInSeconds(() => movieRatingService.GetReviewsByReviewer(1), 5);
			Console.WriteLine("AverageRatingByReviewer");
			PrintTimeInSeconds(() => movieRatingService.AverageRatingByReviewer(1), 5);
			Console.WriteLine("GetCountofGradesByReviewer");
			PrintTimeInSeconds(() => movieRatingService.GetCountOfGradesByReviewer(1, 1), 5);
			Console.WriteLine("GetCountOfMoviesByReviews");
			PrintTimeInSeconds(() => movieRatingService.GetCountOfMovieReviews(1), 5);
			Console.WriteLine("AverageRatingOnMovie");
			PrintTimeInSeconds(() => movieRatingService.AverageRatingOnMovie(1), 5);
			Console.WriteLine("GetCountOfMovieByGrade");
			PrintTimeInSeconds(() => movieRatingService.GetCountOfMovieByGrade(1, 1), 5);
			Console.WriteLine("GetTopGradedMovies");
			PrintTimeInSeconds(() => movieRatingService.GetTopGradedMovies(), 5);
			Console.WriteLine("GetTopReviewers");
			PrintTimeInSeconds(() => movieRatingService.GetTopReviewers(), 5);
			Console.WriteLine("GetTopMovies");
			PrintTimeInSeconds(() => movieRatingService.GetTopMovies(1), 5);
			Console.WriteLine("GetMoviesByReviewer");
			PrintTimeInSeconds(() => movieRatingService.GetMoviesByReviewer(1), 5);
			Console.WriteLine("GetReviewersByMovie");
			PrintTimeInSeconds(() => movieRatingService.GetReviewersByMovie(1), 5);
			Console.WriteLine("Press any key to close.");
			Console.ReadLine();


		}

		static void PrintTimeInSeconds(Action actions, int repeats)
		{
			for (int i = 0; i < repeats; i++)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				actions.Invoke();
				stopwatch.Stop();
				Console.WriteLine("    Time = {0:f5}", stopwatch.ElapsedMilliseconds / 1000.0);
			}
			Console.WriteLine();
		}
	}
}
