using System;
using System.Collections.Generic;
using System.Text;
using MovieRatings.Core.DomainService;
using MovieRatings.Core.Entity;
using Newtonsoft.Json;

namespace MovieRatings.Infrastructure.Data
{
    public class MovieRatingRepository : IMovieRatingRepository
    {
        //const string filePath = @"..\..\..\..\ratings.json";
        //JsonSerializer js = new JsonSerializer();
        //(MovieRating[]) js.Deserialize(sr, typeof(MovieRating[]));
        public double AverageRatingByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public double AverageRatingOnMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfGradesByReviewer(int reviewer, int grade)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfMovieReviews(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetCountOfMovieByGrade(int movie, int grade)
        {
            throw new NotImplementedException();
        }

        public List<MovieRating> GetMoviesByReviewer(int reviewer)
        {
            throw new NotImplementedException();
        }

        public List<MovieRating> GetReviewersByMovie(int movie)
        {
            throw new NotImplementedException();
        }

        public int GetReviewsByReviewer(int reviewer)
        {
            int count = 0;
            return count;
        }

        public List<int> GetTopGradedMovies()
        {
            throw new NotImplementedException();
        }

        public List<MovieRating> GetTopMovies(int number)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTopReviewers()
        {
            throw new NotImplementedException();
        }
    }
}
