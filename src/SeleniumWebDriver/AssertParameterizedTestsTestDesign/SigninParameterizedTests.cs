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

namespace SeleniumWebDriver.AssertParameterizedTestsTestDesign
{
    public class SigninParameterizedTests
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

        [TestCase("", "", "//div[@class='alert-general-error ng-star-inserted']", "Please fill all red fields")]
        [TestCase("samplestest@greencity.com", "test", "//div[contains(text(),'Password have from 8 to 20 characters long without')]", "Password have from 8 to 20 characters long without spaces and contain at least one uppercase letter (A-Z), one lowercase letter (a-z), a digit (0-9), and a special character (~`!@#$%^&*()+=_-{}[]|:;”’?/<>,.)")]
        [TestCase("", "testpassword", "//div[contains(text(),'Email is required')]", "Email is required")]
        public void SignInNotValid(string email, string password, string errSelector, string errMessage)
        {
            var xpathSelector = "//a[contains(@class, 'header_sign-in-link')]";
            var btnSignIn = Driver.FindElement(By.XPath(xpathSelector));
            btnSignIn.Click();

            xpathSelector = "//input[@id='email']";
            var txtEmail = Driver.FindElement(By.XPath(xpathSelector));
            txtEmail.SendKeys(email);

            xpathSelector = "//input[@id='password']";
            var txtPassword = Driver.FindElement(By.XPath(xpathSelector));
            txtPassword.SendKeys(password);

            txtEmail.Clear();
            txtEmail.SendKeys(email);

            var divError = Driver.FindElement(By.XPath(errSelector));
            divError.Text.Should().Be(errMessage);
        }
    }
}
