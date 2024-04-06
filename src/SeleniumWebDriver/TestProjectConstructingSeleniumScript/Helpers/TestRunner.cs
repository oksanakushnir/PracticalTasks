using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;
using System;
using System.Timers;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public abstract class TestRunner
    {
        protected IWebDriver Driver { get; set; }
        protected IJavaScriptExecutor JSExecutor { get; set; }

        protected IWelcomePageRepository WelcomePageRepository { get; set; }

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
            return WelcomePageRepository switch
            {
                WelcomePageXPathRepository => Driver.FindElement(By.XPath(selector)),
                WelcomePageJSInjectRepository => (IWebElement)JSExecutor.ExecuteScript(selector),
                _ => null
            };
        }
    }
}
