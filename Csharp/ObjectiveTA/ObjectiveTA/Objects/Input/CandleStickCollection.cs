using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ObjectiveTA.Model.Input
{
    public class CandleStickCollection : Collection<CandleStick>
    {
        public CandleStickCollection(){}

        public CandleStickCollection(List<CandleStick> candleSticks)
        {
            try
            {
                foreach (CandleStick bin in candleSticks)
                {
                    this.Add(bin);
                }   
            }
            catch (NullReferenceException)
            {
                throw;
            }

        }

        public CandleStickCollection(Collection<CandleStick> candleSticks)
        {
            try
            {
                foreach (CandleStick bin in candleSticks)
                {
                    this.Add(bin);
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }

    }
}
