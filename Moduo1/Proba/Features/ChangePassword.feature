Feature: ChangePassword
	In order to keep my account safe
	As an employee
	I want to be able to change my password

@DusanBDD
Scenario: Entered valid username, invalid passdword
	When I have entered valid username, wrong password and new password, 
	And I request to change it
	Then the result should be ended without a change

@DusanBDD
Scenario: Entered invalid username, password
	When I have entered invalid username, and new paswword
	And I request to change old password
	Then the result should be non-positive

@DusanBDD
Scenario: Entered valid username, valid password
	When I have both username and password valid, and new paswword
	And I request to make a change on my password
	Then the result should have a positive outcome