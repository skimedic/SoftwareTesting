// Copyright Information
// ==================================
// SoftwareTesting - PlayWright - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/07/22
// ==================================
using Microsoft.Playwright;

using IPlaywright playwright = await Playwright.CreateAsync();
await using IBrowser browser =
    await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false, SlowMo = 50 });

IBrowserContext context = await browser.NewContextAsync();
IPage page = await context.NewPageAsync();

//Navigate to letsUseData
await page.GotoAsync("https://letsusedata.com/index.html");

//Search
await page.FillAsync("id=txtUser"]", "Test1");
await page.FillAsync("id=txtPassword"]", "12345678");
                     
//Click Enter
await page.ClickAsync("id=javascriptLogin");
                     
//Screen shot
await page.ScreenshotAsync(new PageScreenshotOptions { Path = @"..\..\..\Test.png" });
Console.ReadLine();

