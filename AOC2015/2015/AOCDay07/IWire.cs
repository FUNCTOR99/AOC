using System;

namespace AOC2015
{
    public interface IWire
    {
        string Name { get; set; }

        ushort Signal { get; set; }

        bool HasSignal { get; set; }

        void SetSignal(ushort value);

        string ToString();

        string ToCSV();
    }
}