
namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public class WelcomePageErrorRepository
    {
        public static string GetDivInvalidAllRedErrorXPathSelector()
        {
            return "//div[@class='alert-general-error ng-star-inserted']";
        }

        public static string GetDivInvalidPasswordErrorXPathSelector()
        {
            return "//div[contains(text(),'Password have from 8 to 20 characters long without')]";
        }

        public static string GetDivInvalidEmailRequiredErrorXPathSelector()
        {
            return "//div[contains(text(),'Email is required')]";
        }
    }
}
