Feature: AccessTests
	In order to access the website
	As a developer
	I want to ensure that all webpages can be accessed having logged in

@AccessWithLogin
Scenario: Try to access results page with login
	Given I am logged in correctly
	When I type in the results page url
	Then I should be on the "results" page

@AccessWithLogin
Scenario: Try to access dispatches page with login
	Given I am logged in correctly
	When I type in the dispatches page url
	Then I should be on the "dispatches" page

@AccessWithLogin
Scenario: Try to access home page with login
	Given I am logged in correctly
	When I type in the home page url
	Then I should be on the "home" page

@AccessWithLogin
Scenario: Try to access polling page with login
	Given I am logged in correctly
	When I type in the polling page url
	Then I should be on the "polling" page

@Defect-AccessWithLogin
Scenario: Try to access register page with login
	Given I am logged in correctly
	When I type in the register page url
	Then I should be not see the "register" page

@Defect-AccessWithLogin
Scenario: Try to access login page with login
	Given I am logged in correctly
	When I type in the login page url
	Then I should be not see the "login" page

@AccessWithLogin
Scenario: Try to press homepage button with login
	Given I am logged in correctly
	When I press the Sparta logo
	Then I should be on the "home" page