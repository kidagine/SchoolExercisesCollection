using System;

namespace DenmarkGrade.Core
{
    public class GradeSystem : IGradeSystem
    {
        public int Result { get; private set; }


        public int ToGrade(int percentage)
        {
            switch (percentage)
            {
                case int i when (i >= 0 && i <= 7):
                    Result = -3;
                    break;
                case int i when (i >= 8 && i <= 33):
                    Result = 0;
                    break;
                case int i when (i >= 34 && i <= 41):
                    Result = 2;
                    break;
                case int i when (i >= 42 && i <= 57):
                    Result = 4;
                    break;
                case int i when (i >= 58 && i <= 77):
                    Result = 7;
                    break;
                case int i when (i >= 78 && i <= 89):
                    Result = 10;
                    break;
                case int i when (i >= 90 && i <= 100):
                    Result = 12;
                    break;
                default:
                    throw new ArgumentException("The percentage is outside the allowed range");
            }
            return Result;
        }
    }
}
