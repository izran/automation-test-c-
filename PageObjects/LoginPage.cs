using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test.PageObjects {
    class LoginPage {
        IWebDriver oWebDriver = null;

        [FindsBy(How = How.Id, Using = "uh-mail")]
        public IWebElement ProfileButton { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[2]/div/div/div/div/div/div/div[2]/div/ul/li[1]/a")]
        public IWebElement SigneButton { get; set; }

        [FindsBy(How = How.Id, Using = "login-signin")]

        public IWebElement SigneButton1 { get; set; }

        [FindsBy(How = How.Id, Using = "uh-profile")]
        public IWebElement btnUhProfile { get; set; }

        [FindsBy(How = How.Id, Using = "login-username")]
        public IWebElement UserName { get; set; }
        
        [FindsBy(How = How.Id, Using = "login-passwd")]
        public IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = @".//*[@id='uh-signedout']/span")]
        public IWebElement LogOut { get; set; }

        [FindsBy(How = How.XPath, Using = @".//*[@id='mbr-login-error']")]

        public IWebElement LoginError { get; set; }

        public LoginPage(IWebDriver rWebDriver) {
            this.oWebDriver = rWebDriver;
            PageFactory.InitElements(this.oWebDriver, this);
        }
        public void Login(string pUserName, string pPassword) {
         

            SigneButton.Click();
            System.Threading.Thread.Sleep(1000);
            UserName.SendKeys(pUserName);
            SigneButton1.Click();
            System.Threading.Thread.Sleep(1000);
            UserPassword.SendKeys(pPassword);
            System.Threading.Thread.Sleep(1000);
            SigneButton1.Click();
        }
    }
}
