Feature: EmployeeLogIn
	In order to mark my arrival at work
	As an employee
	I want to be able to change my status to logged in

@DusanBDD
Scenario: Entered correct username
	When I have entered valid username
	And I request to change my log status
	Then the result should be returning true

@DusanBDD
Scenario: Entered incorrect username
	When I have entered invalid username
	And I have requested to update my log status
	Then the result should not be returning true
