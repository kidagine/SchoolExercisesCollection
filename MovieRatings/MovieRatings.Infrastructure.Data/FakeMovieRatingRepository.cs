using System;
using System.Linq;
using System.Collections.Generic;
using MovieRatings.Core.Entity;
using MovieRatings.Core.DomainService;


namespace MovieRatings.Infrastructure.Data
{
    public class FakeMovieRatingRepository : IMovieRatingRepository
    {
        readonly private List<MovieRating> movieRatings = new List<MovieRating>();


        public void Add(MovieRating movieRating)
        {
            movieRatings.Add(movieRating);    
        }

        public int GetCountOfMovieReviews(int movie)
        {
            return movieRatings.Where(mr => mr.Movie == movie).Count();
        }

        public int GetReviewsByReviewer(int reviewer)
        {
            return movieRatings.Where(mr => mr.Reviewer == reviewer).Count();
        }

        public int GetCountOfMovieByGrade(int movie, int grade)
        {
            return movieRatings.Where(mr => mr.Movie == movie).Where(mr => mr.Grade == grade).Count();
        }

        public int GetCountOfGradesByReviewer(int reviewer, int grade)
        {
            return movieRatings.Where(mr => mr.Reviewer == reviewer).Where(mr => mr.Grade == grade).Count();
        }

        public double AverageRatingByReviewer(int reviewer)
        {
            return movieRatings.Where(mr => mr.Reviewer == reviewer).Select(mr => mr.Grade).DefaultIfEmpty(0).Average();
        }

        public double AverageRatingOnMovie(int movie)
        {
            return movieRatings.Where(mr => mr.Movie == movie).Select(mr => mr.Grade).DefaultIfEmpty(0).Average();
        }

        public IEnumerable<int> GetTopGradedMovies()
        {
            return movieRatings.OrderByDescending(mr => mr.Grade).Select(mr => mr.Movie).Distinct().Take(5);
        }    

        public IEnumerable<int> GetTopReviewers()
        {
            return movieRatings.GroupBy(mr => mr.Reviewer).OrderByDescending(mr => mr.Count()).Select(mr => mr.Key);
        }

        public IEnumerable<MovieRating> GetTopMovies(int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieRating> GetMoviesByReviewer(int reviewer)
        {
            return movieRatings.Where(mr => mr.Reviewer == reviewer).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date);
        }

        public IEnumerable<MovieRating> GetReviewersByMovie(int movie)
        {
            return movieRatings.Where(mr => mr.Movie == movie).OrderByDescending(mr => mr.Grade).ThenByDescending(mr => mr.Date);
        }
    }   
}
