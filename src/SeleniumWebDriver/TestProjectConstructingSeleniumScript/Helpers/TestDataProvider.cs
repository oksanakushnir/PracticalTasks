using NUnit.Framework;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository;
using System.Collections.Generic;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public static class TestDataProvider
    {
        public static IEnumerable<TestCaseData> GetTestDataForSignIn()
        {
            yield return new TestCaseData("samplestest@greencity.com", "weyt3$Guew^");
            yield return new TestCaseData("anotheruser@greencity.com", "anotherpassword");
        }

        public static IEnumerable<TestCaseData> GetTestDataForSignInInvalidEmail()
        {
            yield return new TestCaseData("samplestestgreencity.com", "testpassword", "Please check that your e-mail address is indicated correctly");
        }

        public static IEnumerable<TestCaseData> GetTestDataForSignInNotValid()
        {
            yield return new TestCaseData(
                "",
                "",
                WelcomePageErrorRepository.GetDivInvalidAllRedErrorXPathSelector(),
                "Please fill all red fields"
            );

            yield return new TestCaseData(
                "samplestest@greencity.com",
                "test",
                WelcomePageErrorRepository.GetDivInvalidPasswordErrorXPathSelector(),
                "Password have from 8 to 20 characters long without spaces and contain at least one uppercase letter (A-Z), one lowercase letter (a-z), a digit (0-9), and a special character (~`!@#$%^&*()+=_-{}[]|:;”’?/<>,.)"
            );

            yield return new TestCaseData(
                "",
                "testpassword",
                WelcomePageErrorRepository.GetDivInvalidEmailRequiredErrorXPathSelector(),
                "Email is required"
            );
        }
    }
}
