Feature: Add

Add a show from the Search page and have it show up in the watchlist
Background:
	Given the following users exist
	  | UserName	| Email						| Password		 |
	  | SampleUser1	| sampleruser1@gmail.com	| Password1!	 |
	  | SampleUser13| sampleruser13@gmail.com	| Sampleuser13!# |

@tag1
Scenario Outline: Add shows
	Given I am logged in
	And I am on the search page
	When I enter <name> into the search bar
	And I click the Add button next to <name>
	Then My watchlist will contain <name>
	Examples: 
	| name				|
	| Pulp Fiction		|
	| The Gentlemen	    |

@tag2
Scenario Outline: Add upcoming shows from Homepage
	Given I am logged in
	And I am on the homepage page
	When I click the Add next to shows <name>
	Then <name> will be added to my watchlist
	Examples:
	| name								|
	| Jurassic World Dominion (2022)	|
	| Lightyear (2022)					|