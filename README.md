# angularjs_spa_practice

* Dependency injection design pattern (applied with constructors). 
The Dependency Inversion principle (DIP) helps to loosely couple my code by ensuring that the high-level modules depend on abstractions rather than concrete implementations of lower-level modules. The Dependency Injection pattern is an application/ implementation of this principle. 

For those three delivery options, DeliveryServiceBase class is defined as a parent class to handle the common parts for all options, such as base cost, JuneToAugust factor, SepFactor, otherMonthFactor and the calcution of delivery cost. MotorbikeService, TrainService and AircraftService are concrete classes. Every concrete class has their own delivery information requires an instance of a DEPENDENCY to work.

--- DeliveryServiceBase	(parent class) <br />																	
  |_ MotorbikeService  ----> public MotorbikeService(IDeliveryInfo deliData) <br />
  |_ TrainService	   ----> public TrainService(IDeliveryInfo deliData) <br />
  |_ AircraftService   ----> public AircraftService(IDeliveryInfo deliData) <br />


--- IDeliveryInfo (interface) <br />
 |_ MotorbikeDeliverInfo r<br />
 |_ TrainDeliverInfor <br />
 |_ AircraftDeliverInfor <br />
 
 
* The benefit: <br />
loosely coupled and easily maintainable, scalable

==================
* Time Summary:<br />
preparation: 2 hours<br />
coding: 6 hours without testing<br />
styling: 30 minutes<br />
Building & testing: 4.5 hours<br /><br />

As this practice is quite simple in front end and use Bootstramp for styling, there is no Sass or Less, just a short normal site.css included
