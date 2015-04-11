#include <TinyGPS.h>
#include <SoftwareSerial.h>

#define rxPin 12
#define txPin 13

TinyGPS gps;
SoftwareSerial ss(rxPin, txPin);

void setup()
{
   ss.begin(9600); 
   Serial.begin(9600);
}

void loop()
{
    bool newData = false;
    Serial.println(ss.available());
    while (ss.available())
    {
      char c = ss.read();
      Serial.print(c); // uncomment this line to see the GPS data flowing
      if (gps.encode(c))  // Did a new valid sentence come in?
        newData = true;
    } 
}
