Feature: LoginPage

@smoke
Scenario: Test Login operation to ebalance
	Given I navigate to application
	And I click login button on home page
	And I enter username 'qmjumtt971@fatamail.com'
	And I enter password 'Candidate!22'
	And I accept Cookie Policy
	When I click login button
	And save printscreen
	Then the welcome text must be visible
	

@smoke
Scenario: Test incorect Login operation to ebalance
	Given I navigate to application
	And I click login button on home page
	And I enter username 'UserName@fakemail.com'
	And I enter password 'Password'
	And I accept Cookie Policy
	When I click login button
	And save printscreen
	Then I see alert message
	