Feature: Get user calls

@mytag
Scenario: Get single user
	Given I have made a get call using id 
	| id |
	| 2  |
	Then I should recieve valid statuscode and responsefile for requested user
	| statuscode | responsefile     |
	| 200        | JsonResponses\SingleUser.json |

@mytag
Scenario: Get List of users
	Given I have made a get call to list all users
	Then I should recieve valid statuscode and responsefile for all user
	| statuscode | responsefile |
	| 200        | JsonResponses\ListUSers.json |
