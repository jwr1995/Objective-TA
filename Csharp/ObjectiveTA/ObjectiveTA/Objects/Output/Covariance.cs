using System;
using ObjectiveTA.Common;

namespace ObjectiveTA.Objects.Output
{
    public class Covariance
    {
        private double value;

        public Covariance(double[] x, double[] y)
        {
            int n;
            double sum = 0;

            if (x.Length > y.Length)
            {
                n = x.Length;
            }
            else
            {
                n = y.Length;
            }



            for (int i = 0; i < n; i++)
            {
                sum = sum + (x[i] - y[i]).Squared();
            }

            this.value = sum / n;
        }

        public double Value { get => value; }
    }
}
