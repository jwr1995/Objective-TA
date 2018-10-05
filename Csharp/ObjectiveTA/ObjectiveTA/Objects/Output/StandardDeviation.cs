using System;
using System.Collections.Generic;

namespace ObjectiveTA.Objects.Output
{
    public class StandardDeviation
    {
        private double[] x;
        private double[] xAverage;
        private double sd;
        public StandardDeviation(double[] x, double[] xAverage)
        {
            double y = 0;
            int count = x.Length;
            for (int i = 0; i < count; i++)
            {

            }
            sd = Math.Sqrt(y);
        }
    }
}
