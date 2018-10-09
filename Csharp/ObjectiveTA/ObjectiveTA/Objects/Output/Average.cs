using System;
using ObjectiveTA.Common;
namespace ObjectiveTA.Objects.Output
{
    public class Average
    {
        private double[] input;
        private double value;

        public double Value { get => this.value; set => this.value = value; }
        public double[] Input { get => input; set { input = value; this.value = value.Average(); } }

        public Average(double[] input)
        {
            this.input = input;
            value = input.Average();
        }

        public Average() 
        {
            input = null;
            value = 0;
        }
    }

    public enum AverageType { Mean, MovingAverage }
}
