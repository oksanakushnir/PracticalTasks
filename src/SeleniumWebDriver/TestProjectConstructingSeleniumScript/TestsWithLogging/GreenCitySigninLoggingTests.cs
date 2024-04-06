using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests;
using FluentAssertions;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.TestsWithLogging
{
    [TestFixture]
    public class GreenCitySigninLoggingTests : TestRunner
    {
        private WelcomePageValidator WelcomePageValidator { get; }

        public GreenCitySigninLoggingTests()
        {
            WelcomePageRepository = new WelcomePageXPathRepository();
            WelcomePageValidator = new WelcomePageValidator();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignIn(string email, string password)
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
            WelcomePageValidator.SignInWithValidData(new SignInWithValidDataRecord(FindElement, WelcomePageRepository, email, password));
            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmail(string email, string password, string errMessage)
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
            WelcomePageValidator.SignInWithInvalidEmail(new SignInWithInvalidEmailRecord(FindElement, WelcomePageRepository, email, password, errMessage));
            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInNotValid))]
        public void SignInNotValid(string email, string password, string errSelector, string errMessage)
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
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
            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }
    }
}
