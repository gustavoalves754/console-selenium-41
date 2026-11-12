using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ConsoleSelenium.Tests.Infrastructure;

internal static class ChromeDriverFactory
{
    public static IWebDriver Create()
    {
        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        service.HideCommandPromptWindow = true;

        ChromeOptions options = new();
        options.AddArgument("--headless=new");
        options.AddArgument("--window-size=1440,1000");
        options.AddArgument("--disable-search-engine-choice-screen");
        options.AddArgument("--disable-notifications");

        return new ChromeDriver(service, options);
    }
}

