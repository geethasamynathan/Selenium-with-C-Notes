using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class CalculatorTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void TestPercentageCalculation()
        {
            // Open Percentage Calculator page
            driver.Navigate().GoToUrl("https://www.calculator.net/percent-calculator.html");

            // Enter "50" in the first input field
            IWebElement num1 = driver.FindElement(By.Id("cpar1"));
            num1.Clear();
            num1.SendKeys("50");

            // Enter "10" in the second input field
            IWebElement num2 = driver.FindElement(By.Id("cpar2"));
            num2.Clear();
            num2.SendKeys("10");

            // Click the 'Calculate' button
            IWebElement calculateBtn = driver.FindElement(By.XPath("//input[@value='Calculate']"));
            calculateBtn.Click();

            // Wait for result to appear
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.ClassName("verybigtext")));

            // Get the result text
            IWebElement result = driver.FindElement(By.ClassName("verybigtext"));
            string resultText = result.Text.Trim();

            // Validate the output
            Assert.That(resultText, Is.EqualTo("50% of 10 = 5"), "Calculation result is incorrect!");

            Console.WriteLine("Test Passed: Percentage calculation is correct.");
        }

        [TearDown]
        public void TearDown()
        {

           // driver.Dispose();
            //driver.Quit();
        }
    }
}
