package objectiveta.objects.input;

public class CandleStick {

	private double open;
	private double high;
	private double low;
	private double close;
	
	public CandleStick(){}
	
	public CandleStick(double open, double high, double low, double close) 
	{
		this.open = open;
		this.high = high;
		this.low = low;
		this.close = close;
	}

	public double getOpen() {
		return open;
	}

	public void setOpen(double open) {
		this.open = open;
	}

	double getHigh() {
		return high;
	}

	void setHigh(double high) {
		this.high = high;
	}

	double getLow() {
		return low;
	}

	void setLow(double low) {
		this.low = low;
	}

	public double getClose() {
		return close;
	}

	public void setClose(double close) {
		this.close = close;
	}
	
}
