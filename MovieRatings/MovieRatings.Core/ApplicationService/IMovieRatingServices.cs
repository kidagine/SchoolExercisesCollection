using MovieRatings.Core.Entity;
using System.Collections.Generic;

namespace MovieRatings.Core.ApplicationService
{
    public interface IMovieRatingServices
    {
        int GetReviewsByReviewer(int reviewer);
        double AverageRatingByReviewer(int reviewer);
        int GetCountOfGradesByReviewer(int reviewer, int grade);
        int GetCountOfMovieReviews(int movie);
        double AverageRatingOnMovie(int movie);
        int GetCountOfMovieByGrade(int movie, int grade);
        List<int> GetTopGradedMovies();
        List<int> GetTopReviewers();
        List<int> GetTopMovies(int number);
        List<MovieRating> GetMoviesByReviewer(int reviewer);
        List<MovieRating> GetReviewersByMovie(int movie);
    }
}
