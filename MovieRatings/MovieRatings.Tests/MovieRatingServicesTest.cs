using Moq;
using MovieRatings.Core.ApplicationService;
using MovieRatings.Core.ApplicationService.Services;
using MovieRatings.Core.DomainService;
using MovieRatings.Core.Entity;
using MovieRatings.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

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
            MovieRating movieRating1 = new MovieRating(1, 0, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 2, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 2, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 2, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetReviewsByReviewer(reviewer);

            Assert.Equal(reviews, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-5, 0)]
        public void GetCountOfReviewersFromReviewerNonExistingReviewer(int reviewer, int reviews)
        {

        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void GetAverageRatingFromReviewerWithCorrectValues(int reviewer, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 0, 1, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 2, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(3, 3, 4, DateTime.Now);
            MovieRating movieRating5 = new MovieRating(3, 3, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(movieRating5);
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
            MovieRating movieRating1 = new MovieRating(1, 0, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
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
            MovieRating movieRating1 = new MovieRating(1, 0, grade, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, grade, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, grade, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, grade, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
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
            MovieRating movieRating1 = new MovieRating(1, 0, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<InvalidDataException>(() =>
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
            MovieRating movieRating1 = new MovieRating(1, 3, 1, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 2, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            int actual = movieRatingService.GetCountOfMovieReviews(movie);

            Assert.Equal(count, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetCountOfMovieReviewsFromMovieNonExistingMovie(int movie)
        {

        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 2.5)]
        public void GetAverageGradeFromMovieWithCorrectValues(int movie, double average)
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 1, 1, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 2, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 2, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 4, DateTime.Now);
            MovieRating movieRating5 = new MovieRating(2, 3, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(movieRating5);
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
            MovieRating movieRating1 = new MovieRating(1, 0, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 1, 4, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 2, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
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
            MovieRating movieRating1 = new MovieRating(2, 2, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 3, 3, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 3, 3, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 3, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
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
            MovieRating movieRating1 = new MovieRating(2, 2, 2, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 3, 3, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(2, 3, 3, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 3, 3, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            Exception e = Assert.Throws<InvalidDataException>(() =>
            {
                movieRatingService.GetCountOfMovieByGrade(movie, grade);
            });
            Assert.True(e.Message == "The grade has to be between 1-5");
        }

        [Fact]
        public void GetTopGradedMoviesFromMoviesWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 6, 5, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(2, 6, 5, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(1, 4, 3, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(1, 5, 4, DateTime.Now);
            MovieRating movieRating5 = new MovieRating(1, 3, 2, DateTime.Now);
            MovieRating movieRating6 = new MovieRating(1, 2, 1, DateTime.Now);
            MovieRating movieRating7 = new MovieRating(2, 2, 1, DateTime.Now);
            MovieRating movieRating8 = new MovieRating(1, 1, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(movieRating5);
            movieRatingRepository.Object.Add(movieRating6);
            movieRatingRepository.Object.Add(movieRating7);
            movieRatingRepository.Object.Add(movieRating8);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<int> expected = new List<int>() { 6, 5, 4, 3, 2 };
            List<int> actual = movieRatingService.GetTopGradedMovies();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReviewersWithMostReviewsWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 6, 5, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(1, 6, 5, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(1, 5, 4, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 4, 3, DateTime.Now);
            MovieRating movieRating5 = new MovieRating(2, 3, 2, DateTime.Now);
            MovieRating movieRating6 = new MovieRating(3, 2, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(movieRating5);
            movieRatingRepository.Object.Add(movieRating6);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<int> expected = new List<int>() { 1, 2, 3 };
            List<int> actual = movieRatingService.GetTopReviewers();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetTopMoviesFromAverageGradeWithCorrectValues()
        {
            var movieRatingRepository = new Mock<FakeMovieRatingRepository>();
            MovieRating movieRating1 = new MovieRating(1, 6, 5, DateTime.Now);
            MovieRating movieRating2 = new MovieRating(1, 6, 5, DateTime.Now);
            MovieRating movieRating3 = new MovieRating(1, 5, 4, DateTime.Now);
            MovieRating movieRating4 = new MovieRating(2, 4, 3, DateTime.Now);
            MovieRating movieRating5 = new MovieRating(2, 3, 2, DateTime.Now);
            MovieRating movieRating6 = new MovieRating(3, 2, 1, DateTime.Now);
            movieRatingRepository.Object.Add(movieRating1);
            movieRatingRepository.Object.Add(movieRating2);
            movieRatingRepository.Object.Add(movieRating3);
            movieRatingRepository.Object.Add(movieRating4);
            movieRatingRepository.Object.Add(movieRating5);
            movieRatingRepository.Object.Add(movieRating6);
            IMovieRatingServices movieRatingService = new MovieRatingServices(movieRatingRepository.Object);

            List<MovieRating> expected = new List<MovieRating>();
            List<MovieRating> actual = movieRatingService.GetTopMovies(2);

            Assert.Equal(expected, actual);
        }
    }
}
