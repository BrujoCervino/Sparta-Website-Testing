Feature: InvalidInput
	In order to check the assessment page
	As a Tester
	I want to be able to test the page for all invalid data

@Assessment
Scenario: valid candidate name but invalid recruiter email id
	Given I am in assessment page
	And I have selected the <test> to send
	And I have entered  valid candidate name
	And I have invalid the Candidate email 
	And I have valid the Recruiter email <Recruiter email> 
	When I press the submit button
	Then warning popup message should appear <Message>

	Examples: 
		| test   | Recruiter email | Message                                                             |
		| java   | ghg             | please include an '@' in the email address. 'ghg' is missing an '@' |
		| csharp | ghg@            | please enter a following '@'. 'ghg@' is incomplete                  |