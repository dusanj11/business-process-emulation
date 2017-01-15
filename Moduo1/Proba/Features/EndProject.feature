Feature: EndProject
	In order to know witch project is finished
	As an PO
	I want to be able to mark projects as finished

@DusanBDD
Scenario: EndProject
	Given I have chosen a project to end
	When I request to end it
	Then the result should be afirmativly returned
