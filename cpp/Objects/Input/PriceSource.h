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
#include "CandleStickCollection.h";

using objectiveTA::objects::input::CandleStick;
using namespace std;

namespace objectiveTA::objects::input {

class PriceSource {
private: enum priceSourceEnum {_open, _high, _low, _close};
public:
	PriceSource Open();
	PriceSource High();
	PriceSource Low();
	PriceSource Close();
	vector<double> GetArrayFromCandleStickCollection(CandleStickCollection cs);
};

} /* namespace objectiveTA */

#endif /* OBJECTS_INPUT_PRICESOURCE_H_ */
