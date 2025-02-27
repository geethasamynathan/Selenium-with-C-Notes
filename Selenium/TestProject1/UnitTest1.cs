using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class GoogleSearchTest
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");


        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [Test]
    public void SearchForSeleniumTest()
    {
        // Open Google
        driver.Navigate().GoToUrl("https://www.google.com/");

        // Accept cookies if prompted
        try
        {
            var acceptButton = driver.FindElement(By.CssSelector("button[aria-label='Accept all']"));
            acceptButton.Click();
        }
        catch (NoSuchElementException) { } // Ignore if not present

        // Enter search text
        IWebElement searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys("Selenium C# Test");
        searchBox.SendKeys(Keys.Enter);

        // Wait for results
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //wait.Until(d => d.FindElement(By.CssSelector("h3")));

        // Verify that search results appear
        var searchResults = driver.FindElements(By.CssSelector("h3")).ToList();
        bool resultsDisplayed = searchResults.Count > 0;

        Assert.That(resultsDisplayed, Is.True, "Search results were not displayed.");

        // List elements & values
        Console.WriteLine("Search results:");
        foreach (var result in searchResults)
        {
            Console.WriteLine(result.Text);
        }

        Console.WriteLine("Test Passed: Search results were found.");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
        driver.Quit();
    }
}
