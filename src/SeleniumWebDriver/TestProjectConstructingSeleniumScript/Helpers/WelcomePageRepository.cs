
namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Helpers
{
    public interface IWelcomePageRepository
    {
        string GetBtnSignInXPathSelector();
        string GetHeaderH1XPathSelector();
        string GetHeaderH2XPathSelector();
        string GetLblEmailXPathSelector();
        string GetTxtEmailXPathSelector();
        string GetLblPasswordXPathSelector();
        string GetTxtPasswordXPathSelector();
        string GetBtnSubmitXPathSelector();
        string GetDivInvalidEmailErrorXPathSelector();
    }

    public class WelcomePageRepository : IWelcomePageRepository
    {
        private RepositorySelectorType SelectorType { get; set; }

        public WelcomePageRepository(RepositorySelectorType selectorType) => SelectorType = selectorType;

        public string GetBtnSignInXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//a[contains(@class, 'header_sign-in-link')]",
                RepositorySelectorType.JSInject => "return document.querySelector(\"a[role='link']\")",
                _ => ""
            };
        }

        public string GetHeaderH1XPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//h1[normalize-space()='Welcome back!']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"div[class='container'] div h1\")",
                _ => ""
            };
        }

        public string GetHeaderH2XPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//h2[normalize-space()='Please enter your details to sign in.']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"div[class='container'] div h2\")",
                _ => ""
            };
        }

        public string GetLblEmailXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//label[normalize-space()='Email']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"label[for='email']\")",
                _ => ""
            };
        }

        public string GetTxtEmailXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//input[@id='email']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"#email\")",
                _ => ""
            };
        }

        public string GetLblPasswordXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//label[normalize-space()='Password']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"label[for='password']\")",
                _ => ""
            };
        }

        public string GetTxtPasswordXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//input[@id='password']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"#password\")",
                _ => ""
            };
        }

        public string GetBtnSubmitXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//button[@type='submit']",
                RepositorySelectorType.JSInject => "return document.querySelector(\"button[type='submit']\")",
                _ => ""
            };
        }

        public string GetDivInvalidEmailErrorXPathSelector()
        {
            return SelectorType switch
            {
                RepositorySelectorType.XPath => "//div[contains(text(),'Please check that your e-mail address is indicated')]",
                RepositorySelectorType.JSInject => "return document.querySelector(\"div[id='email-err-msg'] app-error div\")",
                _ => ""
            };
        }
    }
}
