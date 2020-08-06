Feature: SendTestStartStatusInprogress
	In order to check the status of the sent Assessment
	As a Sparta Recruiter
	I want to be able to see the status at the polls

@EndToEnd
Scenario: Check the status of the test at polls page
	Given "Kate Smith" has been sent a "python" test to "testproject.dummy456@gmail.com"
	When the test has been started
	And I go to the results page
	And The results have been updated
	And I go to Polls page
	Then Status of the matching test id is "in progress"

@EndToEnd
Scenario: Check the status of the page at polls page before start of test
	Given "Kate Smith" has been sent a "csharp" test to "testproject.dummy456@gmail.com"
	When I go to the results page
	And The results have been updated
	And I go to Polls page
	Then Status of the matching test id is "waiting"
	
