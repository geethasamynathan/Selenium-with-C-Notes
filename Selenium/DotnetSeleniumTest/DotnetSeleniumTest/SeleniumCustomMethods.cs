using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSeleniumTest
{
    public class SeleniumCustomMethods
    {
        public static void Click(IWebDriver driver,By locator)
        {
            driver.FindElement(locator).Click();
        }
        public static void EnterText(IWebDriver driver,By locator,string text) {
            driver.FindElement(locator).Clear();  // clear the text from textbox
            driver.FindElement(locator).SendKeys(text);
        }

        public static void SelectDropDownByText (IWebDriver driver,By locator,string text)
        {
           SelectElement selectElement=new SelectElement(driver.FindElement(locator)); 
           selectElement.SelectByText(text);
        }
        public static void SelectDropDownByValue(IWebDriver driver, By locator, string value)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(value);
        }
        
        public static void MultiSelectElements(IWebDriver driver, By locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(IWebDriver driver,By locator) {
            List<string> options=new List<string>();
            SelectElement multiSelect = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
        public static List<string> GetAllCheckedCheckboxes(IWebDriver driver, By locator)
        {
            List<string> selectedValues = new List<string>();
            var checkboxes = driver.FindElements(locator);

            foreach (var checkbox in checkboxes)
            {
                if (checkbox.Selected)  // If the checkbox is checked
                {
                    selectedValues.Add(checkbox.GetAttribute("value"));
                }
            }
            return selectedValues;
        }

    }
}
