Feature: Actor Resource

Scenario: Get Actor All
	Given I am a client
	When I make GET Request '/actors'
	Then response code must be '200'
	And response data must look like '[{"id":1, "name":"A1"}]'