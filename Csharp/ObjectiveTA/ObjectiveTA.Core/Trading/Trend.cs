using System;
namespace ObjectiveTA.Core.Trading
{
    /// <summary>
    /// Trend.
    /// </summary>
    public enum Trend
    {
        Up = 1, 
        Down = -1, 
        Sideways = 0,
        Converging = 2,
        Diverging = 3,
        NotFound = 4
    }

    /// <summary>
    /// Trend changed
    /// </summary>
    public enum TrendChange
    {
        Upwards = 1,
        NotChanged = 0,
        DownWards = -1
    }
}
