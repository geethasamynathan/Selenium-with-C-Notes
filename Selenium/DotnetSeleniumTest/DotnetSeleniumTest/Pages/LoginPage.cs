using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSeleniumTest.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        //locators
        //property
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));
        IWebElement TxtUserName => driver.FindElement(By.Id("UserName"));
        IWebElement TxtPassword => driver.FindElement(By.Id("Password"));
        IWebElement BtnLogin => driver.FindElement(By.CssSelector(".btn"));

        public void ClickLogin()
        {
            //LoginLink.Click();
            SeleniumCustomMethods.Click(LoginLink);
        }
        public void Login(string username, string password)
        {
            SeleniumCustomMethods.EnterText(TxtUserName, username);
            SeleniumCustomMethods.EnterText(TxtPassword, password);
            //TxtUserName.SendKeys(username);
            //TxtPassword.SendKeys(password);
            //BtnLogin.Submit();
            SeleniumCustomMethods.Submit(BtnLogin);
        }
    }
}
