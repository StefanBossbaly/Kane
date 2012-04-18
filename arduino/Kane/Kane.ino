//Light threshold value
#define THRESHOLD 200

//Analog inputs
int input0 = 0;
int input1 = 0;
int input2 = 0;
int input3 = 0;
int input4 = 0;
int input5 = 0;

void setup()
{
  //Open the serial
  Serial.begin(9600);
}

void loop()
{
  //Read the inputs
  input0 = analogRead(0);
  input1 = analogRead(1);
  input2 = analogRead(2);
  input3 = analogRead(3);
  input4 = analogRead(4);
  input5 = analogRead(5);
  
  //Check to see if they are below THRESHOLD
  if (input0 <= THRESHOLD){
    Serial.print((byte)0);
  }
  if (input1 <= THRESHOLD){
    Serial.print((byte)1);
  }
  if (input2 <= THRESHOLD){
    Serial.print((byte)2);
  }
  if (input3 <= THRESHOLD){
    Serial.print((byte)3);
  }
  if (input4 <= THRESHOLD){
    Serial.print((byte)4);
  }
  if (input5 <= THRESHOLD){
    Serial.print((byte)5);
  }
  
  //Delay for 150ms
  delay(250);
}
