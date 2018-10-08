using System;
using ObjectiveTA.Indicators;
using ObjectiveTA.Objects.Input;
using ObjectiveTA.Common;

namespace ObjectiveTA.Objects.Output
{
    public class BollingerBands
    {
        private double[] upperBand, middleBand, lowerBand;

        public BollingerBands(CandleStickCollection candleSticks, int period = 20, 
                              double multiplier = 2, PriceSource priceSource = PriceSource.Close)
        {
            int length = candleSticks.Count-period;
            double[] prices = priceSource.GetArrayFromCandleStickCollection(candleSticks);
            StandardDeviation standardDeviation;

            LowerBand = UpperBand = new double[length];
            MiddleBand = MovingAverages.SMA(candleSticks, period, priceSource).MA;

            for (int i = 0; i < length; i++)
            {
                standardDeviation = new StandardDeviation(prices.GetSegment(i, i+period), MiddleBand.GetSegment(i, i+period));
                UpperBand[i] = MiddleBand[i] + multiplier * standardDeviation.Value;
                LowerBand[i] = MiddleBand[i] - multiplier * standardDeviation.Value;
            }
        }

        public double[] UpperBand { get => upperBand; set => upperBand = value; }
        public double[] MiddleBand { get => middleBand; set => middleBand = value; }
        public double[] LowerBand { get => lowerBand; set => lowerBand = value; }
    }
}
