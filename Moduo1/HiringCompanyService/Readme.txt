Start up project:

	>HiringCompanyService.proj<
	
	Directories(namespaces):

	->HiringCompanyService.Access
		-communication with DB

	->HiringCompanyService.DB
		-local DB instance

		- if you use VS2015 you might need to generate local DB again:
			- right click on DB directory / Add / New item...
			- Select Data / Select Service-based Database
			- Give it a name and click Add.

		-if you use VS2013 you might need to check App.config file and see if it has  Source=(LocalDB)\MSSQLLocalDB;,
			- if so, you must replace it with  Source=(LocalDB)\v11.0;

	->HiringCompanyService.cs
		-represent implementation of wcf contract IHiringCompany and IHcContract interfaces

	->ServiceProxy.cs
		-Representation of the same object structure that will be serialized and then passed over the wire
		 to the endpoint (the Outsourcing company service).
