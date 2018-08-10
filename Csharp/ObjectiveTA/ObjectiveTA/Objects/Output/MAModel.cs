using System;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Trading;

namespace ObjectiveTA.Objects.Output
{
    /// <summary>
    /// Moving Average Model
    /// </summary>
    public class MAModel
    {
        private double[] movingAverage;
        private MAType maType;

        public MAModel(double[] movingAverage, MAType maType)
        {
            MovingAverage = movingAverage;
            this.maType = maType;
        }

        public double[] MovingAverage { get => movingAverage; set => movingAverage = value; }
        public MAType MaType { get => maType; }

        public bool HasBrokeSupport(CandleStickCollection candleSticks, double support, int period = 2)
        {
            return true;
        }

        public bool HasBrokeResistance(CandleStickCollection candleSticks, double resistance, int period = 2)
        {
            return true;
        }
    }

    /// <summary>
    /// MA Types:
    /// Simple Moving Average (SMA), Exponential Moving Average (EMA),
    /// Cumulative Moving Average (CMA), Weighted Moving Average (WMA),
    /// Running Moving Average/Smoothed Moving Average/Modified Moving Average (RMA)
    /// </summary>
    public enum MAType { SMA, EMA, CMA, WMA, RMA }
}
