Feature: PageAccess
	In order to view the dispatched assessments
	As an admin
	I want to be able to access the page and ensure it's the correct page


@PageAccess
Scenario: Login and Access page
	Given I am logged in correctly
	When I naviage to the dispatches page
	Then the page title should be "Dispatches"