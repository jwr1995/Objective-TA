/*
 * CandleStick.cpp
 *
 *  Created on: 27 Aug 2018
 *      Author: William Ravenscroft
 *   Copyright: Objective-TA, 2018
 */

#include "CandleStick.h"

CandleStick::CandleStick() {
	this->_open = 0.0;
	this->_high = 0;
	this->_low = 0;
	this->_close = 0;
}

CandleStick::CandleStick(double open, double high, double low, double close) {
	this->_open = open;
	this->_high = high;
	this->_low = low;
	this->_close = close;
}

CandleStick::~CandleStick() {
	delete _open;
	delete _high;
	delete _low;
	delete _close;
	delete this;
}

