#include <SoftwareSerial.h>
#include <TinyGPS.h>
#include <LiquidCrystal.h>
#include <XBee.h>


// create the XBee object, buffer, address, response packet, and transmit packet
XBee xbee = XBee();  
uint8_t buffer[20];
char temp[20];
XBeeAddress64 addr64 = XBeeAddress64(0,0);
ZBTxRequest zbTx1 = ZBTxRequest(addr64,buffer,sizeof(buffer));
ZBRxResponse zbRx = ZBRxResponse();


/*Additionally,
   10K pot is wired to +5V and GND, with it's wiper (output) to LCD screens VO pin (pin3).*/

/*  9600-baud serial GPS device hooked up on pins 13(rx) and 12(tx). */

TinyGPS gps;
SoftwareSerial ss(12, 13);

float flat, flon;
    unsigned long age;

void setup()
{ 
  Serial.begin(9600);
  xbee.begin(Serial);
  // initialize the serial communications
  ss.begin(9600);
  
  Serial.print("Beacon"); 
  Serial.println();
  Serial.println("by Elizabeth");
  Serial.println();
     delay(1000);   
}

void loop()
{ 
  bool newData = false;

  // For one second we parse GPS data and report some key values
  for (unsigned long start = millis(); millis() - start < 1000;)
  {
    while (ss.available())
    {
      char c = ss.read();
     // Serial.write(c);  // uncomment this line to see the GPS data flowing
      if (gps.encode(c))  // did a new valid sentence come in?
        newData = true;
    }
  }

  if (newData)
  {                             
    gps.f_get_position(&flat, &flon, &age);

      Serial.print("LAT: ");
      Serial.println(flat == TinyGPS::GPS_INVALID_F_ANGLE ? 0.0 : flat, 12);
        
      Serial.print("LON: "); 
      Serial.println(flon == TinyGPS::GPS_INVALID_F_ANGLE ? 0.0 : flon, 12); 
      Serial.print(""); 
  }
  
  if (xbee.readPacket(500)) 
  {
    if(xbee.getResponse().getApiId() == ZB_RX_RESPONSE)
    {
      xbee.getResponse().getZBRxResponse(zbRx);
/*
      for(int i = 0;i<zbRx.getDataLength(); i++)
      {
        if(i<sizeof(buffer))
          buffer[i] = zbRx.getData(i);
      }
*/    
      
      dtostrf(flat,4,4,temp);
      for(int i = 0; i < 20; i++)
      {
       buffer[i] = temp[i]; 
      }
      for(int i = 0; i < 20; i++)
      {
       Serial.print(buffer[i]); 
      }
      zbTx1 = ZBTxRequest(addr64, buffer, zbRx.getDataLength());
      xbee.send(zbTx1);
    }
  } 
  else if (xbee.getResponse().isError()) 
  {
    ss.print("Error reading packet.  Error code: ");  
    ss.println(xbee.getResponse().getErrorCode());
  } 
  else {
   ///  local XBee did not provide a timely TX Status Response -- should not happen
    // flashLed(errorLed, 10, 50);
  }
  
  
}


