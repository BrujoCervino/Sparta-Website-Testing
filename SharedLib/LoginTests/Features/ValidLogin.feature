Feature: ValidLogin
	In order to access the system
	As a member of the requtement team
	I want to be able to login with my username and password

@Login
Scenario: Valid login
	Given that I am on the login page
	When I entern my username
	And I enter my password
	Then the page title should be "Send Assessment"