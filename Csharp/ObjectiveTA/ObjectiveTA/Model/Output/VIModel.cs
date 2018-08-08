using System;
using System.Linq;
using ObjectiveTA.Trading;

namespace ObjectiveTA.Model.Output
{
    /// <summary>
    /// Output model for a Vortex Indicator
    /// </summary>
    public class VIModel
    {
        private double[] viUp;
        private double[] viDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:zdxTA.Model.Output.VIModel"/> class.
        /// </summary>
        /// <param name="viUp">Vi up.</param>
        /// <param name="viDown">Vi down.</param>
        public VIModel(double[] viUp, double[] viDown)
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


        public Signal GetTradeSignal(int period = 2)
        {
            if (CurrentTrend == TrendAtIndex(VIUp.Length-period)) {
                return Signal.DoNothing;
            } else {
                if (CurrentTrend == Trend.Up) {
                    return Signal.Buy;
                } else {
                    return Signal.Sell;
                }
            }

        }

    }

}
