using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRatings.Core.Entity
{
    public class MovieRating
    {
        private int _reviewer;
        public int Reviewer 
        {
            get 
            {
                return _reviewer;       
            }
            private set 
            {
                if (value <= 0) throw new ArgumentException("Invalid reviewer id!!!!!!!!!!!!");
                _reviewer = value;
            } 
        }
        public int Movie { get; private set; }
        public int Grade { get; private set; }
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
