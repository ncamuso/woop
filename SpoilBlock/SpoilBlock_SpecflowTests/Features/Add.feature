Feature: Add

Add a show from the Search page and have it show up in the watchlist

@tag1
Scenario Outline: Add shows
	Given I am logged in
	And I am on the search page
	When I enter <name> into the search bar
	And I click the Add button next to <name>
	Then My watchlist will contain <name>

	| name         |
	| Pulp Fiction |
	| Inception    |