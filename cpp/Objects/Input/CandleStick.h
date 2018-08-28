/*
 * CandleStick.cpp
 *
 *  Created on: 27 Aug 2018
 *      Author: William Ravenscroft
 *   Copyright: Objective-TA, 2018
 */

#ifndef OBJECTS_INPUT_CANDLESTICK_H_
#define OBJECTS_INPUT_CANDLESTICK_H_

namespace objectiveta_objects_input {

class CandleStick {

private: double _open, _high, _low, _close;

public:
	CandleStick();
	CandleStick(double open, double high, double low, double close);
	double getOpen();
	double getHigh();
	double getLow();
	double getClose();
	virtual ~CandleStick();
};

} /* namespace objectiveta_objects_input */
#endif /* OBJECTS_INPUT_CANDLESTICK_H_ */
