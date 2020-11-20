using System.Drawing;

namespace AOC2015
{
    public interface ILightInstruction
    {
        LightCommand Command { get; set; }
        Point FromPoint { get; set; }
        Point ToPoint { get; set; }
    }
}