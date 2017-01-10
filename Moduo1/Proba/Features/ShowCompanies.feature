Feature: ShowCompanies
	In order to see partner companies
	As an employee
	I want to be able to see a table view of all partner companies

@DusanBDD
Scenario: Show Companies
	Given I have logged in succesfully 
	When I press button "showCompBtn"
	Then the window should contain a data grid with that information
