Feature: MoShop
	In order to Create A Shop
	As a MoShop User
	I want to be Logged In 

@mytag
Scenario: LogIn
	Given I have an User Name And Password
	And when I enter the correct Details
	When I clikc Logon Button
	Then the result should Moshop Console HomePage
