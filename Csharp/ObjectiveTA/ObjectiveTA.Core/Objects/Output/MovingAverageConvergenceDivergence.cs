using System;
using ObjectiveTA.Core.Indicators;

namespace ObjectiveTA.Objects.Output
{
    public class MovingAverageConvergenceDivergence
    {
        private double[] macd;
        private double[] macdSignalLine;
        private double[] macdHistogram;
        private int length;


        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:ObjectiveTA.Objects.Output.MovingAverageConvergenceDivergence"/> class.
        /// </summary>
        /// <param name="macd">Macd.</param>
        /// <param name="length">Length.</param>
        public MovingAverageConvergenceDivergence(double[] macd, int length)
        {
            this.length = length;
            MACD = macd;
            macdSignalLine = MovingAverages.EMA(macd, length).MA;
            macdHistogram = SubtractArray(MACD, MACDSignalLine);
        }

        /// <summary>
        /// Gets or sets the MACD line.
        /// </summary>
        /// <value>The MACD line.</value>
        public double[] MACD
        {
            get => macd;
            set
            {
                macd = value;
                macdSignalLine = MovingAverages.EMA(macd, length).MA;
                macdHistogram = SubtractArray(MACD, MACDSignalLine);
            }
        }

        /// <summary>
        /// Gets the MACD Signal line.
        /// </summary>
        /// <value>The MACD Signal line.</value>
        public double[] MACDSignalLine { get => macdSignalLine; }

        /// <summary>
        /// Gets the MACD Histogram.
        /// </summary>
        /// <value>The MACD Histogram.</value>
        public double[] MACDHistogram { get => macdHistogram; }

        private double[] SubtractArray(double[] first, double[] second)
        {
            double[] output = new double[first.Length];

            for (int i = 0; i < first.Length; i++)
            {
                output[i] = first[i] - second[i];
            }

            return output;
        }
    }
}
