
#include <XBee.h>

/*
This example is for Series 2 XBee
 Sends a ZB TX request with the value of analogRead(pin5) and checks the status response for success
*/

// create the XBee object
XBee xbee = XBee();

uint8_t payload2[] = { "port 3" };
uint8_t *buffer;
      
XBeeAddress64 coord1 = XBeeAddress64(0, 0);
XBeeAddress64 coord2 = XBeeAddress64(0x0013A200, 0x40C1BC5F);
XBeeAddress64 broadcast = XBeeAddress64(0, 0x0000FFFF);

ZBTxRequest zbTx1 = ZBTxRequest(coord1, payload2, sizeof(buffer));
ZBTxRequest zbTx2 = ZBTxRequest(coord1, payload2, sizeof(payload2));
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
  //initializes pin as output
  pinMode(statusLed, OUTPUT);
  pinMode(errorLed, OUTPUT);

  Serial3.begin(9600);
  xbee.begin(Serial3);
  //controlLed(statusLed,0);
  digitalWrite(statusLed,LOW);

  Serial.begin(115200);
  

}

void loop() {   
  // break down 10-bit reading into two bytes and place in payload
  //pin5 = analogRead(5);
  //payload[0] = pin5 >> 8 & 0xff;
  //payload[1] = pin5 & 0xff;

  //xbee.send(zbTx);


  // flash TX indicator
//  flashLed(statusLed, 1, 100);

  // after sending a tx request, we expect a status response
  // wait up to half second for the status response
  /*if(i == 0){
    xbee.send(zbTx1);
    i++;
  }
*/
 // xbee.readPacketUntilAvailable();
 // xbee.send(zbTx2); 
  //flashLed(statusLed,50,5);
/*
  //detect incoming packet
  //if (xbee.readPacket(500)) 
  {
    //if(xbee.getResponse().getApiId() == ZB_RX_RESPONSE)
    {
      xbee.getResponse().getZBRxResponse(zbRx);
  
	  //buffer = zbRx.getData();
	  zbTx1 = ZBTxRequest(coord1, buffer, zbRx.getDataLength());
      xbee.send(zbTx1);
    }
  } 
  //else if (xbee.getResponse().isError()) 
  {
    //nss.print("Error reading packet.  Error code: ");  
    //nss.println(xbee.getResponse().getErrorCode());
  } 
  //else {
    // local XBee did not provide a timely TX Status Response -- should not happen
    //flashLed(errorLed, 10, 50);
  }
  */
/*
  if(*buffer == 'H')
  {
    digitalWrite(13,HIGH);
  }
  else if(*buffer == 'L')
  {
   digitalWrite(13,LOW); 
  }
*/
	xbee.send(zbTx1);
	Serial.write("port 0");
	delay(1000);
}

