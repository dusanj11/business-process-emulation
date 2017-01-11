Feature: AddProjectDefinition
	In order to start a projetc
	As an employee
	I want to be able to create a definition of a project

@DusanBDD
Scenario: Sucessful creation 
	When I have created a definition data for a project
	And I have requested to add it
	Then the result should be afirmative
