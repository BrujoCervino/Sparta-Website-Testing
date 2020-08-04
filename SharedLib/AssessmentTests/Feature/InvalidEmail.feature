Feature: Email Validation
	In order to send the aseessment to proper email id
	As a recruiter
	I want to be be able to check there is a bad response message when there is invalid email id

@InvalidEmail
Scenario: Invalid recruiter email
	Given I am in assessment page
	And I have selected the <test> to send
	And I have entered  valid candidate name
	And I have valid the Candidate email 
	And I have Invalid the Recruiter email <Recruiter email> 
	And None of the text boxes are in focus
	When I press the submit button
	Then i should be shown an error message <Message>

	Examples: 
		| test   | Recruiter email           | Message                                                    |
		| java   | shwetha21ashwath@gmailcom | Error: Request failed with a status code 400 - Bad Request |
		| csharp | ghg@com                   | Error: Request failed with a status code 400 - Bad Request |

@InvalidEmail
Scenario: Invalid Candidate email
	Given I am in assessment page
	And I have selected the <test> to send
	And I have entered  valid candidate name
	And I have Invalid the Candidate email <Candidate email> 
	And I have valid the Recruiter email 
	And None of the text boxes are in focus
	When I press the submit button
	Then i should be shown an error message <Message>

	Examples: 
		| test           | Candidate email           | Message                                                    |
		| python         | shwetha21ashwath@gmailcom | Error: Request failed with a status code 400 - Bad Request |
		| pythonLearning | ghg@com                   | Error: Request failed with a status code 400 - Bad Request |