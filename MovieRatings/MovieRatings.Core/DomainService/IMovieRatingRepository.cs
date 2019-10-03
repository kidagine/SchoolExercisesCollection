using MovieRatings.Core.Entity;
using System.Collections.Generic;

namespace MovieRatings.Core.DomainService
{
    public interface IMovieRatingRepository
    {
        int GetReviewsByReviewer(int reviewer);
        double AverageRatingByReviewer(int reviewer);
        int GetCountOfGradesByReviewer(int reviewer, int grade);
        int GetCountOfMovieReviews(int movie);
        double AverageRatingOnMovie(int movie);
        int GetCountOfMovieByGrade(int movie, int grade);
        IEnumerable<int> GetTopGradedMovies();
        IEnumerable<int> GetTopReviewers();
        IEnumerable<MovieRating> GetTopMovies(int number);
        IEnumerable<MovieRating> GetMoviesByReviewer(int reviewer);
        IEnumerable<MovieRating> GetReviewersByMovie(int movie);
    }
}
