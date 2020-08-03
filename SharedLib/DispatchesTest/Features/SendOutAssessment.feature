Feature: SendOutAssessment
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@SendCSharpAssessment
Scenario: Send CSharp Assessment
	Given I have logged in successfully
	And the assessment dropdown has CSharp selected
	And "Test CSharp name" is entered as a candidate name
	And "testproject.dummy456@gmail.com" is entered as the candidate email
	And "testproject.dummy456@gmail.com" is entered as the recruiter email
	And Non of the text boxes are in focus
	When The submit button is clicked
	And I am on the dispatches page
	Then The dispatches table should have a new entry in it with the following data:
		| field      | value                          |
		| Name       | Test CSharp name               |
		| Email      | testproject.dummy456@gmail.com |
		| Recruiter  | testproject.dummy456@gmail.com |
		| Assessment | csharp                         |
		| Complete   | No                             |
		| Expired    | No                             |

@SendCSharpAssessmentWithPsychometric
Scenario: Send CSharp Assessment With Psychometric
	Given I have logged in successfully
	And the assessment dropdown has CSharp selected
	And the Psychometric check box has been selected
	And "Test with Psychometric name" is entered as a candidate name
	And "testproject.dummy456@gmail.com" is entered as the candidate email
	And "testproject.dummy456@gmail.com" is entered as the recruiter email
	And Non of the text boxes are in focus
	When The submit button is clicked
	And I am on the dispatches page
	Then The top two rows should have the name "Test with Psychometric name"
	And The top two rows should have a the following assessments:
		| Assessment   |
		| csharp       |
		| psychometric |