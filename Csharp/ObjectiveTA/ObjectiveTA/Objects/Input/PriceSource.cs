using System;
namespace ObjectiveTA.Objects.Input
{
    public enum PriceSource{Open, High, Low, Close}

    static class PriceSourceExtensions
    {
        /// <summary>
        /// Gets the selected price from a candle stick.
        /// </summary>
        /// <returns>The value from candle stick.</returns>
        /// <param name="p">P.</param>
        /// <param name="c">C.</param>
        public static double GetValueFromCandleStick(this PriceSource p, CandleStick c)
        {
            switch(p)
            {
                case PriceSource.Open:
                    return c.Open;
                case PriceSource.High:
                    return c.High;
                case PriceSource.Low:
                    return c.Low;
                case PriceSource.Close:
                    return c.Close;
                default:
                    Exception exception = new Exception("Invalid price source value");
                    throw(exception);
            }
        }

        public static double[] GetArrayFromCandleStickCollection(this PriceSource p, 
                                                                 CandleStickCollection c)
        {
            int count = c.Count;
            double[] priceArray = new double[count];

            switch (p)
            {
                case PriceSource.Open:
                    for (int i = 0; i < count - 1; i++){
                        priceArray[i] = c[i].Open;
                    }
                    return priceArray;
                case PriceSource.High:
                    for (int i = 0; i < count - 1; i++)
                    {
                        priceArray[i] = c[i].High;
                    }
                    return priceArray;
                case PriceSource.Low:
                    for (int i = 0; i < count - 1; i++)
                    {
                        priceArray[i] = c[i].Low;
                    }
                    return priceArray;
                case PriceSource.Close:
                    for (int i = 0; i < count - 1; i++)
                    {
                        priceArray[i] = c[i].Close;
                    }
                    return priceArray;
                default:
                    Exception exception = new Exception("Invalid price source value");
                    throw (exception);
            }
        }

    }
}
