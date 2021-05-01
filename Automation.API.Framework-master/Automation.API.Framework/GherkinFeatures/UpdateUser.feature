Feature: Update user api call

@mytag
Scenario: Update a User Successfully
	Given I have entered email, password to update and made a put call 
	| name     | job           | id |
	| morpheus | zion resident | 2  |
	Then I should recieve valid statuscode and responsefile for updated user
	| statuscode |
	| 200        | 