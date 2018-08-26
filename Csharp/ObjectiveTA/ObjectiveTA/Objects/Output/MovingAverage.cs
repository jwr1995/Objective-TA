using System;
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
    }

    /// <summary>
    /// MA Types:
    /// Simple Moving Average (SMA), Exponential Moving Average (EMA),
    /// Cumulative Moving Average (CMA), Weighted Moving Average (WMA),
    /// Smoothed Moving Average/Running Moving Average (SMMA)
    /// </summary>
    public enum MAType { SMA, EMA, CMA, WMA, SMMA }
}
