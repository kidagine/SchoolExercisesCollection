using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using Moq;
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
        public void GetCountOfReviewsFromReviewerWithCorrectValues(int reviewer, int reviews)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 3, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 1, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 2, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetReviewsByReviewer(reviewer);

            Assert.Equal(reviews, actual);
        }

        [Fact]
        public void GetCountOfReviewersFromReviewerNegativeReviewerThrowsException()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetReviewsByReviewer(-1);
            });
            Assert.True(e.Message == "The reviewer cannot be a negative number");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void GetAverageRatingFromReviewerWithCorrectValues(int reviewer, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 1, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(3, 4, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(3, 5, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            double actual = movieRatingService.AverageRatingByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        public void GetAverageRatingFromReviewerWithNoMovieReviewedReturnsZero(int reviewer, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 4, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            double actual = movieRatingService.AverageRatingByReviewer(reviewer);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 3, 3)]
        public void GetCountOfGradesFromReviewerWithCorrectValues(int reviewer, int grade, int count)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 3, grade, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 1, grade, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, grade, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, grade, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetCountOfGradesByReviewer(reviewer, grade);

            Assert.Equal(count, actual);
        }


        [Theory]
        [InlineData(4, 0)]
        [InlineData(5, 6)]
        public void GetCountOfGradesFromReviewerWithGradeThatDoesntExistThrowsException(int reviewer, int grade)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 3, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetCountOfGradesByReviewer(reviewer, grade);
            });
            Assert.True(e.Message == "The grade has to be between 1-5");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void GetCountOfMovieReviewsFromMovieWithCorrectValues(int movie, int count)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 3, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 1, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetCountOfMovieReviews(movie);

            Assert.Equal(count, actual);
        }

        [Fact]
        public void GetCountOfMovieReviewsFromNegativeMovieThrowsException()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetCountOfMovieReviews(-1);
            });
            Assert.True(e.Message == "The movie cannot be a negative number");
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void GetAverageGradeFromMovieWithCorrectValues(int movie, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 1, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            double actual = movieRatingService.AverageRatingOnMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        public void GetAverageGradeFromMovieWithNoMovieReviewedReturnsZero(int movie, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 1, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 1, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            double actual = movieRatingService.AverageRatingOnMovie(movie);

            Assert.Equal(average, actual);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 2, 1)]
        [InlineData(3, 3, 3)]
        public void GetCountOfMoviesByGradeFromMovieWithCorrectValues(int movie, int grade, int count)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetCountOfMovieByGrade(movie, grade);

            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(4, 0)]
        [InlineData(5, 6)]
        public void GetCountOfMoviesByGradeFromMovieWithGradeThatDoesntExistThrowsException(int movie, int grade)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 3, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetCountOfMovieByGrade(movie, grade);
            });
            Assert.True(e.Message == "The grade has to be between 1-5");
        }

        [Fact]
        public void GetTopGradedMoviesFromMoviesWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 4, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 5, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 3, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 2, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 2, 1, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 1, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<int> expected = new List<int>() { 6, 5, 4, 3, 2 };
            List<int> actual = movieRatingService.GetTopGradedMovies();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReviewersWithMostReviewsWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 5, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 4, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<int> expected = new List<int>() { 1, 2, 3 };
            List<int> actual = movieRatingService.GetTopReviewers();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMoviesFromAverageGradeWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 5, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 6, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(1, 5, 4, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 4, 3, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(2, 3, 2, DateTime.Now));
            movieRatingRepository.Object.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<MovieRating> expected = new List<MovieRating>();
            List<MovieRating> actual = movieRatingService.GetTopMovies(2);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMoviesByReviewerFromReviewerSortedByGradeAndThenByDateWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRating movieRating2 = new MovieRating(1, 2, 5, DateTime.Now.AddYears(3));
            MovieRating movieRating3 = new MovieRating(1, 3, 4, DateTime.Now.AddYears(3));
            MovieRating movieRating4 = new MovieRating(1, 4, 3, DateTime.Now.AddYears(2));
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<MovieRating> expected = new List<MovieRating>() { movieRating1, movieRating2, movieRating3, movieRating4};
            List<MovieRating> actual = movieRatingService.GetMoviesByReviewer(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetMoviesByReviewerFromReviewerSortedByGradeAndThenByDateWithNegativeReviewerThrowsException()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetMoviesByReviewer(-1);
            });
            Assert.True(e.Message == "The reviewer cannot be a negative number");
        }

        [Fact]
        public void GetReviewersByReviewedMovieSortedByGradeAndThenByDateMovieWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 1, 5, DateTime.Now.AddYears(4));
            MovieRating movieRating2 = new MovieRating(2, 1, 5, DateTime.Now.AddYears(3));
            MovieRating movieRating3 = new MovieRating(3, 1, 4, DateTime.Now.AddYears(3));
            MovieRating movieRating4 = new MovieRating(4, 1, 3, DateTime.Now.AddYears(2));
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(new MovieRating(3, 2, 1, DateTime.Now));
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<MovieRating> expected = new List<MovieRating>() { movieRating1, movieRating2, movieRating3, movieRating4 };
            List<MovieRating> actual = movieRatingService.GetReviewersByMovie(1);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReviewersByReviewedMovieSortedByGradeAndThenByDateMovieWithNegativeMovieThrowsException()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<ArgumentException>(() =>
            {
                movieRatingService.GetReviewersByMovie(-1);
            });
            Assert.True(e.Message == "The movie cannot be a negative number");
        }
    }
}
