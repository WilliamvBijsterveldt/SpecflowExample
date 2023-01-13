using FluentAssertions;
using OpenQA.Selenium;
using Specflow.tests.Selenium;
using TechTalk.SpecFlow;

namespace Specflow.tests.Steps;

[Binding]
public class CreatePlanningSteps
{
    private IWebDriver driver;
    private int planningListCount;

    private readonly ScenarioContext _scenarioContext;

    public CreatePlanningSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Given(@"a user navigates to the planning application")]
    public void GivenAUserNavigatesToThePlanningApplication()
    {
        driver = _scenarioContext.Get<SeleniumDriver>("SeleniumDriver").Setup();

        driver.Url = "http://localhost:4200";
        
        planningListCount = driver.FindElements(By.ClassName("planningRow")).Count;
    }
    
    [Given(@"a user clicks the New planning button")]
    public void GivenAUserClicksTheNewPlanningButton()
    {
        driver.FindElement(By.Id("createPlanningBtn")).Click();
    }
    
    [Given(@"a user fills in the activity type field with a value")]
    public void GivenAUserFillsInTheActivityTypeFieldWithAValue()
    {
        driver.FindElement(By.Id("activityType")).SendKeys("Learning selenium");
    }

    [Given(@"a user fills in the description field with a value")]
    public void GivenAUserFillsInTheDescriptionFieldWithAValue()
    {
        driver.FindElement(By.Id("description")).SendKeys("Writing an example of how to use selenium");
    }

    [Given(@"a user chooses a starting date from the start date field")]
    public void GivenAUserChoosesAStartingDateFromTheStartDateField()
    {
        driver.FindElement(By.Id("startDate")).SendKeys("01/13/2023");
    }


    [Given(@"a user chooses an ending date from the end date field")]
    public void GivenAUserChoosesAnEndingDateFromTheEndDateField()
    {
        driver.FindElement(By.Id("endDate")).SendKeys("10/13/2023");
    }

    [When(@"a user clicks the submit button")]
    public void WhenAUserClicksTheSubmitButton()
    {
        driver.FindElement(By.Id("submitBtn")).Click();
    }
    
    [Then(@"I verify if a new planning has been added to the planning list")]
    public void ThenIVerifyIfANewPlanningHasBeenAddedToThePlanningList()
    {
        var newPlanningList = driver.FindElements(By.ClassName("planningRow")).Count;

        newPlanningList.Should().BeGreaterThan(planningListCount);
    }
}