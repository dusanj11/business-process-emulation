Feature: ShowProject
	In order to see actual projects
	As an employee 
	I want to be shown working projects in a atable

@DusanBDD
Scenario: Show current projects
	Given I have signed in sucessfully
	When I push "showProjBtn" button
	Then the user control for showing projects should be desplayed in current window
