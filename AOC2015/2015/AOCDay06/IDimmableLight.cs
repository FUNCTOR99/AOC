namespace AOC2015
{
    public interface IDimmableLight
    {
        int GetLightBrightness();
        void ToggleLight();
        void TurnOff();
        void TurnOn();
    }
}