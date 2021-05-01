Feature: Delete API Call

@mytag
Scenario: Delete a User Successfully
	Given I have made a get call using id to delete a user 
	| id |
	| 2  |
	Then I should recieve valid statuscode as below
	| statuscode |
	| 204        | 