using System;
using System.Collections.Generic;
using ObjectiveTA.Common;

namespace ObjectiveTA.Objects.Output
{
    public class StandardDeviation
    {
        private double sd;

        public StandardDeviation(double[] x, double[] y)
        {
            double sigsq = new Covariance(x, y).Value;
            sd = Math.Sqrt(sigsq);
        }

        public StandardDeviation(double[] x, MAType type = MAType.SMA, int period = 14)
        {
            double var = new Variance(x: x, period: period, type: type).Value;
            sd = Math.Sqrt(var);
        }

        public StandardDeviation(double[] x)
        {
            double var = new Variance(x).Value;
            sd = Math.Sqrt(var);
        }

        public StandardDeviation(Variance variance)
        {
            sd = Math.Sqrt(variance.Value);
        }

        public StandardDeviation(Covariance covariance)
        {
            sd = Math.Sqrt(covariance.Value);
        }

        public double Value { get => sd; }
    }
}
