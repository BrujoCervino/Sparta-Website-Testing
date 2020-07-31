Feature: ValidLogin
	In order to access the system
	As a member of the recruitment team
	I want to be able to login with my username and password

@Login
Scenario: Valid login
	Given that I am on the login page
	Given I entern my valid username
	Given I enter my valid password
	When I press the login button
	Then the page title should be "Send Assessment"