Feature: EmployeeLogOut
	In order to mark that I've left the company
	As an employee
	I want to be able to change my log status

@DusanBDD
Scenario: I have presented wrong username
	When I have presented incorrect username
	And I have request to change log status
	Then the result should be returning false

@DusanBDD
Scenario: I have presented correct username
	When I have presented correct username
	And I have requested changing log status
	Then the result should be returning positive value
