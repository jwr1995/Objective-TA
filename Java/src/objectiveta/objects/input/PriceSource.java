package objectiveta.objects.input;

public enum PriceSource{
	Open,
	High, 
	Low, 
	Close;
	
	public double GetValueFromCandleStick(CandleStick c) throws Exception
	{
		switch(this)
        {
            case Open:
                return c.getOpen();
            case High:
                return c.getHigh();
            case Low:
                return c.getLow();
            case Close:
                return c.getClose();
            default:
                Exception exception = new Exception("Invalid price source value");
                throw(exception);
        }	
	}
}

