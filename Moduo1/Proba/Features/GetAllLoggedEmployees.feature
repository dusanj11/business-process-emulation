Feature: GetAllLoggedEmployees
	In order to see who came to work
	As an employee
	I want to be able to get data about all logged workers

@DusanBDD
Scenario: Get Logged Employees
	Given I have access to database
	When I request the data about logged employees
	And if there is at least one logged employye
	Then the result should be list of Employees