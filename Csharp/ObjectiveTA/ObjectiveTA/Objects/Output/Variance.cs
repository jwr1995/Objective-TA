using System;
using ObjectiveTA.Common;
using ObjectiveTA.Indicators;

namespace ObjectiveTA.Objects.Output
{
    public class Variance
    {
        private double value;

        public Variance(double[] x, double[] xAverage)
        {
            double sum = 0;
            int n = xAverage.Length;
            int m = x.Length - n;

            for (int i = 0; i < n; i++)
            {
                sum = sum + (x[i+m] - xAverage[i]).Squared();
            }

            this.value = sum / n;
        }

        public Variance(double[] x, MAType type = MAType.SMA, int period = 14)
        {
            MovingAverage xAvg = type.GetMovingAverageFromArray(x);

            double sum = 0;
            int n = xAvg.Count;
            int m = x.Length - n;

            for (int i = 0; i < n; i++)
            {
                sum = sum + (x[i+m] - xAvg.MA[i]).Squared();
            }

            this.value = sum / n;
        }

        public double Value { get => this.value; }
    }
}
