namespace AOC2015
{
    public interface ILight
    {
        bool IsLightOn();
        void ToggleLight();
        void TurnOff();
        void TurnOn();
    }
}