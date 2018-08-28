/*
 * CandleStickCollection.h
 *
 *  Created on: 28 Aug 2018
 *      Author: will
 */


#ifndef OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_
#define OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_

#include <iostream>;
#include <vector>;
#include "CandleStick.h"

using objectiveTA::objects::input::CandleStick;
using namespace std;

namespace objectiveTA::objects::input {

class CandleStickCollection: vector<CandleStick> {

public:
	CandleStickCollection();
	CandleStickCollection(CandleStick candleSticks[]);
	virtual ~CandleStickCollection();
};

} /* namespace objectiveta_objects_input */

#endif /* OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_ */
