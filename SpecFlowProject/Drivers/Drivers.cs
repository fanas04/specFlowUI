using Microsoft.Playwright;

namespace SpecFlowProject.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;
        private bool disposedValue;

        public Driver() => _page = InitializePlaywright();
        public IPage Page => _page.Result;

        public async Task<IPage> InitializePlaywright()
        {
            var playwright = await Playwright.CreateAsync();

            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                //  Headless = false // Set headless option to false for non-headless mode
                   SlowMo = 300
            });

            return await _browser.NewPageAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _browser?.CloseAsync();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}