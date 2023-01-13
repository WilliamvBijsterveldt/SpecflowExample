using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace Specflow.tests.Selenium;

public class SeleniumDriver
{
    private IWebDriver _driver;

    private readonly ScenarioContext _scenarioContext;

    public SeleniumDriver(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    public IWebDriver Setup()
    {
        _driver = new ChromeDriver();
        
        _scenarioContext.Set(_driver, "WebDriver");
        
        _driver.Manage().Window.Maximize();
        
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

        return _driver;
    }
}