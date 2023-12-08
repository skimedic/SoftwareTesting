// Copyright Information
// ==================================
// SoftwareTesting - PlaywrightTests - UserInterfaceTests.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================

namespace PlaywrightTests;

public class UserInterfaceTests
{
    //https://medium.com/version-1/playwright-a-modern-end-to-end-testing-for-web-app-with-c-language-support-c55e931273ee#:~
    [Fact]
    public static async Task VerifyGoogleSearchForPlaywright()
    {
        using IPlaywright playwright = await Playwright.CreateAsync();
        await using var browser =
            await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false, SlowMo = 50 });

        IBrowserContext context = await browser.NewContextAsync();

        IPage page = await context.NewPageAsync();
        // Navigate to letsusedata.com
        await page.GotoAsync("https://www.letsusedata.com/");
        
        // Fill in the login credentials for Test1
        await page.FillAsync("#txtUser", "Test1");
        await page.FillAsync("#txtPassword", "12345678");
    
        // Click on the login button
        await page.ClickAsync("#javascriptLogin");
        
        // Verify that the user is logged in successfully
        Assert.Equal("https://www.letsusedata.com/CourseSelection.html", page.Url);
    
        // Optionally, we can navigate back to the login page or start a new page for the next test user
        await page.GotoAsync("https://www.letsusedata.com/");
    
        // Fill in the login credentials for Test2
        await page.FillAsync("#txtUser", "Test2");
        await page.FillAsync("#txtPassword", "iF3sBF7c");
    
        // Click on the login button
        await page.ClickAsync("#javascriptLogin");
        
        // Verify that the user is logged in successfully
        Assert.Equal("https://www.letsusedata.com/CourseSelection.html", page.Url);
    }
}
