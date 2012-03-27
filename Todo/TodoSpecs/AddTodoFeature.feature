Feature: Add todo
	In order to know what to do next
	As somebody with no memory
	I want to be able to add a new todo item

@mytag
Scenario: Add a new todo item
	Given I have entered a title into the form
	And I have entered an entry into the form
	When I press new 
	Then the todo is listed on the index page


Scenario Outline: Add todo items
	Given I have entered <title> into the form
	And I have entered an <entry> into the form
	When I press new 
	Then the todo is listed on the index page

Scenarios: Add todo items
	| title | entry |
	| hello |goodbye|
	| fred	|goodwin|
