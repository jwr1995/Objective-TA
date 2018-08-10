using System;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Objects.Output;

namespace ObjectiveTA.Indicators
{
    public static class MovingAverage
    {
        /// <summary>
        /// Simple Moving Average
        /// </summary>
        /// <returns>The sma.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="period">Time period (size of candlestick time inerval * period)</param>
        public static MAModel SMA(CandleStickCollection candleSticks,int period = 14)
        {
            int count = candleSticks.Count;
            double[] sma = new double[count];

            for (int j = 0; j < count - period - 1; j++)
            {
                double sum = 0;

                for (int i = j; i < j + period - 1; i++)
                {
                    sum = sum + candleSticks[i].Close;
                }

                sma[j + period - 1] = sum/period;
            }
            
            return new MAModel(sma, MAType.SMA);
        }
    }
}
