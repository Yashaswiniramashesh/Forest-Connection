//TRANSMITTING FROM UNO WITH TEMPERATURE TRANSMITTING

#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include <DHT.h>
#define DHTTYPE     DHT11      
#define DHTPIN      A0
DHT dht(DHTPIN, DHTTYPE);
uint32_t delayMS;

int smokeA0 = A5;

RF24 radio(8,10); // CE, CSN
const byte address[6] = "00001";
void setup() {
  pinMode(smokeA0, INPUT);
  Serial.begin(9600);
  radio.begin();
  radio.openWritingPipe(address);
  radio.setPALevel(RF24_PA_MAX);
  radio.stopListening();
  
}
void loop() {
  int h = dht.readHumidity();
  int t = dht.readTemperature();
  Serial.println(h);
  Serial.println(t);
  int ana = analogRead(smokeA0);
 // const char text[] =analogSensor ;
  int node;
  String str="";
  node=1; 
  str+=node;
  str+=t;
  str+=h;
  str+=ana;
  int str_len = str.length()+1;
  char text[str_len];
  
  str.toCharArray(text,str_len);
  
  radio.write(&text,sizeof(text));
  Serial.println(text);
  delay(9000);
}
