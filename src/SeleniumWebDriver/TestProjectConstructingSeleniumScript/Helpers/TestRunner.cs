using System.IO;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;
using log4net;
using log4net.Config;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NUnit.Framework.Interfaces;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public abstract class TestRunner
    {
        protected static readonly ILog Logger = LogManager.GetLogger("TestLogger");

        protected IWebDriver Driver { get; set; }
        protected IJavaScriptExecutor JSExecutor { get; set; }

        protected IWelcomePageRepository WelcomePageRepository { get; set; }

        [OneTimeSetUp]
        public void TestOneTimeSetUp()
        {
            // Configure log4net using the configuration file
            XmlConfigurator.Configure(new FileInfo("log4net.config"));

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
            var currentStatus = TestContext.CurrentContext.Result.Outcome.Status;

            if (currentStatus == TestStatus.Failed)
            {
                var testName = TestContext.CurrentContext.Test.Name;
                var testMessage = TestContext.CurrentContext.Result.Message;
                Logger.Error($"Test - {testName} failed.");
                Logger.Debug($"Test failure result - {testMessage}");
            }

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

        protected static string CurrentTestMethod
        {
            get
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame[] stackFrames = stackTrace.GetFrames();

                if (stackFrames.Length >= 2)
                {
                    // Index 0 is the CurrentTestMethod method itself
                    // Index 1 is the YourMethod method
                    // Index 2 is the parent method
                    MethodBase parentMethod = stackFrames[1].GetMethod();
                    return parentMethod?.Name;
                }

                // If unable to retrieve the parent method name
                return "Unknown";
            }
        }
    }
}
