Feature: GetProjects
	In order to see current projects
	As an employee
	I want to be able to see this data

@DusanBDD
Scenario: There are current projects
	When I have requested to see current projects
	Then the result should be a list of projects

@DusanBDD
Scenario: There are none current projects
	When I have requested current projects data
	Then the result should be null or empty list
