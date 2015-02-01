Feature: Get Restaurants
	In order to postcode validation
	I want to be get list of restaurants or error message

@mytag
Scenario: Postcode is valid
	Given I have entered valid postcode 'se19' into the textbox
	When I press find
	Then the result should be the list of restaurants
	
Scenario: Postcode is invalid
	Given I have entered invalid postcode '$$$' into the textbox
	When I press find
	Then the result should be error message
