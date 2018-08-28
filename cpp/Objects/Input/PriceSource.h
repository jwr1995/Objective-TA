/*
 * PriceSource.h
 *
 *  Created on: 28 Aug 2018
 *      Author: will
 */

#ifndef OBJECTS_INPUT_PRICESOURCE_H_
#define OBJECTS_INPUT_PRICESOURCE_H_

#include <iostream>;
#include <vector>;
#include "CandleStick.h";

using objectiveTA::objects::input::CandleStick;
using namespace std;

namespace objectiveTA::objects::input {

enum class PriceSourceEnum {
	open, high, low, close
};

class PriceSource : public PriceSourceEnum {
public:
	vector<double> GetArrayFromCandleSticks(CandleStick cs);
};

} /* namespace objectiveTA */

#endif /* OBJECTS_INPUT_PRICESOURCE_H_ */
