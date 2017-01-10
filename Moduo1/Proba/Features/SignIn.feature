Feature: SignIn
	In order to use my functions
	As an employee
	I want to be able to log in

@DusanBDD
Scenario: Invalid sign in
	Given I have started the application sucessfully
	And I have filled username and password with invalid data
	When I push button "signInBtn" 
	Then the dialog for client should not open

@DusanBDD
Scenario: Valid sign in
	Given I have run the correct application
	And I have entered valid data in text boxes
	When I press "signInBtn"  button 
	Then the dialog for client should open