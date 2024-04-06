using NUnit.Framework;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCitySigninJSInjectTests : TestRunner
    {
        private WelcomePageValidator WelcomePageValidator { get; }

        public GreenCitySigninJSInjectTests()
        {
            WelcomePageRepository = new WelcomePageJSInjectRepository();
            WelcomePageValidator = new WelcomePageValidator();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignInJSInject(string email, string password)
        {
            WelcomePageValidator.SignInWithValidData(new SignInWithValidDataRecord(FindElement, WelcomePageRepository, email, password));
        }


        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmailJSInject(string email, string password, string errMessage)
        {
            WelcomePageValidator.SignInWithInvalidEmail(new SignInWithInvalidEmailRecord(FindElement, WelcomePageRepository, email, password, errMessage));
        }
    }
}