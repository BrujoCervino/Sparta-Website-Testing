Feature: SendOutAssessment
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Send CSharp Assessment
	Given I have logged in successfully
	And the assessment dropdown has CSharp selected
	And "Test name" is entered as a candidate name
	And "testproject.dummy456@gmail.com" is entered as the candidate email
	And "testproject.dummy456@gmail.com" is entered as the recruiter email
	And Non of the text boxes are in focus
	When The submit button is clicked
	And I am on the dispatches page
	Then The dispatches table should have a new entry in it with the following data:
	| field      | value                          |
	| Name       | Test name                      |
	| Email      | testproject.dummy456@gmail.com |
	| Recruiter  | testproject.dummy456@gmail.com |
	| Assessment | csharp                         |
	| Complete   | No                             |
	| Expired    | No                             |