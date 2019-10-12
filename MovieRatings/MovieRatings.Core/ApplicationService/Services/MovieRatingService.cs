using System;
using System.Linq;
using System.Collections.Generic;
using MovieRatings.Core.Entity;
using MovieRatings.Core.DomainService;

namespace MovieRatings.Core.ApplicationService.Services
{
    public class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieRatingRepository _movieRatingRepository;

        public MovieRatingService(IMovieRatingRepository movieRatingRepository)
        {
            _movieRatingRepository = movieRatingRepository;
        }

        public int GetCountOfMovieReviews(int movie)
        {
            if (movie < 1)
            {
                throw new ArgumentException("The movie cannot be a negative number");
            }
            return _movieRatingRepository.GetCountOfMovieReviews(movie);
        }

        public int GetReviewsByReviewer(int reviewer)
        {
            if (reviewer < 1)
            {
                throw new ArgumentException("The reviewer cannot be a negative number");
            }
            return _movieRatingRepository.GetReviewsByReviewer(reviewer);
        }

        public int GetCountOfMovieByGrade(int movie, int grade)
        {
            if (!(grade > 0 && grade < 6))
            {
                throw new ArgumentException("The grade has to be between 1-5");
            }
            return _movieRatingRepository.GetCountOfMovieByGrade(movie, grade);
        }

        public int GetCountOfGradesByReviewer(int reviewer, int grade)
        {
            if (!(grade > 0 && grade < 6))
            {
                throw new ArgumentException("The grade has to be between 1-5");
            }
            return _movieRatingRepository.GetCountOfGradesByReviewer(reviewer, grade);
        }

        public double AverageRatingByReviewer(int reviewer)
        {
            return _movieRatingRepository.AverageRatingByReviewer(reviewer);
        }

        public double AverageRatingOnMovie(int movie)
        {
            return _movieRatingRepository.AverageRatingOnMovie(movie);
        }

        public List<int> GetTopGradedMovies()
        {
            return _movieRatingRepository.GetTopGradedMovies().ToList();
        }

        public List<int> GetTopReviewers()
        {
            return _movieRatingRepository.GetTopReviewers().ToList();
        }

        public List<int> GetTopMovies(int number)
        {
            return _movieRatingRepository.GetTopMovies(number).ToList();
        }

        public List<MovieRating> GetMoviesByReviewer(int reviewer)
        {
            if (reviewer < 1)
            {
                throw new ArgumentException("The reviewer cannot be a negative number");
            }
            return _movieRatingRepository.GetMoviesByReviewer(reviewer).ToList();
        }

        public List<MovieRating> GetReviewersByMovie(int movie)
        {
            if (movie < 1)
            {
                throw new ArgumentException("The movie cannot be a negative number");
            }
            return _movieRatingRepository.GetReviewersByMovie(movie).ToList();
        }
    }
}
