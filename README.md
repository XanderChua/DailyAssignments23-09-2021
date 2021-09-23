# DailyAssignments23-09-2021
Write a program using delegate and event
 - A counter class which increases the counter every 5 seconds
 - Every 20 count it raises a event which is subscribed by the main class
 - The main class on recieving the event Prints "Event Recieved".
 
 Write a program with the following specifications:
 - A main class which subscribes to an event called "Alert". 
	On recieving an alert it can notify the users with a text output.
 - A class called Earthquake which captures the intensity of the earthquake and the place of occurance.
 - Additionally we have another class called Tsunami which has one member probability of tsunami

Once you create an earthquake object you have to pass the "Place" and intensity information to the class
The earthquake class then creates a Tsunami object and calls the member "CalculateTsunamiProbability"
The probability of  a Tsunami is calculated by the formula "P(T) = I(E)*0.7 + 0.3 * RandomOccuranceChance" I(E) - Denotes the intensity of an earthquake. 
The Tsunami class will notify its subscribers regarding the proability of a tsunami. The main class will display it. 
 
Write a program for random encryption key generator
 - The prgram will take few inputs from a user (characters to be used for generating a random key, public key for which a encryption key will be generated, Time difference within which a key should be generated)
 - The generator class has a member called Public key which has to bootstraped during object creation.
 - The generator class keeps track of each of the random string generated and can return it if needed by an exposed indexer.
 - The generator class have additional method called "Start" and "Stop" which starts and stops generating keys
 - The main class can create an object of generator class ane then can start or stop depending on its need.
 - It can subscribe to an event exposed by generator class to display all the encryption keys sent by the generator.

create a hotel mgmt.  system to perform different operation  given below.                                                                     first you have to book a room according to your convenience . then you will choose the services you want then a bill will generate with all the details and also with the tax
create a hospital mgmt. system to enroll a patient according to his condition , ex. emergency , opd, clinical services etc. then after the inspection the doctor will send  him to pharmacy to collect the medicine . and at last you need to generate abill with all the patient details
From Training License 1 to Everyone:  04:19 PM
create a blood bank to collect blood units of different blood groups. you will supply this blood to all the needy people , at a time you can only store 50 units of blood. if your stock goes down below 5 units it shows a warning message to collect urgently . take a track of supply units of different blood groups
