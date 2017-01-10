Feature: ShowEmployees
	In order to see workers in company
	As an employee
	I want to be shown a table of all workers in company

@DusanBDD
Scenario: Show table of signed employees
	Given I have signed sucessfully in my account
	When I press "showEmployBtn" button
	Then the user control for showing signed employyes should be desplayed in current window
