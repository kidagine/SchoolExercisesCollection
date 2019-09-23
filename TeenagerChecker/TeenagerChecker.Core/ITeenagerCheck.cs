using System;

namespace TeenagerChecker.Core
{
    public interface ITeenagerCheck
    {
        bool Result { get; }

        bool IsTeenager(DateTime birthday);
    }
}
