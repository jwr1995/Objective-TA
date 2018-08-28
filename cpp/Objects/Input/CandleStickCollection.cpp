/*
 * CandleStickCollection.cpp
 *
 *  Created on: 28 Aug 2018
 *      Author: will
 */

#include "CandleStickCollection.h"

namespace objectiveTA::objects::input {

CandleStickCollection::CandleStickCollection() {
	this->vector<CandleStick>();
}

CandleStickCollection::CandleStickCollection(CandleStick candleSticks[]) {
	for (int i = 0; i<sizeof(candleSticks); i++)
	{
		this->push_back(candleSticks[i]);
	}
}

CandleStickCollection::~CandleStickCollection() {
	delete this;
}

} /* namespace objectiveta_objects_input */
