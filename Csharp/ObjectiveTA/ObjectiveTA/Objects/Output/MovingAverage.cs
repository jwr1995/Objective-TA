using System;
using ObjectiveTA.Indicators;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Trading;

namespace ObjectiveTA.Objects.Output
{
    /// <summary>
    /// Moving Average Model
    /// </summary>
    public class MovingAverage
    {
        private double[] ma;
        private MAType maType;

        public MovingAverage(double[] movingAverage, MAType maType)
        {
            MA = movingAverage;
            this.maType = maType;
        }

        /// <summary>
        /// Gets or sets the moving average as an array of doubles
        /// </summary>
        /// <value>The ma.</value>
        public double[] MA { get => ma; set => ma = value; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count { get => ma.Length; }

        /// <summary>
        /// Gets the type of the ma.
        /// </summary>
        /// <value>The type of the ma.</value>
        public MAType MaType { get => maType; }

        /// <summary>
        /// Indicates if the moving average has broken support
        /// </summary>
        /// <returns><c>true</c>, if broke support was hased, <c>false</c> otherwise.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="support">Support.</param>
        /// <param name="priceSource">Price source.</param>
        public bool HasBrokeSupport(CandleStickCollection candleSticks, double support, 
                                    PriceSource priceSource = PriceSource.Close)
        {
            if (priceSource.GetValueFromCandleStick(candleSticks[candleSticks.Count-1])<support)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Indicates if the moving average has broken resistance
        /// </summary>
        /// <returns><c>true</c>, if broke resistance was hased, <c>false</c> otherwise.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="resistance">Resistance.</param>
        /// <param name="priceSource">Price source.</param>
        public bool HasBrokeResistance(CandleStickCollection candleSticks, double resistance,
                                       PriceSource priceSource = PriceSource.Close)
        {
            if (priceSource.GetValueFromCandleStick(candleSticks[candleSticks.Count - 1]) > resistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double[] GetSegment(int start, int finish)
        {
            if(finish > ma.Length || start < 0 || start > ma.Length)
            {
                IndexOutOfRangeException exception = new IndexOutOfRangeException();
                throw (exception);
            }

            double[] output = new double[finish - start];

            for (int i = 0; i < output.Length;i++)
            {
                output[i] = ma[start + i];
            }

            return output;
        }


    }

    public static class MovingAverageExtensions
    {
        public static MovingAverage GetMovingAverageFromArray(this MAType type, double[] array, int period = 14)
        {
            switch (type)
            {
                case MAType.SMA:
                    return MovingAverages.SMA(array, period);
                case MAType.CMA:
                    return null;
                case MAType.EMA:
                    return null;
                case MAType.SMMA:
                    return null;
                case MAType.WMA:
                    return null;
                default:
                    return null;
            }
        }
    }

    /// <summary>
    /// MA Types:
    /// Simple Moving Average (SMA), Exponential Moving Average (EMA),
    /// Cumulative Moving Average (CMA), Weighted Moving Average (WMA),
    /// Smoothed Moving Average/Running Moving Average (SMMA)
    /// </summary>
    public enum MAType { SMA, EMA, CMA, WMA, SMMA }
}
