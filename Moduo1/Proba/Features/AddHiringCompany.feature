Feature: AddHiringCompany
	In order differentiate companies
	As an employee
	I want to be able to add companies

@DusanBDD
Scenario: Company with existing ID
	When I have entered a company with existing id
	And I have tryed to put it in database
	Then the result should be failing

@DusanBDD
Scenario: Company with new ID
	When I have entered a company with  new id
	And I have requested to put it in database
	Then the result should be sucessful
