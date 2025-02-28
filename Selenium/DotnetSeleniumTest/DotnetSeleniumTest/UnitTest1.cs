using DotnetSeleniumTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V131.DOM;
using OpenQA.Selenium.Support.UI;

namespace DotnetSeleniumTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // 1. create a new instance of Selenium Web Driver
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
        }

        [Test]
        public void EAWebsiteTest()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");

            IWebElement loginLink = driver.FindElement(By.Id("loginLink"));
            loginLink.Click();
            IWebElement txtUserName = driver.FindElement(By.Id("UserName"));
            txtUserName.SendKeys("admin");
            IWebElement txtPassword = driver.FindElement(By.Id("Password"));
            txtPassword.SendKeys("password");
            IWebElement btnLogin2 = driver.FindElement(By.CssSelector(".btn"));
            btnLogin2.Submit();
            // Wait for the page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.TagName("img")));

            // Verify the image is present
            try
            {
                IWebElement imageElement = driver.FindElement(By.CssSelector("img[src='/Image/EA_banner_white_v1.jpg']"));
                Assert.IsTrue(imageElement.Displayed, "Image is not displayed on the page.");
                Console.WriteLine("Image is present on the page.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Image not found on the page.");
            }

            driver.Quit();
        }

        [Test]
        public void TestWithPOM()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.ClickLogin();
            loginPage.Login("admin", "password");
        }



        [Test]
        public void EAwebsiteTestReduceSizeCode()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            SeleniumCustomMethods.Click(driver.FindElement(By.Id("loginLink")));

            // driver.FindElement(By.Id("UserName")).SendKeys("admin");
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("UserName")), "admin");
            // driver.FindElement(By.Id("Password")).SendKeys("password");
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("Password")), "password");

            driver.FindElement(By.CssSelector(".btn")).Submit();
        }

        [Test]
        public void WorkingWithAdvancedControls()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Personal/cmr_capgemini/Testing/Selenium-with-C-Notes/Selenium/Testpage.html");
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("name")), "Geetha Eswaramurthi");
            
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("email")), "geethaeswaramurthi@outlook.com");
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("doj")), "8-3-2020");
            SeleniumCustomMethods.Click(driver.FindElement(By.CssSelector("input[name='gender'][value='female']")));

            SeleniumCustomMethods.SelectDropDownByText(driver.FindElement(By.Id("city")), "Coimbatore");
            SeleniumCustomMethods.EnterText(driver.FindElement(By.Id("designation")), "Senior Product Engineer");

            SeleniumCustomMethods.MultiSelectElements(driver.FindElement(By.Id("skills")), ["testing", "cloud"]);
            var getSelectedOptions = SeleniumCustomMethods.GetAllSelectedLists(driver.FindElement(By.Id("skills")));

            getSelectedOptions.ForEach(Console.WriteLine);
            SeleniumCustomMethods.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Reading Books']")));
            SeleniumCustomMethods.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Playing Baseball']")));
            var getSelectedHobbies = SeleniumCustomMethods.GetAllCheckedCheckboxes(driver,driver.FindElement(By.Name("hobbies")));
            getSelectedHobbies.ForEach(Console.WriteLine);
            // Clicking the Register Button
            SeleniumCustomMethods.Click(driver.FindElement(By.CssSelector("button[type='submit']")));

            // Validation: Ensure form submission redirects to a success page or displays a confirmation message
            Thread.Sleep(2000);  // Wait for form submission response
            bool isSubmissionSuccessful = driver.PageSource.Contains("Thank you for registering") || driver.Url.Contains("success");
            Assert.IsTrue(isSubmissionSuccessful, "Form submission failed.");

        }
    }
}