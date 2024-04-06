using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Repository
{
    public class WelcomePageJSInjectRepository : IWelcomePageRepository
    {
        public string GetBtnSignInSelector()
        {
            return "return document.querySelector(\"a[role='link']\")";
        }

        public string GetHeaderH1Selector()
        {
            return "return document.querySelector(\"div[class='container'] div h1\")";
        }

        public string GetHeaderH2Selector()
        {
            return "return document.querySelector(\"div[class='container'] div h2\")";
        }

        public string GetLblEmailSelector()
        {
            return "return document.querySelector(\"label[for='email']\")";
        }

        public string GetTxtEmailSelector()
        {
            return "return document.querySelector(\"#email\")";
        }

        public string GetLblPasswordSelector()
        {
            return "return document.querySelector(\"label[for='password']\")";
        }

        public string GetTxtPasswordSelector()
        {
            return "return document.querySelector(\"#password\")";
        }

        public string GetBtnSubmitSelector()
        {
            return "return document.querySelector(\"button[type='submit']\")";
        }

        public string GetDivInvalidEmailErrorSelector()
        {
            return "return document.querySelector(\"div[id='email-err-msg'] app-error div\")";
        }
    }
}
