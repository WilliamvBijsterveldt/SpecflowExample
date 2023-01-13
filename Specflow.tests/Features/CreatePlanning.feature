Feature: Users can create an planning
    As a user
    I want to create a planning
    
Scenario: A user should be able to create a new planning
    Given a user navigates to the planning application
    And a user clicks the New planning button
    And a user fills in the activity type field with a value
    And a user fills in the description field with a value
    And a user chooses a starting date from the start date field
    And a user chooses an ending date from the end date field
    When a user clicks the submit button
    Then I verify if a new planning has been added to the planning list