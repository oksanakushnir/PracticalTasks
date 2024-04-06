using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCitySigninTests : TestRunner
    {
        private static IWelcomePageRepository WelcomePageRepository { get; } = new WelcomePageRepository(RepositorySelectorType.XPath);

        //public GreenCitySigninTests()
        //{
        //    //WelcomePageRepository = new WelcomePageRepository(RepositorySelectorType.XPath);
        //}

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignIn))]
        public void SignIn(string email, string password)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInXPathSelector());
            btnSignIn.Click();

            var headerH1 = FindElement(WelcomePageRepository.GetHeaderH1XPathSelector());
            var actualH1Text = headerH1.Text;
            actualH1Text.Should().Be("Welcome back!");

            var headerH2 = FindElement(WelcomePageRepository.GetHeaderH2XPathSelector());
            var actualH2Text = headerH2.Text;
            actualH2Text.Should().Be("Please enter your details to sign in.");

            var lblEmail = FindElement(WelcomePageRepository.GetLblEmailXPathSelector());
            lblEmail.Text.Should().Be("Email");

            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailXPathSelector());
            txtEmail.SendKeys(email);
            txtEmail.GetAttribute("value").Should().Be(email);

            var lblPassword = FindElement(WelcomePageRepository.GetLblPasswordXPathSelector());
            lblPassword.Text.Should().Be("Password");

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordXPathSelector());
            txtPassword.SendKeys(password);
            txtPassword.GetAttribute("value").Should().Be(password);
            
            var btnSubmit = FindElement(WelcomePageRepository.GetBtnSubmitXPathSelector());
            btnSubmit.Click();
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInInvalidEmail))]
        public void SignInInvalidEmail(string email, string password, string errMessage)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInXPathSelector());
            btnSignIn.Click();
            
            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailXPathSelector());
            txtEmail.SendKeys(email);

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordXPathSelector());
            txtPassword.SendKeys(password);
            
            var divError = FindElement(WelcomePageRepository.GetDivInvalidEmailErrorXPathSelector());
            divError.Text.Should().Be(errMessage);
        }

        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetTestDataForSignInNotValid))]
        public void SignInNotValid(string email, string password, string errSelector, string errMessage)
        {
            var btnSignIn = FindElement(WelcomePageRepository.GetBtnSignInXPathSelector());
            btnSignIn.Click();

            var txtEmail = FindElement(WelcomePageRepository.GetTxtEmailXPathSelector());
            txtEmail.SendKeys(email);

            var txtPassword = FindElement(WelcomePageRepository.GetTxtPasswordXPathSelector());
            txtPassword.SendKeys(password);

            txtEmail.Clear();
            txtEmail.SendKeys(email);

            var divError = Driver.FindElement(By.XPath(errSelector));
            divError.Text.Should().Be(errMessage);
        }

    }
}
