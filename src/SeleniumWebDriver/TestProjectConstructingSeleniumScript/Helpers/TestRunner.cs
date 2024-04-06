using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public abstract class TestRunner
    {
        protected IWebDriver Driver { get; set; }
        protected IJavaScriptExecutor JSExecutor { get; set; }

        [OneTimeSetUp]
        public void TestOneTimeSetUp()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://www.greencity.social/#/greenCity";
            Driver.Manage().Window.FullScreen();

            JSExecutor = (IJavaScriptExecutor)Driver;
        }

        [SetUp]
        public void TestSetUp()
        {
            Driver.Url = "https://www.greencity.social/#/greenCity";
        }

        [OneTimeTearDown]
        public void TestOneTimeTearDown()
        {
            Thread.Sleep(2000);
            Driver.Quit();
        }

        [TearDown]
        public void TestTearDown()
        {
            Thread.Sleep(3000);
        }

        protected IWebElement FindElement(string selector)
        {
            return Driver.FindElement(By.XPath(selector));
        }
    }
}
