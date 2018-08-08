using System;

namespace ObjectiveTA.Trading
{
    public enum Signal
    {
        Buy = 1,
        DoNothing = 0,
        Sell = -1
    }

    public enum SignalStrength
    {
        StrongBuy = 2,
        WeakBuy = 1,
        DoNothing = 0,
        WeakSell = -1,
        StrongSell = -2
    }
}
