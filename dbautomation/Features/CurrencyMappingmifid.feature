Feature: CurrencyMappingmifid
Currency field raw value is AU and as per the Login if should translated to AUD

@mytag
Scenario: I want to verify currency field for the transaction which has value AU
	Given Currency value is AU
	| Currency |
	| AU       |
    
	When Transaciton gets processed
	Then the result should be <AUD>
	| Currency |
	| AUD      |
	