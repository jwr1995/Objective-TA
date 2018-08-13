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
        public static RSIModel RelativeStrengthIndex(CandleStickCollection candleSticks, int period = 14)
        {
            int count = candleSticks.Count;

            double[] rsi = new double[count];

            for (int j = 0; j < count - period - 2; j++)
            {
                for (int i = 1 + j; i < 1 + period; i++)
                {
                    // TO DO
                }
            }

            return new RSIModel(rsi);
        }

        /// <summary>
        /// Vortex Indicator Model
        /// </summary>
        /// <returns>The indicator.</returns>
        /// <param name="candleSticks">Candle stick data array.</param>
        /// <param name="period">Period.</param>
        public static VIModel VortexIndicator(CandleStickCollection candleSticks, int period = 14)
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

                return new VIModel(viUP, viDown);
            }
            catch (IndexOutOfRangeException e)
            {
                throw e;
            }
        }
    }
}
