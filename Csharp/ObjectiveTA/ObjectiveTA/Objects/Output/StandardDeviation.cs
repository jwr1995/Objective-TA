using System;
using System.Collections.Generic;
using ObjectiveTA.Common;

namespace ObjectiveTA.Objects.Output
{
    public class StandardDeviation
    {
        private double[] x;
        private double[] xAverage;
        private double sd;

        public StandardDeviation(double[] x, double[] xAverage)
        {
            int n = x.Length;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum = sum + (x[i] - xAverage[i]).Squared();
            }
            value = Math.Sqrt(sum/n);
        }

        public double Value { get => sd; set => sd = value; }
    }
}
