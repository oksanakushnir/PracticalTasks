using NUnit.Framework;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.TestsWithLogging
{
    [TestFixture]
    internal class GreenCitySigninJSInjectLoggingTests : TestRunner
    {
        private WelcomePageValidator WelcomePageValidator { get; }

        public GreenCitySigninJSInjectLoggingTests()
        {
            WelcomePageRepository = new WelcomePageJSInjectRepository();
            WelcomePageValidator = new WelcomePageValidator();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignInJSInject(string email, string password)
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
            WelcomePageValidator.SignInWithValidData(new SignInWithValidDataRecord(FindElement, WelcomePageRepository, email, password));
            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }


        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmailJSInject(string email, string password, string errMessage)
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
            WelcomePageValidator.SignInWithInvalidEmail(new SignInWithInvalidEmailRecord(FindElement, WelcomePageRepository, email, password, errMessage));
            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }
    }
}
