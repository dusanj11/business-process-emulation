Feature: AddEmployee
	In order to employ new people
	As an employer
	I want to be able to add new employees

@DusanBDD
Scenario: Employee with certain username already exists
	Given I can write in database
	And I have entered employee with existing username
	When I request to add him/her
	Then the result should be false

@DusanBDD
Scenario: Employee with certain username does not exists
	Given I have power to write on database
	And I have entered non existing username for employee
	When I request to put them in database
	Then the result should be true
