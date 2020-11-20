using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Light : ILight
    {
        Boolean _lightOn = false;

        public void TurnOn()
        {
            _lightOn = true;
        }

        public void TurnOff()
        {
            _lightOn = false;
        }

        public void ToggleLight()
        {
            _lightOn = !_lightOn;
        }

        public bool IsLightOn()
        {
            return _lightOn;
        }
    }
}
