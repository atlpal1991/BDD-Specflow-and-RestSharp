Feature: Register and Create calls
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Register a User Successfully
	Given I have entered email, password to register 
	| email              | password |
	| eve.holt@reqres.in | pistol   |
	When made a post call to register user
	Then I should recieve valid statuscode and responsefile for registered user
	| statuscode | resposefile   |
	| 200        | Register.json |

@mytag
Scenario: Create a User
	Given I have entered name, job for new user
	| name     | job    |
	| morpheus | leader |
	When made a post call to create user
	Then I should recieve valid statuscode and responsefile for new user
	| statuscode | responsefile |
	| 201        | Create.json  |
