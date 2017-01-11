Feature: UpdateEmployee
	In order to keep data up-to-date 
	As an employee
	I want to be able to change data of certain employee

@DusanBDD
Scenario: Updating non-existable employee
	When I try to update employee with wrong username
	And I request to update his/hers personal data
	Then the result should be negative

@DusanBDD
Scenario: Updating existing employee
	When I try to update employee with correct username
	And I request to update employee's personal data
	Then the result should be positive