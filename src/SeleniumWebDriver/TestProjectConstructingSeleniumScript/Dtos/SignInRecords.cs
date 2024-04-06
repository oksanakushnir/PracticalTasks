using System;
using OpenQA.Selenium;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos
{
    public record SignInWithValidDataRecord(
        Func<string, IWebElement> FindElementHandler,
        IWelcomePageRepository WelcomePageRepository,
        string Email,
        string Password
    );
    
    public record SignInWithInvalidEmailRecord(
        Func<string, IWebElement> FindElementHandler,
        IWelcomePageRepository WelcomePageRepository,
        string Email,
        string Password,
        string ErrMessage
    );

}
