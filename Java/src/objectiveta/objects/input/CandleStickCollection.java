package objectiveta.objects.input;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

public class CandleStickCollection extends ArrayList<CandleStick> {

	private static final long serialVersionUID = 1L;

	public CandleStickCollection() {}
	
	public CandleStickCollection(CandleStick[] candleSticks)
	{
		int length = candleSticks.length; 
		for (int i = 0; i<length; i++)
		{
			this.add(candleSticks[i]);
		}
	}
	
	public CandleStickCollection(List<CandleStick> candleSticks)
	{
		for (Iterator<CandleStick> cs = candleSticks.iterator(); cs.hasNext();)
		{
			this.add(cs.next());
		}
	}
	
	public CandleStickCollection(Collection<CandleStick> candleSticks)
	{
		for (Iterator<CandleStick> cs = candleSticks.iterator(); cs.hasNext();)
		{
			this.add(cs.next());
		}
	}
}
