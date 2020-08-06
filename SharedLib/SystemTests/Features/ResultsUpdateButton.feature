Feature: ResultsUpdateButton
	In order to update the results
	As an user
	I want to be able to be taken to the results page after I have clicked the update button

@UpdateResults
Scenario: ClickUpdateButton
	Given I login to the Website
	And I navigate to the results page
	When The update button has been clicked
	Then the url should contain "/polls"