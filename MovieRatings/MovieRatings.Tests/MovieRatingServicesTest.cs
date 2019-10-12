using System;
using System.Collections.Generic;
using Xunit;
using MovieRatings.Core.Entity;
using MovieRatings.Infrastructure.Data;
using MovieRatings.Core.ApplicationService;
using MovieRatings.Core.ApplicationService.Services;

namespace MovieRatings.Tests
{
    public class MovieRatingServicesTest
    {
        [Theory]
        [InlineData(3, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        public void GetReviewsByReviewer_ValidNumber_ReturnsReviewsOfReviewer(int reviewer, int reviews)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 2, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.GetReviewsByReviewer(reviewer);

            Assert.Equal(reviews, actual);
        }

        [Fact]
        public void GetReviewsByReviewer_InvalidNumber_ThrowsArguementException()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetReviewsByReviewer(-1);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void AverageRatingByReviewer_ValidNumber_ReturnsAverageRatingOfReviewer(int reviewer, double average)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 1, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(3, 4, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(3, 5, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.AverageRatingByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        public void AverageRatingByReviewer_ZeroNumber_ReturnsAverageRatingZero(int reviewer, double average)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 4, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.AverageRatingByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 3)]
        public void GetCountOfGradesByReviewer_TwoValidNumbers_ReturnsAmountOfGradesOfReviewer(int reviewer, int grade, int count)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 3, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 1, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, grade, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, grade, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.GetCountOfGradesByReviewer(reviewer, grade);

            Assert.Equal(count, actual);
        }


        [Theory]
        [InlineData(4, 0)]
        [InlineData(5, 6)]
        public void GetCountOfGradesByReviewer_TwoInvalidNumbers_ThrowsArguementException(int reviewer, int grade)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            MovieRating movieRating1 = new MovieRating(1, 3, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 1, DateTime.Now);
            movieRatingRepository.Add(movieRating1);
            movieRatingRepository.Add(movieRating2);
            movieRatingRepository.Add(movieRating3);
            movieRatingRepository.Add(movieRating4);
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetCountOfGradesByReviewer(reviewer, grade);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void GetCountOfMovieReviews_ValidNumber_ReturnsAmountOfMovieReviews(int movie, int count)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 3, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 1, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.GetCountOfMovieReviews(movie);

            Assert.Equal(count, actual);
        }

        [Fact]
        public void GetCountOfMovieReviews_NegativeNumber_ThrowsArguementException()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetCountOfMovieReviews(-1);

            Assert.Throws<ArgumentException>(actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void AverageRatingOnMovie_ValidNumber_ReturnsAverageRatingOfMovie(int movie, double average)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 1, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.AverageRatingOnMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        public void AverageRatingOnMovie_ValidNumber_ReturnsAverageRatingZero(int movie, double average)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 1, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            double actual = movieRatingService.AverageRatingOnMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 3, 3)]
        public void GetCountOfMoviesByGrade_TwoValidNumbers_ReturnsAmountOfMoviesOfGrade(int movie, int grade, int count)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            int actual = movieRatingService.GetCountOfMovieByGrade(movie, grade);

            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(4, 0)]
        [InlineData(5, 6)]
        public void GetCountOfMoviesByGrade_TwoInvalidNumbers_ThrowsArguementException(int movie, int grade)
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetCountOfMovieByGrade(movie, grade);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetTopGradedMovies_Valid_ReturnsTopGradedMovies()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 4, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 5, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 1, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 6, 5, 4, 3, 2, 1 };
            List<int> actual = movieRatingService.GetTopGradedMovies();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopReviewers_Valid_ReturnsReviewersWithMostAmountOfReviews()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 5, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 4, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 1, 2, 3 };
            List<int> actual = movieRatingService.GetTopReviewers();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMovies_ValidNumber_ReturnsTopMoviesBasedOnAverateRating()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            movieRatingRepository.Add(new MovieRating(1, 7, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 6, 1, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 6, 4, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(1, 5, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 4, 2, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<int> expected = new List<int>() { 7, 6, 5, 3, 4 };
            List<int> actual = movieRatingService.GetTopMovies(5);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMoviesByReviewer_ValidNumber_ReturnsMovieRatingsOfReviewerSorted()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            MovieRating movieRating1 = new MovieRating(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRating movieRating2 = new MovieRating(1, 2, 5, DateTime.Now.AddYears(3));
            MovieRating movieRating3 = new MovieRating(1, 3, 4, DateTime.Now.AddYears(3));
            MovieRating movieRating4 = new MovieRating(1, 4, 3, DateTime.Now.AddYears(2));
            movieRatingRepository.Add(movieRating1);
            movieRatingRepository.Add(movieRating2);
            movieRatingRepository.Add(movieRating3);
            movieRatingRepository.Add(movieRating4);
            movieRatingRepository.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<MovieRating> expected = new List<MovieRating>() { movieRating1, movieRating2, movieRating3, movieRating4 };
            List<MovieRating> actual = movieRatingService.GetMoviesByReviewer(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMoviesByReviewer_NegativeNumber_ThrowsArguementException()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetMoviesByReviewer(-1);

            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void GetReviewersByMovie_ValidNumber_ReturnsMovieRatingsOfMovieSorted()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            MovieRating movieRating1 = new MovieRating(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRating movieRating2 = new MovieRating(2, 1, 5, DateTime.Now.AddYears(3));
            MovieRating movieRating3 = new MovieRating(3, 1, 4, DateTime.Now.AddYears(3));
            MovieRating movieRating4 = new MovieRating(4, 1, 3, DateTime.Now.AddYears(2));
            movieRatingRepository.Add(movieRating1);
            movieRatingRepository.Add(movieRating2);
            movieRatingRepository.Add(movieRating3);
            movieRatingRepository.Add(movieRating4);
            movieRatingRepository.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            List<MovieRating> expected = new List<MovieRating>() { movieRating1, movieRating2, movieRating3, movieRating4 };
            List<MovieRating> actual = movieRatingService.GetReviewersByMovie(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReviewersByMovie_NegativeNumber_ThrowsArguementException()
        {
            FakeMovieRatingRepository movieRatingRepository = new FakeMovieRatingRepository();
            IMovieRatingService movieRatingService = new MovieRatingService(movieRatingRepository);

            Action actual = () => movieRatingService.GetReviewersByMovie(-1);

            Assert.Throws<ArgumentException>(actual);
        }
    }
}
