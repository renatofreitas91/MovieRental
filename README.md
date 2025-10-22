# MovieRental Exercise

This is a dummy representation of a movie rental system.
Can you help us fix some issues and implement missing features?

 * The app is throwing an error when we start, please help us. Also, tell us what caused the issue.
 ** The app fails at startup because IRentalFeatures is a Singleton but depends on the Scoped DbContext; making IRentalFeatures Scoped fixes this.
 * The rental class has a method to save, but it is not async, can you make it async and explain to us what is the difference?
 ** The Rental save method is synchronous, blocking the thread; using AddAsync and SaveChangesAsync makes it non-blocking and better for APIs. 
 * Please finish the method to filter rentals by customer name, and add the new endpoint.
 * We noticed we do not have a table for customers, it is not good to have just the customer name in the rental.
   Can you help us add a new entity for this? Don't forget to change the customer name field to a foreign key, and fix your previous method!
 ** Filtering rentals by customer name can be done with a query and exposed via a new endpoint. A Customer entity should replace the plain CustomerName field in Rental, using a foreign key, and methods should be updated accordingly.
 * In the MovieFeatures class, there is a method to list all movies, tell us your opinion about it.
 * No exceptions are being caught in this api, how would you deal with these exceptions?
 **  The MovieFeatures.GetAll() method exposes EF entities, tracks them unnecessarily, and loads all records; it should return DTOs, use AsNoTracking(), and support paging. Finally, exceptions are not caught in the API; global middleware should handle them, log errors, and return standardized responses.


	## Challenge (Nice to have)
We need to implement a new feature in the system that supports automatic payment processing. Given the advancements in technology, it is essential to integrate multiple payment providers into our system.

Here are the specific instructions for this implementation:

* Payment Provider Classes:
    * In the "PaymentProvider" folder, you will find two classes that contain basic (dummy) implementations of payment providers. These can be used as a starting point for your work.
* RentalFeatures Class:
    * Within the RentalFeatures class, you are required to implement the payment processing functionality.
* Payment Provider Designation:
    * The specific payment provider to be used in a rental is specified in the Rental model under the attribute named "PaymentMethod".
* Extensibility:
    * The system should be designed to allow the addition of more payment providers in the future, ensuring flexibility and scalability.
* Payment Failure Handling:
    * If the payment method fails during the transaction, the system should prevent the creation of the rental record. In such cases, no rental should be saved to the database.
