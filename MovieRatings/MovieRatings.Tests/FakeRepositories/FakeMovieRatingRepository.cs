using System.Linq;
using System.Collections.Generic;
using MovieRatings.Core.Entity;
using MovieRatings.Core.DomainService;

namespace MovieRatings.Tests.FakeRepositories
{
	public class FakeMovieRatingRepository : IMovieRatingRepository
	{
		readonly private List<MovieRating> _movieRatings = new List<MovieRating>();


		public void Add(MovieRating movieRating)
		{
			_movieRatings.Add(movieRating);
		}

		public int GetCountOfMovieReviews(int movie)
		{
			return _movieRatings.Where(mr => mr.Movie == movie).Count();
		}

		public int GetCountOfReviewsByReviewer(int reviewer)
		{
			return _movieRatings.Where(mr => mr.Reviewer == reviewer).Count();
		}

		public int GetCountOfMovieByGrade(int movie, int grade)
		{
			return _movieRatings.Where(mr => mr.Movie == movie).Where(mr => mr.Grade == grade).Count();
		}

		public int GetCountOfGradesByReviewer(int reviewer, int grade)
		{
			return _movieRatings.Where(mr => mr.Reviewer == reviewer).Where(mr => mr.Grade == grade).Count();
		}

		public double AverageRatingByReviewer(int reviewer)
		{
			return _movieRatings.Where(mr => mr.Reviewer == reviewer).Select(mr => mr.Grade).DefaultIfEmpty(0).Average();
		}

		public double AverageRatingOnMovie(int movie)
		{
			return _movieRatings.Where(mr => mr.Movie == movie).Select(mr => mr.Grade).DefaultIfEmpty(0).Average();
		}

		public IEnumerable<int> GetTopGradedMovies()
		{
			return _movieRatings.OrderByDescending(mr => mr.Grade).Select(mr => mr.Movie).Distinct();
		}

		public IEnumerable<int> GetTopReviewers()
		{
			return _movieRatings.GroupBy(mr => mr.Reviewer).OrderByDescending(mr => mr.Count()).Select(mr => mr.Key);
		}

		public IEnumerable<int> GetTopMovies(int number)
		{
			return _movieRatings.OrderByDescending(mr => mr.Grade).Select(mr => mr.Movie).Distinct().Take(number);
		}

		public IEnumerable<MovieRating> GetMoviesByReviewer(int reviewer)
		{
			return _movieRatings.Where(mr => mr.Reviewer == reviewer).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date);
		}

		public IEnumerable<MovieRating> GetReviewersByMovie(int movie)
		{
			return _movieRatings.Where(mr => mr.Movie == movie).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date);
		}
	}
}
