using System.Drawing;

namespace AOC2015
{
    public interface IHouse
    {
        Point Location { get; set; }

        void DeliverPresent();
        bool Equals(House other);
        int GetPresentCount();
    }
}