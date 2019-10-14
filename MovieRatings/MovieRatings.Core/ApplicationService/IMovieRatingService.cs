using MovieRatings.Core.Entity;
using System.Collections.Generic;

namespace MovieRatings.Core.ApplicationService
{
    public interface IMovieRatingService
    {
		int GetCountOfMovieReviews(int movie);
		int GetCountOfReviewsByReviewer(int reviewer);
		int GetCountOfMovieByGrade(int movie, int grade);
		int GetCountOfGradesByReviewer(int reviewer, int grade);
		double AverageRatingByReviewer(int reviewer);
        double AverageRatingOnMovie(int movie);
        List<int> GetTopGradedMovies();
        List<int> GetTopReviewers();
        List<int> GetTopMovies(int number);
        List<MovieRating> GetMoviesByReviewer(int reviewer);
        List<MovieRating> GetReviewersByMovie(int movie);
    }
}
