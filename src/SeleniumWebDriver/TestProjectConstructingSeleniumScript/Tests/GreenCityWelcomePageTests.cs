using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    [TestFixture]
    public class GreenCityWelcomePageTests : TestRunner
    {
        [Test]
        public void VerifyTitle()
        {
            var actualTitle = Driver.Title;

            using (new AssertionScope())
            {
                actualTitle.Should().Be("GreenCity");
            }
        }
    }
}
