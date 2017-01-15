Feature: SendPartnershipRequest
	In order to make new partnership deals
	As an CEO
	I want to be able to send partnership request

@DusanBDD
Scenario: Successfully sent
	Given I have opted for one outsourcing company
	When I request to send them the request
	Then the result should be completed with value true
