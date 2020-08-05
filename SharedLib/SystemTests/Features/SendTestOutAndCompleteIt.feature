Feature: SendTestOutAndCompleteIt
	In order to get the results from a sent out test
	As a sparta recruiter
	I want to see the new results of the test that I have been completed

@EndToEnd
Scenario: Complete a sent out test
	Given "Bob McCtestyface" has been sent a "csharp" test to "testproject.dummy456@gmail.com"	
	When the test has been completed
	And I go to the results page
	And The results have been updated
	Then "Bob McCtestyface" should bave a new entry in the C# results table
	And the C# results count has increased by one