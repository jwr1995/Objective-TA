using System;
namespace ObjectiveTA.Objects.Input
{
    public enum PriceSource{Open, High, Low, Close}

    static class PriceSourceExtensions
    {
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
    }
}
