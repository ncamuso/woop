Feature: User Logins

**As a registered user I would like to be able to login to SpoilBlock website so I am be able to search for shows and add my choices to my watchlist.**

This feature ensures that users who have previously registered can successfully login and see a personalized message
that confirms they are recognized by the application and logged in.

The steps we define here can be re-used when testing the *register* feature.
Background:
	Given the following users exist
	  | UserName	| Email						| Password		 |
	  | SampleUser1	| sampleruser1@gmail.com	| Password1!	 |
	  | SampleUser13| sampleruser13@gmail.com	| Sampleuser13!# |
	 
	And the following users do not exist
	  | UserName | Email               | Password  |
	  | AndreC   | colea@example.com   | 0a9dfi3.a |
	  | JoannaV  | valdezJ@example.com | d9u(*dsF4 |

Scenario Outline: Existing user can login
	Given I am a user with username '<UserName>'
	When I login
	Then I am redirected to the '<Page>' page
	And I can see a message in the homepage
	Examples:
	| UserName		| Page |
	| SampleUser1	| Home |
	| SampleUser13	| Home |
	