Feature: Search

Search for items using our Search page

@tag1
Scenario: See search bar
	Given I am logged in
	When I navigate to the Search page
	Then I will see the search bar

Scenario Outline: Make a search
	Given  I am logged in
	And I am on the search page
	When I enter <name> into the search bar
	Then I will see a table of shows
	And <name> will be in the results in that table
	Examples: 
	| name          |
	| Inception     |
	| Pulp Fiction  |
	| The Godfather |