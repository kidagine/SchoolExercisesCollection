using System;

namespace TeenagerChecker.Core
{
    public class TeenagerCheck : ITeenagerCheck
    {
        public bool Result { get; private set; }


        public bool IsTeenager(DateTime birthday)
        {
            int yearDifference = DateTime.Now.Year - birthday.Year;
            if (yearDifference >= 13 && yearDifference <= 19)
            {
                Result = true;
            }
            else
            {
                Result = false;
            }
            return Result;
        }
    }
}
