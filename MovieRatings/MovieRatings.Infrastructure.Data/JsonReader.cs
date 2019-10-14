using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using MovieRatings.Core.Entity;

namespace MovieRatings.Infrastructure.Data
{
	public class JsonReader
	{
		private const string filePath = @"..\..\..\..\ratings.json";


		public IEnumerable<MovieRating> GetData()
		{
			IEnumerable<MovieRating> movieRatings = JsonConvert.DeserializeObject<IEnumerable<MovieRating>>(File.ReadAllText(filePath));
			return movieRatings;
		}
	}
}
