Feature: GetAllNotLoggedEmployees
	In order to see who is late
	As an employee
	I want to have date of those employees

@DusanBDD
Scenario: Get Not Logged Employees
	Given I have a way of accesing database
	When I request the data about late employees
	And if there is at least one who is late
	Then the result should be a list of  employees who are late
