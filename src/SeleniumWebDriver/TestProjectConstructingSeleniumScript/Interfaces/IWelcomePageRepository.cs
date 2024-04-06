
namespace SeleniumWebDriver.TestProjectConstructingSeleniumScript.Interfaces
{
    public interface IWelcomePageRepository
    {
        string GetBtnSignInSelector();
        string GetHeaderH1Selector();
        string GetHeaderH2Selector();
        string GetLblEmailSelector();
        string GetTxtEmailSelector();
        string GetLblPasswordSelector();
        string GetTxtPasswordSelector();
        string GetBtnSubmitSelector();
        string GetDivInvalidEmailErrorSelector();
    }
}
