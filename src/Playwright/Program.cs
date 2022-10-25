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
//Navigate to google
await page.GotoAsync("https://www.google.com");
IReadOnlyList<IFrame> f = page.Frames;
//var p = context.Pages;
if (f.Count > 1)
{
    //await f[1].ClickAsync("[aria-label=\"No thanks\"]");
    await f[1].ClickAsync("text=No thanks");
    //await f[1].PressAsync("[aria-label=\"No thanks\"]","Enter");
}
//Search
await page.FillAsync("[aria-label=\"Search\"]", "Playwright");
//Press enter
await page.RunAndWaitForNavigationAsync(async () => await page.PressAsync("[aria-label=\"Search\"]", "Enter"));
//Click on first hit
await page.ClickAsync("xpath=//h3[contains(text(),'Playwright: Fast and reliable end-to-end testing')]");
//Click get started button
await page.ClickAsync("text=Get Started");
//Screen shot
await page.ScreenshotAsync(new PageScreenshotOptions { Path = @"..\..\..\Test.png" });
Console.ReadLine();

