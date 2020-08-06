Feature: LoginViewDifferentPageLogout
	In order to View different pages in the sparta website
	As a Sparta Website User
	I want to be able to login and logout
@mytag
Scenario: Login to the Website view page and logout
	Given I login to the Website
	When I click to the results page
	And I lick to Dispatches page
	And I click to Polls page
	And I press Logout
	Then "You have successfully signed out!"should be displayed