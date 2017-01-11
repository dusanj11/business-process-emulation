Feature: GetAllEmployees
	In order to see all employees
	As an employee
	I want to be able to get that data

@DusanBDD
Scenario: Data base has some data
	Given I have acces to database
	When I request to have data about all employees
	Then the result should be a list of employees

@DusanBDD
Scenario: Data base doesn't have requested data
	Given I am able to access database
	When I want to have the requested data
	Then the result should be an empty list 
