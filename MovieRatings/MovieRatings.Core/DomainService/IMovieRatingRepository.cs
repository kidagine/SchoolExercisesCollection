using MovieRatings.Core.Entity;
using System.Collections.Generic;

namespace MovieRatings.Core.DomainService
{
    public interface IMovieRatingRepository
    {
		int GetCountOfMovieReviews(int movie);
		int GetCountOfReviewsByReviewer(int reviewer);
		int GetCountOfMovieByGrade(int movie, int grade);
		int GetCountOfGradesByReviewer(int reviewer, int grade);
		double AverageRatingByReviewer(int reviewer);
        double AverageRatingOnMovie(int movie);
        IEnumerable<int> GetTopGradedMovies();
        IEnumerable<int> GetTopReviewers();
        IEnumerable<int> GetTopMovies(int number);
        IEnumerable<MovieRating> GetMoviesByReviewer(int reviewer);
        IEnumerable<MovieRating> GetReviewersByMovie(int movie);
    }
}
