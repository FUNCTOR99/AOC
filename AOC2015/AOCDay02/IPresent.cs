namespace AOC2015
{
    public interface IPresent
    {
        // Shouldn't these calculations be double?
        int AreaSmallestSide();
        int TotalSurfaceArea();

        int PerimeterSmallestSide();

        int Volume();
    }
}