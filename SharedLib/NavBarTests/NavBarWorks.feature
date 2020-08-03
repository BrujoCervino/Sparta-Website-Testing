Feature: NavBarWorks
	In order to be able to access other features of the website
	As a user
	I want to click a link in the navbar and be sent to the corresponding page

@NavBar
Scenario: Sparta
	Given I am on the (.*) browser
	And I am on the (.*) page
	When I click the (.*) button in the navbar
	Then I should be sent to the (.*) page