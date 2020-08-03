Feature: InvalidLogin
	In order to avoid unauthorised users from accessing the system
	As an unauthorised user
	I want not be allowed access to the system 

@InvalidLogin
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

@InvalidLogin
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

@InvalidLogin
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

@InvalidLogin
Scenario: Empty username with valid Password
	Given that I am on the login page
	Given I entered nothing into the username textbox
	Given I enter my valid password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@InvalidLogin
Scenario: Valid username with empty Password
	Given that I am on the login page
	Given I enter my valid username
	Given I entered nothing into the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@InvalidLogin
Scenario: Empty username with empty Password
	Given that I am on the login page
	Given I entered nothing into the username textbox
	Given I entered nothing into the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

@InvalidLogin
Scenario: Whitespace username with valid Password
	Given that I am on the login page
	Given I entered <num> chars of whitespace in the username textbox
	Given I enter my valid password
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| num |
		| 1   |
		| 10  |
		| 50  |

@InvalidLogin
Scenario: Valid username with whitespace Password
	Given that I am on the login page
	Given I enter my valid username
	Given I entered <num> chars of whitespace in the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| num |
		| 1   |
		| 10  |
		| 50  |

@InvalidLogin
Scenario: Whitespace username with whitespace Password
	Given that I am on the login page
	Given I entered <num1> chars of whitespace in the username textbox
	Given I entered <num2> chars of whitespace in the password textbox
	When I press the login button
	Then the error message should be "Error: Incorrect password, please try to login again!"

	Examples:
		| num1 | num2 |
		| 1    | 1    |
		| 10   | 10   |
		| 50   | 50   |