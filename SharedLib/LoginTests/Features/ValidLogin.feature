Feature: ValidLogin
	In order to access the system
	As a member of the requtement team
	I want to be able to login with my username and password

@Login
Scenario: Valid login
	Given that I am on the login page
	Given I entern my username
	Given I enter my password
	When I press the login button
	Then the page title should be "Send Assessment"