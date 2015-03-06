
#include <XBee.h>

/*
This example is for Series 2 XBee
 Sends a ZB TX request with the value of analogRead(pin5) and checks the status response for success
*/

// create the XBee object
XBee xbee = XBee();

uint8_t payload2[] = { "message received" };
uint8_t *buffer;
      
XBeeAddress64 addr64 = XBeeAddress64(0, 0);
ZBTxRequest zbTx1 = ZBTxRequest(addr64, buffer, sizeof(buffer));
ZBTxRequest zbTx2 = ZBTxRequest(addr64, payload2, sizeof(payload2));
ZBTxStatusResponse txStatus = ZBTxStatusResponse();
ZBRxResponse zbRx = ZBRxResponse();

int pin5 = 0;

int statusLed = 13;
int errorLed = 13;
int i = 0;

void flashLed(int pin, int times, int wait) {

  for (int i = 0; i < times; i++) {
    digitalWrite(pin, HIGH);
    delay(wait);
    digitalWrite(pin, LOW);

    if (i + 1 < times) {
      delay(wait);
    }
  }
}

void setup() {
  //init Serial stream and tie to xbee
  Serial.begin(9600);
  xbee.begin(Serial);
  
  //use buffer to fill with several hundred characters
  int charCount = 72;
  buffer = (uint8_t*)malloc(charCount*sizeof(uint8_t));
  
  for(int i = 0; i<charCount;i++)
  {
    *(buffer+i) = 'a';
  }

  zbTx1 = ZBTxRequest(addr64, buffer, charCount*sizeof(uint8_t));
  xbee.send(zbTx1);
}

void loop() 
{   
 
}

