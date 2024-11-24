using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

public class SeleniumTestBase : IDisposable
{
    protected IWebDriver Driver { get; private set; }

    public SeleniumTestBase()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        chromeOptions.AddArgument("--disable-infobars");
        chromeOptions.AddArgument("--disable-extensions");
        chromeOptions.AddArgument("--disable-popup-blocking");

        Driver = new ChromeDriver(chromeOptions);
    }

    public void Dispose()
    {
        if (Driver != null)
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
