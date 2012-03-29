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


Scenario: Update a todo item
	Given I am on the index page
	And I select an item to be edited 
	And I change its title
	When I press update
	Then the updated title is displayed
	