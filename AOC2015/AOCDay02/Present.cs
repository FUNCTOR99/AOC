using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2015
{
    // I think this should also be an abstract class.
    // No need to repeat the area and volume calculations in each class that implements the IPresent Interface 
    // 
    public class Present : IPresent
    {
        int _length;
        int _width;
        int _height;

        public Present(int length, int width, int height)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        public int TotalSurfaceArea()
        {
            return (2 * _length * _width) + (2 * _length * _height) + (2 * _height * _width);
        }

        public int AreaSmallestSide()
        {
            if ((_length >= _width) && (_length >= _height))
            {
                return _width * _height;
            }
            else if ((_width >= _length) && (_width >= _height))
            {
                return _length * _height;
            }
            else if ((_height >= _width) && (_height >= _length))
            {
                return _width * _length;
            }
            else
                return 0;
        }

        public int PerimeterSmallestSide()
        {
            if ((_length >= _width) && (_length >= _height))
            {
                return (_width*2) +  (_height*2);
            }
            else if ((_width >= _length) && (_width >= _height))
            {
                return (_length*2) +  (_height*2);
            }
            else if ((_height >= _width) && (_height >= _length))
            {
                return (_width*2) +  (_length*2);
            }
            else
                return 0;
        }

        public int Volume()
        {
            return _length * _width * _height;
        }
    }
}
