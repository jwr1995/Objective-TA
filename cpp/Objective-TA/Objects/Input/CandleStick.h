/*
 * CandleStick.cpp
 *
 *  Created on: 27 Aug 2018
 *      Author: William Ravenscroft
 *   Copyright: Objective-TA, 2018
 */

#ifndef OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICK_H_
#define OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICK_H_

class CandleStick {

public: double _open, _high, _low, _close;

public:
	CandleStick();
	CandleStick(double open, double high, double low, double close);
	virtual ~CandleStick();
};

#endif /* OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICK_H_ */
