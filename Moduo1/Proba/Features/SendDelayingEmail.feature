Feature: SendDelayingEmail
	In order to send notification to employees
	As a system
	I want to be able to send employees who are late an email

@DusanBDD
Scenario: Sucessfully sent
	When I present the correct data of employee
	And I request to notify him by email
	Then the email should be sent successfully