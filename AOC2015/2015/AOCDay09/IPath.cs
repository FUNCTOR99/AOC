using System.Collections.Generic;

namespace AOC2015
{
    public interface IPath<T>
    {
        int Distance { get; }
        List<T> Ends { get; }
    }
}