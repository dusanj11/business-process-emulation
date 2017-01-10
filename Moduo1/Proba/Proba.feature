Feature: Proba
	In order to use my functions
	As a employee
	I want to be able to log in

@mytag
Scenario: Employee Log In
	Given I have sucessfully loaded the application
	And I have entered valid username and password
	When I press "signInBtn" button
	Then the client dialog should open
