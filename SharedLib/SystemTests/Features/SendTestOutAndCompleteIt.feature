Feature: SendTestOutAndCompleteIt
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Complete a sent out test
	Given A "csharp" test has been sent out to "testproject.dummy456@gmail.com"	
	When the test has been completed
	And I go to the results page
	And The results have been updated
	Then there should be a new entry in the C# results table