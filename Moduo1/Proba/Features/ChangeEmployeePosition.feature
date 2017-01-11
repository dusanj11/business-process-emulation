Feature: ChangeEmployeePosition
	In order to upgrade/downgrade someone's position
	As an CEO/HR
	I want to be able to change their position

@DusnBDD
Scenario: Certain employee does not exist in database
	When I have entered wrong username with crroect title
	And I request to change title of thet employee
	Then the process should be incomplete

Scenario: Certain employee exists in database
	When I have entered correct username and wanted title
	And I request to make a change on his/hers title
	Then the process should be complete