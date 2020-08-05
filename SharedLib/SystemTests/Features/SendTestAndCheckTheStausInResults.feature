Feature: SendTestAndCheckTheStausInResults
	In order to check the status of the sent results
	As a Sparta Recruiter
	I want to see the status at the dispatches

@mytag
Scenario: Check the status after sending the test
	Given "John Smith" has been sent a "python" test to "testproject.dummy456@gmail.com"
	When the test has been completed
	And I go to the results page
	And The results have been updated
	And I go to Dispatches page
	Then "John Smith" status under complete should be dislayed as "Yes"