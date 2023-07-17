using FluentAssertions;
using Microsoft.Playwright;


namespace SpecFlowProject.Pages
{
    public class LoginPage
    {
        private IPage _page;
        private ILocator _txtUserName => _page.Locator("input[name=\"email\"]");
        private ILocator _txtPassword => _page.Locator("input[name=\"password\"]");
        private ILocator _btnLogin => _page.GetByRole(AriaRole.Button, new() { Name = "Log in" });
        private ILocator _treeText => _page.Locator(selector: "text='Sveiki, qmjumtt971@fatamail.com'");
        private ILocator _loginPageAlertMessage => _page.Locator(selector: "text='Captcha check failed. Try submitting your form again.'");
        private ILocator _homePageLoginButton => _page.Locator(selector: "id=hgr-topmenu-login");
        private ILocator _acceptCookiePolicy => _page.GetByRole(AriaRole.Button, new() { Name = "Accept" });

        public LoginPage(IPage page) => _page = page;

        public async Task ClickLogin() => await _btnLogin.ClickAsync(new() { Timeout = 3000 });

        public async Task AcceptCookiePolicy() => await _acceptCookiePolicy.ClickAsync(new() { Timeout = 3000 });

        public async Task HomePageLoginButton() => await _homePageLoginButton.ClickAsync(new() { Timeout = 3000 });

        public async Task SendUserName(string userName) => await _txtUserName.FillAsync(userName);

        public async Task SendPassword(string password) => await _txtPassword.FillAsync(password);

        public async Task IsTreeTextExist()
        {
            await _treeText.WaitForAsync();
            var isExist = await _treeText.IsVisibleAsync();
            isExist.Should().BeTrue();
        }
        public async Task LoginPageAlertMessage()
        {
            await _loginPageAlertMessage.WaitForAsync();
            var isExist = await _loginPageAlertMessage.IsVisibleAsync();
            isExist.Should().BeTrue();
        }
        public async Task PrintScreen()
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            var screenshotPath = $"C:\\DELME\\SpecFlowUITests1\\SpecFlowProject\\SpecFlowProject\\Evidence\\screenshot_{timestamp}.png";
            await _page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = screenshotPath
            });
        }      
    }
}
