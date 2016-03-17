#include <iostream>
#include <string.h>
using namespace std;

#include "..\Lib\hamster.h"

int main(void)
{
	int ec = hamster_init();
	uint32_t maxSize = 256;
	
	char* k1 = "k1";
	char* v1 = "Red August";
	h_value_t* h_value = NULL;
	h_value = hamster_value_new(v1, strlen(v1) , maxSize);
	ec = hamster_set(k1, h_value);
	hamster_value_free(h_value);

	char* k2 = "k2";
	char* v2 = "Orange September";
	h_value = hamster_value_new(v2, strlen(v2) , maxSize);
	ec = hamster_set(k2, h_value);
	hamster_value_free(h_value);

	char* k3 = "k3";
	char* v3 = "Blue October";
	h_value = hamster_value_new(v3, strlen(v3) , maxSize);
	ec = hamster_set(k3, h_value);
	hamster_value_free(h_value);
	
	char* pResult = NULL;

	h_value_t* r_value;
	r_value = hamster_value_empty();
	ec = hamster_get(k1, r_value);
	pResult = (char*)r_value->ptr;

	r_value = hamster_value_empty();
	ec = hamster_get(k2, r_value);
	pResult = (char*)r_value->ptr;

	r_value = hamster_value_empty();
	ec = hamster_get(k3, r_value);
	pResult = (char*)r_value->ptr;

	char* k2t = "k2";
	char* v2t = "Orange September ttt";
	h_value = hamster_value_new(v2t, strlen(v2t) , maxSize);
	ec = hamster_set(k2t, h_value);
	hamster_value_free(h_value);
		
	r_value = hamster_value_empty();
	ec = hamster_get(k2t, r_value);
	pResult = (char*)r_value->ptr;
	
	/*
	char* k1 = "k1";
	char* pResult = NULL;
	h_value_t* r_value;
	r_value = hamster_value_empty();
	ec = hamster_get(k1, r_value);
	pResult = (char*)r_value->ptr;
	*/
	//hamster_shutdown();
	return 0;
}