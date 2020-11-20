using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class DimmableLight : IDimmableLight
    {
        Int32 _brightness = 0;

        public void TurnOn()
        {
            _brightness++;
        }

        public void TurnOff()
        {
            _brightness--;

            if (_brightness < 0)
                _brightness = 0;
        }

        public void ToggleLight()
        {
            _brightness = _brightness + 2;
        }

        public Int32 GetLightBrightness()
        {
            return _brightness;
        }
    }
}
