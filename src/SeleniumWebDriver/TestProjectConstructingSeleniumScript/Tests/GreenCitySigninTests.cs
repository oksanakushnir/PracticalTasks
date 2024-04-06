using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCitySigninTests : TestRunner
    {
        private WelcomePageValidator WelcomePageValidator { get; set; }

        public GreenCitySigninTests()
        {
            WelcomePageRepository = new WelcomePageXPathRepository();
            WelcomePageValidator = new WelcomePageValidator();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignIn(string email, string password)
        {
            WelcomePageValidator.SignInWithValidData(new SignInWithValidDataRecord(FindElement, WelcomePageRepository, email, password));

            //var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInSelector());
            //btnSignIn.Click();

            //var headerH1 = FindElement(WelcomePageRepository.GetHeaderH1Selector());
            //var actualH1Text = headerH1.Text;
            //actualH1Text.Should().Be("Welcome back!");

            //var headerH2 = FindElement(WelcomePageRepository.GetHeaderH2Selector());
            //var actualH2Text = headerH2.Text;
            //actualH2Text.Should().Be("Please enter your details to sign in.");

            //var lblEmail = FindElement(WelcomePageRepository.GetLblEmailSelector());
            //lblEmail.Text.Should().Be("Email");

            //var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailSelector());
            //txtEmail.SendKeys(email);
            //txtEmail.GetAttribute("value").Should().Be(email);

            //var lblPassword = FindElement(WelcomePageRepository.GetLblPasswordSelector());
            //lblPassword.Text.Should().Be("Password");

            //var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordSelector());
            //txtPassword.SendKeys(password);
            //txtPassword.GetAttribute("value").Should().Be(password);

            //var btnSubmit = FindElement(WelcomePageRepository.GetBtnSubmitSelector());
            //btnSubmit.Click();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmail(string email, string password, string errMessage)
        {
            WelcomePageValidator.SignInWithInvalidEmail(new SignInWithInvalidEmailRecord(FindElement, WelcomePageRepository, email, password, errMessage));

            //var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInSelector());
            //btnSignIn.Click();

            //var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailSelector());
            //txtEmail.SendKeys(email);

            //var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordSelector());
            //txtPassword.SendKeys(password);

            //var divError = FindElement(WelcomePageRepository.GetDivInvalidEmailErrorSelector());
            //divError.Text.Should().Be(errMessage);
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
