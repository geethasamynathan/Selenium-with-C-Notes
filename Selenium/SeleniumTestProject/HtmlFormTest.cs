using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTestProject
{
    public class HtmlFormTest
    {
        IWebDriver driver;
        public void Setup()
        {
            driver=new ChromeDriver();

        }
        [Test]
        public void WorkingWithAdvancedControls()
        {

            IWebDriver driver = new ChromeDriver();
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            driver.Navigate().GoToUrl("file:///C:/Personal/cmr_capgemini/Testing/Selenium-with-C-Notes/Selenium/Testpage.html");
            FormHelper.EnterText(driver.FindElement(By.Id("name")), "Geetha Eswaramurthi");

            FormHelper.EnterText(driver.FindElement(By.Id("email")), "geethaeswaramurthi@outlook.com");
            FormHelper.EnterText(driver.FindElement(By.Id("doj")), "8-3-2020");
            FormHelper.Click(driver.FindElement(By.CssSelector("input[name='gender'][value='female']")));

            FormHelper.SelectDropDownByText(driver.FindElement(By.Id("city")), "Coimbatore");
            FormHelper.EnterText(driver.FindElement(By.Id("designation")), "Senior Product Engineer");

            FormHelper.MultiSelectElements(driver.FindElement(By.Id("skills")), ["testing", "cloud"]);
            var getSelectedOptions = FormHelper.GetAllSelectedLists(driver.FindElement(By.Id("skills")));

            getSelectedOptions.ForEach(Console.WriteLine);
            FormHelper.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Reading Books']")));
            FormHelper.Click(driver.FindElement(By.CssSelector("input[name='hobbies'][value='Playing Baseball']")));
           // var getSelectedHobbies = FormHelper.GetAllCheckedCheckboxes(driver, driver.FindElement(By.Name("hobbies")));
         //   getSelectedHobbies.ForEach(Console.WriteLine);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            // Clicking the Register Button
            FormHelper.Click(driver.FindElement(By.CssSelector("button[type='submit']")));

            // Validation: Ensure form submission redirects to a success page or displays a confirmation message
            Thread.Sleep(2000);  // Wait for form submission response
            bool isSubmissionSuccessful = driver.PageSource.Contains("Thank you for registering") || driver.Url.Contains("success");
            Assert.IsTrue(isSubmissionSuccessful, "Form submission failed.");


        }

        [TearDown]
        public void TearDown()
        {
            //driver.Close();
            //driver.Quit();
        }
    }
}
