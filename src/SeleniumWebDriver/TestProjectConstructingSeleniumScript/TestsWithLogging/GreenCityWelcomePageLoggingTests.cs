using FluentAssertions.Execution;
using NUnit.Framework;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;
using FluentAssertions;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.TestsWithLogging
{
    [TestFixture]
    public class GreenCityWelcomePageLoggingTests : TestRunner
    {
        [Test]
        public void VerifyTitle()
        {
            Logger.Info($"Started - {CurrentTestMethod} Test ");
            var actualTitle = Driver.Title;

            using (new AssertionScope())
            {
                actualTitle.Should().Be("GreenCity");
            }

            Logger.Info($"Finished - {CurrentTestMethod} Test");
        }
    }
}
