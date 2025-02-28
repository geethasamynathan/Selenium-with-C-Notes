using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    public class ImplicitWaitExample
    {
        [Test]
        public void TestImplicitWait()
        {
            IWebDriver driver = new ChromeDriver();
            //Navigating to Google's homepage
            driver.Navigate().GoToUrl("https://www.google.com");

            ////Applying Implicit Wait command for 5 seconds
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ////Clicking on an element after waiting for 20 seconds
            //driver.FindElement(By.LinkText("I'm Feeling Lucky")).Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement luckyButton = wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementToBeClickable(By.Name("RNmpXc")));
            luckyButton.Click();

            // Wait for a few seconds to observe (not needed in real automation)
            Thread.Sleep(TimeSpan.FromSeconds(5));

            driver.Quit();
        }
    }
}

