using System;

namespace ObjectiveTA.Objects.Input
{
    public class CandleStick
    {
        private double open;
        private double high;
        private double low;
        private double close;
        private string timestamp;
        private double? volume;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:zdxTA.Model.CandleStick"/> class.
        /// </summary>
        /// <param name="open">Open.</param>
        /// <param name="high">High.</param>
        /// <param name="low">Low.</param>
        /// <param name="close">Close.</param>
        /// <param name="timestamp">Timestamp.</param>
        /// <param name="volume">Volume.</param>
        public CandleStick(double open, double high, double low, double close, string timestamp = null, double volume = 0)
        {
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
            this.timestamp = timestamp;
            this.volume = volume;
        }

        /// <summary>
        /// Gets or sets the open.
        /// </summary>
        /// <value>The open.</value>
        public double Open { get => open; set => open = value; }

        /// <summary>
        /// Gets or sets the high.
        /// </summary>
        /// <value>The high.</value>
        public double High { get => high; set => high = value; }

        /// <summary>
        /// Gets or sets the low.
        /// </summary>
        /// <value>The low.</value>
        public double Low { get => low; set => low = value; }

        /// <summary>
        /// Gets or sets the close.
        /// </summary>
        /// <value>The close.</value>
        public double Close { get => close; set => close = value; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public string Timestamp { get => timestamp; set => timestamp = value; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>The volume.</value>
        public double? Volume { get => volume; set => volume = value; }

    }

}
