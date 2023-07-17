using SpecFlowProject.Drivers;
using SpecFlowProject.Pages;
using Newtonsoft.Json;
using TechTalk.SpecFlow;


namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public sealed class LoginPageStepDefinitions
    {
#if DEBUG
        private const string CONF_NAME = "Development";
#elif _INTERNALDEV
        private const string CONF_NAME = "InternalDev";
#elif _HOTFIXINTERNALDEV
        private const string CONF_NAME = "HotfixInternalDev";
#elif _TEST
        private const string CONF_NAME = "Test";
#elif _HOTFIXTEST
        private const string CONF_NAME = "HotfixTest";
#elif _PREPROD
        private const string CONF_NAME = "PreProd";
#endif
        private readonly Driver _driver;
        private readonly LoginPage _loginPage;

        private static string _envUrl;
        private static string GetEnvUrl() => GetCfg().AppSettings.WEB_URL;

        private static dynamic GetCfg()
        {
            var cfgJson = File.ReadAllText($"appsettings.{CONF_NAME}.json");
            return JsonConvert.DeserializeObject(cfgJson);
        }

        public LoginPageStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(_driver.Page);
        }

        [Given(@"I navigate to application")]
        public void GivenUserNavigateToApplication()
        {
            _envUrl = GetEnvUrl();
            _driver.Page.GotoAsync(url: _envUrl);
        }

        [Given(@"I click login button on home page")]
        public async Task GivenClicksLoginButtonOnHomePage()
        {
            await _loginPage.HomePageLoginButton();
        }


        [When(@"I click login button")]
        public async Task GivenUserClickLoginLink()
        {
            await _loginPage.ClickLogin();
        }

        [Then(@"the welcome text must be visible")]
        public async Task ThenUserAbleToSeeNodeLists()
        {
            await _loginPage.IsTreeTextExist();
        }

        [Given(@"I accept Cookie Policy")]
        public async Task GivenIAcceptCookiePolicy()
        {
            await _loginPage.AcceptCookiePolicy();
        }

        [Then(@"I see alert message")]
        public async Task ThenUserSeeAlertMessage()
        {
            await _loginPage.LoginPageAlertMessage();
        }

        [When(@"save printscreen")]
        public async Task ThenSavePrintPrintscreen()
        {
            await _loginPage.PrintScreen();
        }

        [Given(@"I enter username '(.*)'")]
        public async Task GivenUserEnterUsername(string username)
        {
            await _loginPage.SendUserName(username);
        }

        [Given(@"I enter password '(.*)'")]
        public async Task GivenUserEnterPassword(string password)
        {
            await _loginPage.SendPassword(password);
        }
    }
}