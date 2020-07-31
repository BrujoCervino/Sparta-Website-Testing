Feature: InvalidLogin
	In order to avoid unauthorised users from accessing the system
	As an unauthorised user
	I want not be allowed access to the system 

@Login
Scenario: Valid username with invalid Password
	Given that I am on the login page
	Given I entered my valid username
	Given I entered <password> as a password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| password           |
		| incorrectpassword  |
		| !£$%^&*()_+{}@~<>? |

@Login
Scenario: Invalid username with valid Password
	Given that I am on the login page
	Given I entered <username> as a username
	Given I enter my valid password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| username           |
		| incorrectUsername  |
		| !£$%^&*()_+{}@~<>? |

@Login
Scenario: Invalid username with invalid Password
	Given that I am on the login page
	Given I entered <username> as a username
	Given I entered <password> as a password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| username           | password           |
		| incorrectUsername  | incorrectUsername  |
		| !£$%^&*()_+{}@~<>? | !£$%^&*()_+{}@~<>? |

@Login
Scenario: Empty username with valid Password
	Given that I am on the login page
	Given I entered nothing into the username textbox
	Given I enter my valid password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@Login
Scenario: Valid username with empty Password
	Given that I am on the login page
	Given I enter my valid username
	Given I entered nothing into the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@Login
Scenario: Empty username with empty Password
	Given that I am on the login page
	Given I entered nothing into the username textbox
	Given I entered nothing into the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@Login
Scenario: Whitespace username with valid Password
	Given that I am on the login page
	Given I entered "          " as a username
	Given I enter my valid password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@Login
Scenario: Valid username with whitespace Password
	Given that I am on the login page
	Given I enter my valid username
	Given I entered "          " as a password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@Login
Scenario: Whitespace username with whitespace Password
	Given that I am on the login page
	Given I entered "          " as a username
	Given I entered "          " as a password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"