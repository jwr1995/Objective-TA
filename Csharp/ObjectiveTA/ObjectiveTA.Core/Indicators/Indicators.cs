using System;
using System.Collections.ObjectModel;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Objects.Output;

namespace ObjectiveTA.Indicators
{
    /// <summary>
    /// Indicators.
    /// </summary>
    public static partial class Indicators
    {
        /// <summary>
        /// Relatives the index of the strength.
        /// </summary>
        /// <returns>The strength index.</returns>
        /// <param name="candleSticks">Candle sticks.</param>
        /// <param name="period">Period.</param>
        public static RelativeStrengthIndex RelativeStrengthIndex(CandleStickCollection candleSticks, int period = 14,
                                                     PriceSource priceSource = PriceSource.Close)
        {
            int count = candleSticks.Count;
            double[] priceArray = priceSource.GetArrayFromCandleStickCollection(candleSticks);
            double[] rsi = new double[count];

            double[] up = new double[count];
            double[] down = new double[count];
            double[] rs = new double[count];
          
            for (int i = 1; i < count; i++)
            {
                if(priceArray[i]>priceArray[i-1])
                {
                    up[i] = priceArray[i] - priceArray[i - 1];
                }
                else
                {
                    down[i] = priceArray[i - 1] - priceArray[i];
                }
            }

            for (int i = period; i < count; i++)
            {
                rs[i] = MovingAverage.SMMA(up, period, i-period, period).MovingAverage[i] 
                                     / MovingAverage.SMMA(down, period,i-period,period).MovingAverage[i];
                rsi[i] = 100 - 1 / (1 + rs[i]);
            }

            return new RelativeStrengthIndex(rsi);
        }

        /// <summary>
        /// Vortex Indicator Model
        /// </summary>
        /// <returns>The indicator.</returns>
        /// <param name="candleSticks">Candle stick data array.</param>
        /// <param name="period">Period.</param>
        public static VortexIndicator VortexIndicator(CandleStickCollection candleSticks, int period = 14)
        {
            int count = candleSticks.Count;

            double[] sumVMUp = new double[count];
            double[] sumVMDown = new double[count];
            double[] sumTrueRange = new double[count];
            double[] viUP = new double[count];
            double[] viDown = new double[count];

            try 
            {
                for (int j = 0; j < count - period - 2; j++)
                {
                    for (int i = 1 + j; i < 1 + j + period; i++)
                    {
                        // abs(current high - current low)
                        var chcl = Abs(candleSticks[i].High - candleSticks[i].Low);
                        // abs(current low - previous close)
                        var clpc = Abs(candleSticks[i].Low - candleSticks[i - 1].Close);
                        // abs(current high - previous close)
                        var chpc = Abs(candleSticks[i].High - candleSticks[i - 1].Close);

                        //true range
                        var trueRange = Max(chcl, clpc, chpc);

                        var vmUp = Abs(candleSticks[i].High - candleSticks[i - 1].Low);
                        var vmDown = Abs(candleSticks[i].Low - candleSticks[i - 1].High);

                        sumVMUp[j] = sumVMUp[j] + vmUp;
                        sumVMDown[j] = sumVMDown[j] + vmDown;
                        sumTrueRange[j] = sumTrueRange[j] + trueRange;
                    }

                    viUP[j] = sumVMUp[j] / sumTrueRange[j];
                    viDown[j] = sumVMDown[j] / sumTrueRange[j];
                }

                return new VortexIndicator(viUP, viDown);
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }

        public static MovingAverageConvergenceDivergence MACD(CandleStickCollection candleSticks, int fast = 12, int slow = 26, int length = 9,
                                     PriceSource priceSource = PriceSource.Close)
        {
            MovingAverage fastMA = MovingAverages.EMA(candleSticks, fast, priceSource);
            MovingAverage slowMA = MovingAverages.EMA(candleSticks, slow, priceSource);
            double[] macd = SubtractArray(fastMA.MA, slowMA.MA);
            return new MovingAverageConvergenceDivergence(macd, length);
        }
    }
}
