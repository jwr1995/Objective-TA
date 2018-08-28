/*
 * CandleStickCollection.h
 *
 *  Created on: 28 Aug 2018
 *      Author: will
 */


#ifndef OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_
#define OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_

#include "CandleStick.h";
#include <iostream>;
#include <vector>;

using objectiveta_objects_input::CandleStick;
using namespace std;

namespace objectiveta_objects_input {

class CandleStickCollection: vector<CandleStick> {

public:
	CandleStickCollection();
	CandleStickCollection(CandleStick candleSticks[]);
	virtual ~CandleStickCollection();
};

} /* namespace objectiveta_objects_input */

#endif /* OBJECTIVE_TA_OBJECTS_INPUT_CANDLESTICKCOLLECTION_H_ */
