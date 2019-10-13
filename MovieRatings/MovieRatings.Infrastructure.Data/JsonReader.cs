using MovieRatings.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MovieRatings.Infrastructure.Data
{
	public class JsonReader
	{
		private const string filePath = @"..\..\..\..\ratings.json";
		private IEnumerable<MovieRating> movieRatings;


		public void LoadData()
		{
		}

		public IEnumerable<MovieRating> GetData()
		{
			IEnumerable<MovieRating> movieRatings = JsonConvert.DeserializeObject<IEnumerable<MovieRating>>(File.ReadAllText(filePath));
			return movieRatings;
		}
	}
}
