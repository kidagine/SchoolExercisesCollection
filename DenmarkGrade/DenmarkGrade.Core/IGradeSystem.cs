namespace DenmarkGrade.Core
{
    public interface IGradeSystem
    {
        int Result { get; }

        int ToGrade(int percentage);
    }
}
