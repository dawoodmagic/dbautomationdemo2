Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the first number
	And the second number
	When the two numbers are added
	Then the result should



	@mytag2
Scenario: Verify Currency Field Mapping for MIFID feed
	Given Source feed file is copied to Incoming folder Listner
	And Wait till Records gets processed into the DB
	Then result should be currency = AUD