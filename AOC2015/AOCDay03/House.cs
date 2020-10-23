using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2015
{
    public class House : IHouse, IEquatable<House>
    {
        public Point Location { get; set; }
        int _presentCount;

        public House(Point location)
        {
            Location = location;
            _presentCount = 0;
        }

        public void DeliverPresent()
        {
            _presentCount++;
        }

        public int GetPresentCount()
        {
            return _presentCount;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;
            House otherAsHouse = other as House;
            if (otherAsHouse == null)
                return false;
            else
                return Equals(otherAsHouse);
        }

        public bool Equals(House other)
        {
            if (Location == other.Location)
                return true;
            else
                return false;
        }
    }
}
