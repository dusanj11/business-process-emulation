Feature: GetHiringCompanies
	In order to know details of hiring companies
	As an employee
	I want to be able to have that information with their id

@DusanBDD
Scenario: The id of company does not exist
	When I entered id of company
	And I have requested to get that company
	Then the result should be returning a false value

@DusanBDD
Scenario: The id of company exists
	When I filled data with existing id
	And I have requested to have that company detailes
	Then the result should be  hiring company
