Feature: SendProjectRequest
	In order to have a working project
	As an CEO
	I want to be able to send request to outsourcing company

@DusanBDD
Scenario: Successfully sent project request
	Given I have chosen both project and outsourcing company
	When I send the request
	Then the request should be sent correctly
