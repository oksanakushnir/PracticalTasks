using FluentAssertions.Execution;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;

namespace SeleniumWebDriver
{
    [TestFixture]
    public class SinginSearchWebElementsTests
    {
        private IWebDriver Driver { get; set; }

        [SetUp]
        public void TestSetUp()
        {
            Driver = new ChromeDriver();
            Driver.Url = "https://www.greencity.social/#/greenCity";
            Driver.Manage().Window.FullScreen();
        }

        [TearDown]
        public void TestTearDown()
        {
            Thread.Sleep(2000);
            Driver.Quit();
        }

        [TestCase("samplestest@greencity.com", "weyt3$Guew^")]
        [TestCase("anotheruser@greencity.com", "anotherpassword")]
        public void SignIn(string email, string password)
        {
            var jsExecutor = (IJavaScriptExecutor)Driver;

            var jsScript = "return document.querySelector(\"a[role='link']\")";
            var btnSignIn = (WebElement)jsExecutor.ExecuteScript(jsScript);
            btnSignIn.Click();

            jsScript = "return document.querySelector(\"div[class='container'] div h1\")";
            var headerH1 = (WebElement)jsExecutor.ExecuteScript(jsScript);
            var actualH1Text = headerH1.Text;
            actualH1Text.Should().Be("Welcome back!");

            jsScript = "return document.querySelector(\"div[class='container'] div h2\")";
            var headerH2 = (WebElement)jsExecutor.ExecuteScript(jsScript);
            var actualH2Text = headerH2.Text;
            actualH2Text.Should().Be("Please enter your details to sign in.");

            jsScript = "return document.querySelector(\"label[for='email']\")";
            var lblEmail = (WebElement)jsExecutor.ExecuteScript(jsScript);
            lblEmail.Text.Should().Be("Email");

            jsScript = "return document.querySelector(\"#email\")";
            var txtEmail = (WebElement)jsExecutor.ExecuteScript(jsScript);
            txtEmail.SendKeys(email);
            txtEmail.GetAttribute("value").Should().Be(email);

            jsScript = "return document.querySelector(\"label[for='password']\")";
            var lblPassword = (WebElement)jsExecutor.ExecuteScript(jsScript);
            lblPassword.Text.Should().Be("Password");

            jsScript = "return document.querySelector(\"#password\")";
            var txtPassword = (WebElement)jsExecutor.ExecuteScript(jsScript);
            txtPassword.SendKeys(password);
            txtPassword.GetAttribute("value").Should().Be(password);

            jsScript = "return document.querySelector(\"button[type='submit']\")";
            var btnSubmit = (WebElement)jsExecutor.ExecuteScript(jsScript);
            btnSubmit.Click();
        }


        [TestCase("Please check that your e-mail address is indicated correctly")]
        public void SignInNotValid(string errMessage)
        {
            var jsExecutor = (IJavaScriptExecutor)Driver;

            var jsScript = "return document.querySelector(\"a[role='link']\")";
            var btnSignIn = (WebElement)jsExecutor.ExecuteScript(jsScript);
            btnSignIn.Click();

            jsScript = "return document.querySelector(\"#email\")";
            var txtEmail = (WebElement)jsExecutor.ExecuteScript(jsScript);
            txtEmail.SendKeys("samplestestgreencity.com");

            jsScript = "return document.querySelector(\"#password\")";
            var txtPassword = (WebElement)jsExecutor.ExecuteScript(jsScript);
            txtPassword.SendKeys("testpassword");

            jsScript = "return document.querySelector(\"div[id='email-err-msg'] app-error div\")";
            var divError = (WebElement)jsExecutor.ExecuteScript(jsScript); ;
            divError.Text.Should().Be(errMessage);
        }
    }
}
