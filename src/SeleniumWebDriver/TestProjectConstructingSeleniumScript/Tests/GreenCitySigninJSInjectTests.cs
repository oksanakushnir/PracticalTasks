using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCitySigninJSInjectTests : TestRunner
    {
        public GreenCitySigninJSInjectTests()
        {
            WelcomePageRepository = new WelcomePageJSInjectRepository();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignInJSInject(string email, string password)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInSelector());
            btnSignIn.Click();

            var headerH1 = FindElement(WelcomePageRepository.GetHeaderH1Selector());
            var actualH1Text = headerH1.Text;
            actualH1Text.Should().Be("Welcome back!");

            var headerH2 = FindElement(WelcomePageRepository.GetHeaderH2Selector());
            var actualH2Text = headerH2.Text;
            actualH2Text.Should().Be("Please enter your details to sign in.");

            var lblEmail = FindElement(WelcomePageRepository.GetLblEmailSelector());
            lblEmail.Text.Should().Be("Email");

            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailSelector());
            txtEmail.SendKeys(email);
            txtEmail.GetAttribute("value").Should().Be(email);

            var lblPassword = FindElement(WelcomePageRepository.GetLblPasswordSelector());
            lblPassword.Text.Should().Be("Password");

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordSelector());
            txtPassword.SendKeys(password);
            txtPassword.GetAttribute("value").Should().Be(password);

            var btnSubmit = FindElement(WelcomePageRepository.GetBtnSubmitSelector());
            btnSubmit.Click();
        }


        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmailJSInject(string email, string password, string errMessage)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInSelector());
            btnSignIn.Click();

            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailSelector());
            txtEmail.SendKeys(email);

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordSelector());
            txtPassword.SendKeys(password);

            var divError = FindElement(WelcomePageRepository.GetDivInvalidEmailErrorSelector());
            divError.Text.Should().Be(errMessage);
        }
    }
}