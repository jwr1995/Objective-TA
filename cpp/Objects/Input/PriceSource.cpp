/*
 * PriceSource.cpp
 *
 *  Created on: 28 Aug 2018
 *      Author: will
 */

#include "PriceSource.h"

namespace objectiveTA::objects::input {


PriceSource PriceSource::Open() {
	this->priceSourceEnum::_open;
	return this;
}

PriceSource PriceSource::High() {
	this->priceSourceEnum::_high;
	return this;
}

PriceSource PriceSource::Low() {
	this->priceSourceEnum::_low;
	return this;
}

PriceSource PriceSource::Close() {
	this->priceSourceEnum::_close;
	return this;
}

vector<double> PriceSource::GetArrayFromCandleStickCollection(CandleStickCollection cs) {
	vector<double> priceArray = new vector<double>;

	switch(this->priceSourceEnum)
	{
		case priceSourceEnum::_open:
			break;
		case priceSourceEnum::_high:
			break;
		case priceSourceEnum::_low:
			break;
		case priceSourceEnum::_close:
			break;
	}

	for(int i = 0; i < static_cast<int>(cs.size()); i++) {

	}
	return priceArray;
}

} /* namespace objectiveTA */
