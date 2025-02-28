using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    public class FormHelper
    {
        public static void Click(IWebElement locator)
        {
            locator.Click();
        }
        public static void Submit(IWebElement locator)
        {
            locator.Submit();
        }
        public static void EnterText(IWebElement locator, string text)
        {
            locator.Clear();  // clear the text from textbox
            locator.SendKeys(text);
        }

        public static void SelectDropDownByText(IWebElement locator, string text)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }
        public static void SelectDropDownByValue(IWebElement locator, string value)
        {
            SelectElement selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(IWebElement locator, string[] values)
        {
            SelectElement multiSelect = new SelectElement(locator);
            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedLists(IWebElement locator)
        {
            List<string> options = new List<string>();
            SelectElement multiSelect = new SelectElement(locator);
            IList<IWebElement> selectedOption = multiSelect.AllSelectedOptions;
            foreach (var option in selectedOption)
            {
                options.Add(option.Text);
            }
            return options;
        }
        public static List<string> GetAllCheckedCheckboxes(IWebDriver driver, IWebElement locator)
        {
            List<string> selectedValues = new List<string>();
            //var checkBox = locator;
            var checkboxes =driver.FindElements((By)locator); 

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
