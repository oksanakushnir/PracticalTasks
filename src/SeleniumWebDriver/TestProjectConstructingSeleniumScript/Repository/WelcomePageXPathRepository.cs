using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository
{
    public class WelcomePageXPathRepository : IWelcomePageRepository
    {
        public string GetBtnSignInSelector()
        {
            return "//a[contains(@class, 'header_sign-in-link')]";
        }

        public string GetHeaderH1Selector()
        {
            return "//h1[normalize-space()='Welcome back!']";
        }

        public string GetHeaderH2Selector()
        {
            return "//h2[normalize-space()='Please enter your details to sign in.']";
        }

        public string GetLblEmailSelector()
        {
            return "//label[normalize-space()='Email']";
        }

        public string GetTxtEmailSelector()
        {
            return "//input[@id='email']";
        }

        public string GetLblPasswordSelector()
        {
            return "//label[normalize-space()='Password']";
        }

        public string GetTxtPasswordSelector()
        {
            return "//input[@id='password']";
        }

        public string GetBtnSubmitSelector()
        {
            return "//button[@type='submit']";
        }

        public string GetDivInvalidEmailErrorSelector()
        {
            return "//div[contains(text(),'Please check that your e-mail address is indicated')]";
        }
    }
}
