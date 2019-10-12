using System;
using System.Collections.Generic;
using MovieRatings.Core.Entity;
using MovieRatings.Core.DomainService;

namespace MovieRatings.Infrastructure.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        //const string filePath = @"..\..\..\..\ratings.json";
        //JsonSerializer js = new JsonSerializer();
        //(MovieRating[]) js.Deserialize(sr, typeof(MovieRating[]));

        public void Add(MovieRating movieRating)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfMovieReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetReviewsByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfMovieByGrade(int movie, int grade)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfGradesByReviewer(int reviewer, int grade)
        {
            throw new NotImplementedException();
        }

        public double AverageRatingByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public double AverageRatingOnMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTopGradedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTopReviewers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTopMovies(int number)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieRating> GetMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieRating> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }
    }
}
