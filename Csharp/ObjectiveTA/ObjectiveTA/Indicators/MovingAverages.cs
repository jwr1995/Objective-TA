using System;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Objects.Output;
using ObjectiveTA.Common;

namespace ObjectiveTA.Indicators
{
    public static class MovingAverages
    {
        /// <summary>
        /// Simple Moving Average
        /// </summary>
        /// <returns>The SMA.</returns>
        /// <param name="candleSticks">Candle stick data</param>
        /// <param name="period">Time period (size of candlestick time inerval * period)</param>
        /// <param name="priceSource">Price Source (enum: open, high, low, close)</param>
        public static MovingAverage SMA(CandleStickCollection candleSticks, int period = 14, 
                                  PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] priceArray = priceSource.GetArrayFromCandleStickCollection(candleSticks);
            double[] sma = new double[count];
            double sum = priceArray.GetSegment(0, period - 1).Sum();

            sma[period-1] = sum/period;

            for (int j = period; j < count - 1; j++)
            {
                // No more iterating required for the other sums
                sum = sum - priceArray[j - period] + priceArray[j];
                sma[j] = sum/period;
            }

            return new MovingAverage(sma, MAType.SMA);
        }

        public static MovingAverage SMA(double[] inputArray, int period = 14)
        {
            int count = inputArray.Length;

            double[] sma = new double[count];
            double sum = inputArray[0];

            // Compute the first sum
            for (int i = 1; i < period - 1; i++)
            {
                sum = sum + inputArray[i];
            }

            sma[period - 1] = sum / period;

            for (int j = period; j < count - 1; j++)
            {
                // No more iterating required for the other sums
                sum = sum - inputArray[j - period] + inputArray[j];
                sma[j] = sum / period;
            }

            return new MovingAverage(sma, MAType.SMA);
        }

        /// <summary>
        /// Exponential Moving Average
        /// </summary>
        /// <returns>The EMA.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="period">Period.</param>
        /// <param name="priceSource">Price source.</param>
        public static MovingAverage EMA(CandleStickCollection candleSticks, int period = 14,
                                  PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] ema = new double[count];

            double w = 1 / period;

            // Set intial value to first price value
            ema[0] = priceSource.GetValueFromCandleStick(candleSticks[0]);

            for (int i = 1; i < count; i++)
            {
                ema[i] = w * priceSource.GetValueFromCandleStick(candleSticks[i])
                                        + (1.0 - w)*ema[i-1];
            }

            return new MovingAverage(ema, MAType.EMA);
        }

        /// <summary>
        /// Ema the specified inputArray and period.
        /// </summary>
        /// <returns>The ema.</returns>
        /// <param name="inputArray">Input array.</param>
        /// <param name="period">Period.</param>
        public static MovingAverage EMA(double[] inputArray, int period = 14)
        {
            int count = prices.Length;
            double[] ema = new double[count];

            double w = 1 / period;

            // Set intial value to first price value
            ema[0] = prices[0];

            for (int i = 1; i < count; i++)
            {
                ema[i] = w * prices[i] + (1.0 - w) * ema[i - 1];
            }

            return new MovingAverage(ema, MAType.EMA);
        }


        /// <summary>
        /// Cumulative Moving Average
        /// </summary>
        /// <returns>The CMA.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="priceSource">Price source.</param>
        public static MovingAverage CMA(CandleStickCollection candleSticks,
                                  PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] cma = new double[count];
            double[] priceArray = priceSource.GetArrayFromCandleStickCollection(candleSticks);
            cma[0] = priceArray[0];

            for (int i = 1; i < count; i++)
            {
                cma[i] = cma[i - 1] + (priceArray[i] - cma[i - 1]) / (double)i;
            }

            return new MovingAverage(cma, MAType.CMA);
        }

        /// <summary>
        /// Cumulative Moving Average
        /// </summary>
        /// <returns>The CMA.</returns>
        /// <param name="inputArray">.</param>
        public static MovingAverage CMA(double[] inputArray)
        {
            int count = inputArray.Length;
            double[] cma = new double[count];
            cma[0] = inputArray[0];

            for (int i = 1; i < count; i++)
            {
                cma[i] = cma[i - 1] + (inputArray[i] - cma[i - 1]) / (double)i;
            }

            return new MovingAverage(cma, MAType.CMA);
        }

        /// <summary>
        /// Weighted Moving Average
        /// </summary>
        /// <returns>The wma.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="priceSource">Price source.</param>
        public static MovingAverage WMA(CandleStickCollection candleSticks, int weight =14,
                                  PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] priceArray = priceSource.GetArrayFromCandleStickCollection(candleSticks);
            double[] wma = new double[count];
            double[] weights = new double[weight];
            double sum = weight * (weight + 1) / 2;

            for (int i = 0; i < weight; i++)
            {
                weights[i] = i / sum;
            }

            for (int i = weight-1; i < count; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    wma[i] = wma[i] + priceArray[j + i] * weight;
                }
            }

            return new MovingAverage(wma, MAType.WMA);
        }

        /// <summary>
        /// Wma the specified inputArray and weight.
        /// </summary>
        /// <returns>The wma.</returns>
        /// <param name="inputArray">Input array.</param>
        /// <param name="weight">Weight.</param>
        public static MovingAverage WMA(double[] inputArray, int weight = 14)
        {
            int count = inputArray.Length;
            double[] wma = new double[count];
            double[] weights = new double[weight];
            double sum = weight * (weight + 1) / 2;

            for (int i = 0; i < weight; i++)
            {
                weights[i] = i / sum;
            }

            for (int i = weight - 1; i < count; i++)
            {
                for (int j = 0; j < weight; j++)
                {
                    wma[i] = wma[i] + inputArray[j + i] * weight;
                }
            }

            return new MovingAverage(wma, MAType.WMA);
        }

        /// <summary>
        /// Smoothed Moving Average/Running Moving Average
        /// </summary>
        /// <returns>The smma.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="period">Period.</param>
        /// <param name="priceSource">Price source.</param>
        public static MovingAverage SMMA(CandleStickCollection candleSticks, int period = 14,
                                   PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] smma = new double[count];
            double[] priceArray = priceSource.GetArrayFromCandleStickCollection(candleSticks);

            double sum = priceArray[0];

            //Iterate for first sum over period n
            for (int i = 0; i < period - 1; i++)
            {
                sum = sum + priceArray[i];
            }

            // First n values are zero
            smma[period-1] = sum / period;

            for (int i = period; i < count; i++)
            {
                // No need to iterate through every sum
                sum = sum - priceArray[i - period] + priceArray[i];

                smma[i] = (sum - smma[0] + priceArray[i]) / (double)period;
            }

            return new MovingAverage(smma, MAType.SMMA);
        }

        /// <summary>
        /// Smoothed Moving Average/Running Moving Average
        /// </summary>
        /// <returns>The smma.</returns>
        /// <param name="values">Input values</param>
        /// <param name="period">Period.</param>
        public static MovingAverage SMMA(double[] values, int period = 14, int startIndex = 0, int length = 0)
        {

            if (length == 0)
            {
                length = values.Length;
            }

            if (length < period)
            {
                Exception exception = new Exception("Input must equal too or larger than the period");
                throw (exception);
            }

            double[] smma = new double[length];

            double sum = values[startIndex];

            //Iterate for first sum over period n
            for (int i = startIndex; i < startIndex + period - 1; i++)
            {
                sum = sum + values[i];
            }

            // First n values are zero
            smma[startIndex + period - 1] = sum / period;

            for (int i = startIndex + period; i < startIndex + length; i++)
            {
                // No need to iterate through every sum
                sum = sum - values[i - period] + values[i];

                smma[i] = (sum - smma[0] + values[i]) / (double)period;
            }

            return new MovingAverage(smma, MAType.SMMA);
        }
    }



}
