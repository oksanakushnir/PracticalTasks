using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using FluentAssertions.Execution;


namespace SeleniumWebDriver.PracticalTask_1
{
    [TestFixture]
    public class SigninTests
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

        [Test]
        public void VerifyTitle()
        {
            var actualTitle = Driver.Title;

            using (new AssertionScope())
            {
                actualTitle.Should().Be("GreenCity");
            }
        }

        [TestCase("samplestest@greencity.com", "weyt3$Guew^")]
        [TestCase("anotheruser@greencity.com", "anotherpassword")]
        public void SignIn(string email, string password)
        {
            var xpathSelector = "//a[contains(@class, 'header_sign-in-link')]";
            var btnSignIn = Driver.FindElement(By.XPath(xpathSelector));
            btnSignIn.Click();

            xpathSelector = "//h1[normalize-space()='Welcome back!']";
            var headerH1 = Driver.FindElement(By.XPath(xpathSelector));
            var actualH1Text = headerH1.Text;
            actualH1Text.Should().Be("Welcome back!");

            xpathSelector = "//h2[normalize-space()='Please enter your details to sign in.']";
            var headerH2 = Driver.FindElement(By.XPath(xpathSelector));
            var actualH2Text = headerH2.Text;
            actualH2Text.Should().Be("Please enter your details to sign in.");

            xpathSelector = "//label[normalize-space()='Email']";
            var lblEmail = Driver.FindElement(By.XPath(xpathSelector));
            lblEmail.Text.Should().Be("Email");

            xpathSelector = "//input[@id='email']";
            var txtEmail = Driver.FindElement(By.XPath(xpathSelector));
            txtEmail.SendKeys(email);
            txtEmail.GetAttribute("value").Should().Be(email);

            xpathSelector = "//label[normalize-space()='Password']";
            var lblPassword = Driver.FindElement(By.XPath(xpathSelector));
            lblPassword.Text.Should().Be("Password");

            xpathSelector = "//input[@id='password']";
            var txtPassword = Driver.FindElement(By.XPath(xpathSelector));
            txtPassword.SendKeys(password);
            txtPassword.GetAttribute("value").Should().Be(password);

            xpathSelector = "//button[@type='submit']";
            var btnSubmit = Driver.FindElement(By.XPath(xpathSelector));
            btnSubmit.Click();
        }


        [TestCase("Please check that your e-mail address is indicated correctly")]
        public void SignInNotValid(string errMessage)
        {
            var xpathSelector = "//a[contains(@class, 'header_sign-in-link')]";
            var btnSignIn = Driver.FindElement(By.XPath(xpathSelector));
            btnSignIn.Click();

            xpathSelector = "//input[@id='email']";
            var txtEmail = Driver.FindElement(By.XPath(xpathSelector));
            txtEmail.SendKeys("samplestestgreencity.com");

            xpathSelector = "//input[@id='password']";
            var txtPassword = Driver.FindElement(By.XPath(xpathSelector));
            txtPassword.SendKeys("testpassword");

            xpathSelector = "//div[contains(text(),'Please check that your e-mail address is indicated')]";
            var divError = Driver.FindElement(By.XPath(xpathSelector));
            divError.Text.Should().Be(errMessage);
        }
    }


}
