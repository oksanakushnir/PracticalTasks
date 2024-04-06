using FluentAssertions;
using SeleniumWebDriver.TestProjectConstructingSeleniumScript.Dtos;

namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Tests
{
    public class WelcomePageValidator
    {
        public void SignInWithValidData(SignInWithValidDataRecord dataRec)
        {
            var btnSignIn = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetBtnSignInSelector());
            btnSignIn.Click();

            var headerH1 = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetHeaderH1Selector());
            var actualH1Text = headerH1.Text;
            actualH1Text.Should().Be("Welcome back!");

            var headerH2 = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetHeaderH2Selector());
            var actualH2Text = headerH2.Text;
            actualH2Text.Should().Be("Please enter your details to sign in.");

            var lblEmail = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetLblEmailSelector());
            lblEmail.Text.Should().Be("Email");

            var txtEmail = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetTxtEmailSelector());
            txtEmail.SendKeys(dataRec.Email);
            txtEmail.GetAttribute("value").Should().Be(dataRec.Email);

            var lblPassword = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetLblPasswordSelector());
            lblPassword.Text.Should().Be("Password");

            var txtPassword = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetTxtPasswordSelector());
            txtPassword.SendKeys(dataRec.Password);
            txtPassword.GetAttribute("value").Should().Be(dataRec.Password);

            var btnSubmit = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetBtnSubmitSelector());
            btnSubmit.Click();
        }

        public void SignInWithInvalidEmail(SignInWithInvalidEmailRecord dataRec)
        {
            var btnSignIn = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetBtnSignInSelector());
            btnSignIn.Click();

            var txtEmail = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetTxtEmailSelector());
            txtEmail.SendKeys(dataRec.Email);

            var txtPassword = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetTxtPasswordSelector());
            txtPassword.SendKeys(dataRec.Password);

            var divError = dataRec.FindElementHandler(dataRec.WelcomePageRepository.GetDivInvalidEmailErrorSelector());
            divError.Text.Should().Be(dataRec.ErrMessage);
        }
    }
}
