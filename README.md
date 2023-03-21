# Library
Library Project Readme

This project uses Entity Framework Core.  
The project database can be created by running the "update-database" command from the Package Manager Console.

Database will be created locally on (localdb)\MSSQLLocalDB with database name "Library".

Run the database seed script, LibrarySeed.sql  in Library.DataAccess.Scripts folder after database is created.


Project Assumptions:

	Authentication is out of scope.  User is known.
	
	Application logging is out of scope.
	

Current application functionality:

	Users can browse entire library catalog and search by Title,Author,Year.
	Users can add items to cart, up to 5.
	Users can view items in cart.
	Users can checkout items.
	Only know members with id, first and last names can be used during checkout.

Application design notes:

	Solution is divide into 4 projects to separate concerns.
	Data access layer uses a repository pattern.
	Development is done in Code First manner. 	


Next steps:

	Create quick cart to track items for user.
	Lookup members by member number or name during checkout.  Ensure only 5 items are ever checked out to user at once.
	Users should be able to lookup checkout out books and return.
	Update books to show availablity and when they will be returned if checked out.
	Build out details page for books.
