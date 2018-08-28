using System;
using System.Linq;
using ObjectiveTA.Core.Trading;

namespace ObjectiveTA.Core.Objects.Output
{
    /// <summary>
    /// Output model for a Vortex Indicator
    /// </summary>
    public class VortexIndicator
    {
        private double[] viUp;
        private double[] viDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:zdxTA.Model.Output.VIModel"/> class.
        /// </summary>
        /// <param name="viUp">Vi up.</param>
        /// <param name="viDown">Vi down.</param>
        public VortexIndicator(double[] viUp, double[] viDown)
        {
            this.VIUp = viUp;
            this.VIDown = viDown;
        }

        /// <summary>
        /// Gets or sets the vi up.
        /// </summary>
        /// <value>The vi up.</value>
        public double[] VIUp { get => viUp; set => viUp = value; }

        /// <summary>
        /// Gets or sets the vi down.
        /// </summary>
        /// <value>The vi down.</value>
        public double[] VIDown { get => viDown; set => viDown = value; }

        public Trend CurrentTrend
        {
            get
            {
                if (VIUp[VIUp.Length - 1] > VIDown[VIDown.Length - 1]) {
                    return Trend.Up;
                }
                else if (VIDown[VIDown.Length - 1] > VIUp[VIUp.Length - 1]) {
                    return Trend.Down;
                }
                else {
                    return Trend.NotFound;
                }
            }
        }

        /// <summary>
        /// Get the Trend at a particular index.
        /// </summary>
        /// <returns>The at index.</returns>
        /// <param name="idx">Index.</param>
        public Trend TrendAtIndex(int idx)
        {
            if (VIUp[idx] > VIDown[idx]) {
                return Trend.Up;
            }
            else if (VIDown[idx] > VIUp[idx]) {
                return Trend.Down;
            }
            else {
                return Trend.NotFound;
            }
        }

        /// <summary>
        /// Gets the change in trend if it has changed
        /// </summary>
        /// <returns>The trend change.</returns>
        /// <param name="period">Period.</param>
        public TrendChange GetTrendChange(int period = 1)
        {
            if (CurrentTrend == TrendAtIndex(VIUp.Length - 1 - period)) {
                return TrendChange.NotChanged;
            } else {
                if (CurrentTrend == Trend.Up) {
                    return TrendChange.Upwards;
                } else {
                    return TrendChange.DownWards;
                }
            }

        }
    }
}
