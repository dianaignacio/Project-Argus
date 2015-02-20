#include <XBee.h>

//global
XBee xbee = new XBee();

//array should not exceed 80 bytes. limit is at least this much, but may vary due to firmware configurations
uint8_t payload[] = {0,0};

void setup(){
  xbee.begin(9600);
}

void loop(){
  
}
