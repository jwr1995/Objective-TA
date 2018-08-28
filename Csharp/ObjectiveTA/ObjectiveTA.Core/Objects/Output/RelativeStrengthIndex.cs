using System;
using ObjectiveTA.Core.Trading;

namespace ObjectiveTA.Core.Objects.Output
{
    public class RelativeStrengthIndex
    {
        private double[] rsi;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rsiInput"></param>
        public RelativeStrengthIndex(double[] rsiInput)
        {
            rsi = rsiInput;
        }

        /// <summary>
        /// Gets or sets the rsi.
        /// </summary>
        /// <value>The rsi.</value>
        public double[] RSI { get => rsi;}

        /// <summary>
        /// Gets the latest value.
        /// </summary>
        /// <value>The latest value.</value>
        public double LatestValue { get => rsi[rsi.Length-1];}

        /// <summary>
        /// Gets a trade signal based on uppder threshold or lower threshold set by the user
        /// </summary>
        /// <returns>A trade signal.</returns>
        /// <param name="lowerBound">Lower bound.</param>
        /// <param name="upperBound">Upper bound.</param>
        /// <exception cref="T:System.Exception"></exception>
        public Signal GetTradeSignal(double lowerBound, double upperBound)
        {
            if (lowerBound > upperBound)
            {
                Exception exception = new Exception("Lower bound must be less than upper bound");
                throw(exception);
            }

            if (LatestValue < lowerBound)
            {
                return Signal.Buy;
            }
            else if (LatestValue > upperBound)
            {
                return Signal.Sell;
            }
            else
            {
                return Signal.DoNothing;
            }
        }
    }
}
