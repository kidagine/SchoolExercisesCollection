using System;

namespace CprNumberAgeChecker.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Type your cpr-number");
			string cprNumber = Console.ReadLine();
			string day = cprNumber.Substring(0,2);
			string month = cprNumber.Substring(2, 2);
			string year = cprNumber.Substring(4, 2);

			Console.WriteLine($"day: {day} month: {month} year: {year}");
			Console.WriteLine("Your age is: " + GetAge(cprNumber));
		}

		static int GetAge(string cprNumber)
		{
			int age;
			int day = int.Parse(cprNumber.Substring(0, 2));
			int month = int.Parse(cprNumber.Substring(2, 2));
			int year = int.Parse(cprNumber.Substring(4, 2));
			int controlDigit = int.Parse(cprNumber.Substring(6, 1));
			DateTime birthdate;

			if (controlDigit >= 3 & controlDigit < 0)
			{
				birthdate = new DateTime(int.Parse($"19{year}"), month, day);
				age = DateTime.Now.Year - birthdate.Year;
			}
			else if (controlDigit >= 4 & controlDigit <= 5)
			{
				if (year < 37)
				{
					birthdate = new DateTime(int.Parse($"20{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;
				}
				else
				{
					birthdate = new DateTime(int.Parse($"19{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;
				}
			}
			else if (controlDigit >= 5 & controlDigit <= 8)
			{
				if (year <= 57)
				{
					birthdate = new DateTime(int.Parse($"20{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;
				}
				else
				{
					birthdate = new DateTime(int.Parse($"18{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;
				}
			}
			else
			{
				if (year <= 36)
				{
					birthdate = new DateTime(int.Parse($"20{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;

				}
				else
				{
					birthdate = new DateTime(int.Parse($"19{year}"), month, day);
					age = DateTime.Now.Year - birthdate.Year;
				}
			}
			if (birthdate > DateTime.Now.AddYears(-age))
			{
				age--;
			}
			return age;
		}
	}
}
