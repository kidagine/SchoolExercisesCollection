using System;

namespace MovieRatings.Core.Entity
{
    public class MovieRating
    {
        private int _reviewer;
        private int _movie;
        private int _grade;


        public int Reviewer 
        {
            get 
            {
                return _reviewer;       
            }
            private set 
            {
                if (value < 1) throw new ArgumentException("The reviewer cannot be a negative number");
                _reviewer = value;
            } 
        }
        public int Movie
        {
            get
            {
                return _movie;
            }
            private set
            {
                if (value < 1) throw new ArgumentException("The movie cannot be a negative number");
                _movie = value;
            }
        }
        public int Grade
        {
            get
            {
                return _grade;
            }
            private set
            {
                if (!(value > 0 && value < 6)) throw new ArgumentException("The grade has to be between 1-5");
                _grade = value;
            }
        }

        public DateTime Date { get; private set; }

        public MovieRating(int reviewer, int movie, int grade, DateTime date)
        {
            this.Reviewer = reviewer;
            this.Movie = movie;
            this.Grade = grade;
            this.Date = date;
        }

        public override string ToString()
        {
            return $"{Reviewer, 5} {Movie, 10} {Grade, 5} {Date.ToShortDateString()}";
        }
    }
}
