using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCitySigninTests : TestRunner
    {
        private WelcomePageValidator WelcomePageValidator { get; }

        public GreenCitySigninTests()
        {
            WelcomePageRepository = new WelcomePageXPathRepository();
            WelcomePageValidator = new WelcomePageValidator();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignIn(string email, string password)
        {
            WelcomePageValidator.SignInWithValidData(new SignInWithValidDataRecord(FindElement, WelcomePageRepository, email, password));
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmail(string email, string password, string errMessage)
        {
            WelcomePageValidator.SignInWithInvalidEmail(new SignInWithInvalidEmailRecord(FindElement, WelcomePageRepository, email, password, errMessage));
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInNotValid))]
        public void SignInNotValid(string email, string password, string errSelector, string errMessage)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInSelector());
            btnSignIn.Click();

            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailSelector());
            txtEmail.SendKeys(email);

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordSelector());
            txtPassword.SendKeys(password);

            txtEmail.Clear();
            txtEmail.SendKeys(email);

            var divError = Driver.FindElement(By.XPath(errSelector));
            divError.Text.Should().Be(errMessage);
        }

    }
}
