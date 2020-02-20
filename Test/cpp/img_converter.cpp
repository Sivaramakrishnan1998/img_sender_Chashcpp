#include "img_converter.h"
#include <vector>
#include <iostream>
#include <cstdlib>
using namespace std;

bool ReleaseMemoryFromC(unsigned char* buf){
	if (buf == NULL)
		return false;
	free(buf);
	return true;
}


void imagePassChashtoCpp(unsigned char* data, int dataLen, ImageInfo & imInfo){
	vector<unsigned char> bytes(data, data + dataLen);
	imInfo.size = bytes.size();
	imInfo.data = (unsigned char *)calloc(imInfo.size, sizeof(unsigned char));
	std::copy(bytes.begin(), bytes.end(), imInfo.data);
}