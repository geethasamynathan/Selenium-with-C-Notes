// 1. create a new instance of Selenium Web Driver
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

IWebDriver driver = new ChromeDriver();
// 2.Navigate to URL
driver.Navigate().GoToUrl("https://www.google.com/");
// 3. Maximize the browser window
driver.Manage().Window.Maximize();
// 4. Find the Element
IWebElement webElement = driver.FindElement(By.Name("q"));

// 5. Type in element
webElement.SendKeys("Selenium");
// 6.click on the element
webElement.SendKeys(Keys.Return);
