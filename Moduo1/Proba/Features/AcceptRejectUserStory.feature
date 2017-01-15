Feature: AcceptRejectUserStory
	In order to show the outsourcing company the right way
	As a PO
	I want to be able to accept/reject their user stories

@DusanBDD
Scenario: Accept user story
	Given I have picked an user story to accept
	When I choose to accept it
	Then the result should be value true

@DusanBDD
Scenario: Reject user story
	Given I have opted desired user story to reject
	When I request to reject it
	Then the returning value should be true
