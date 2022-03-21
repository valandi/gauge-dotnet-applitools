using Applitools;
using Applitools.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using Gauge.CSharp.Lib.Attribute;
using FluentAssertions;

namespace netcore.template
{
    public class StepImplementation
    { 

        private EyesRunner runner;
        private Eyes eyes;

        private IWebDriver driver;

        [BeforeSpec]
        public void setup() {
            runner = new ClassicRunner();
            eyes = new Eyes(runner);
            driver = new ChromeDriver();
        }

        [Step("Run simple Applitools test")]
        public void simpleApplitoolsTest() {
            eyes.Open(driver, "Demo App", "Smoke Test", new Size(800, 600));
            driver.Url = "https://demo.applitools.com/";
            eyes.CheckWindow("Login Page");
            driver.FindElement(By.Id("log-in")).Click();
            eyes.CheckWindow("App Window");
            eyes.CloseAsync();
            true.Should().Be(true);
        }

        [AfterSpec]
        public void tearDown() {
            driver.Quit();
            eyes.CloseAsync();
            TestResultsSummary allTestResults = runner.GetAllTestResults();
        }
    }
}
