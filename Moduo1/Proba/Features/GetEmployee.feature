Feature: GetEmployee
	In order to see details of certain employee
	As an employee
	I want to be able get requested info

@DusanBDD
Scenario: Employee exists and password valid
	Given I can use database
	And I have entered valid username and password
	When I request to get wanted data
	Then the result should be an instance of employee

@DusanBDD
Scenario: Employee exists and password invalid
	Given I have the power work on datbase
	And I have entered valid username and invalid password
	When I request the possesion of that data
	Then the result should be a null value or empty object

@DusanBDD
Scenario: Employee doesn't exist
	Given I have a way to read from database
	And I have entered invalid data
	When I request the certain data
	Then the result should be an empty object or null 
