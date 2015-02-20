/*
#include <SoftwareSerial.h>

// the setup function runs once when you press reset or power the board
//SoftwareSerial mySerial(4,5);
//SoftwareSerial mySerial(0,1);
Serial mySerial(0,1);
char buffer;
void setup() {
  // initialize digital pin 13 as an output.
  pinMode(13, OUTPUT);
  mySerial.begin(9600);
  buffer = NULL;
}

// the loop function runs over and over again forever
void loop() 
{
//  if(mySerial.available() > 0)
    //digitalWrite(13, HIGH);   // turn the LED on (HIGH is the voltage level)
//    if(mySerial.read() == '1')
//      digitalWrite(13, HIGH);   // turn the LED on (HIGH is the voltage level)
//    else if(mySerial.read() == '0')
//      digitalWrite(13,LOW);    // turn the LED off by making the voltage LOW
  buffer = mySerial.read();
  if(buffer)
  {
    mySerial.print(buffer);
    digitalWrite(13, HIGH);   // turn the LED on (HIGH is the voltage level)
  }  
  //digitalWrite(13,LOW);    // turn the LED off by making the voltage LOW
  //delay(1000);
  digitalWrite(13,LOW);    // turn the LED off by making the voltage LOW
}
*/

/*
const int ledPin = 13; // the pin that the LED is attached to
int incomingByte;      // a variable to read incoming serial data into

void setup() {
  // initialize serial communication:
  Serial.begin(9600);
  // initialize the LED pin as an output:
  pinMode(ledPin, OUTPUT);
}

void loop() {
  // see if there's incoming serial data:
  if (Serial.available() > 0) {
    // read the oldest byte in the serial buffer:
    incomingByte = Serial.read();
    if(incomingByte != NULL)
    {
       Serial.write(incomingByte);
    }
    // if it's a capital H (ASCII 72), turn on the LED:
    if (incomingByte == 'H') {
      digitalWrite(ledPin, HIGH);
    } 
    // if it's an L (ASCII 76) turn off the LED:
    if (incomingByte == 'L') {
      digitalWrite(ledPin, LOW);
      
    }
  }
}
*/

#include <XBee.h>

//global
Xbee xbee = Xbee();
void setup(){
  xbee.begin(9600);
}

void loop(){
  //Serial.write('a');
  //delay(400);
  
  if(Serial.available())
  {
    letter = Serial.read();
    Serial.print(letter);
  }
}
