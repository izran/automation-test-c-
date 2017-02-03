using Automation_Test.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test.PageObjects {
    class ComposePage {

 
    IWebDriver oWebDriver = null;

        [FindsBy(How = How.Id, Using = "uh-mail")]
        public IWebElement ProfileButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Compose')]")]
        public IWebElement ComposeLink { get; set; }

        [FindsBy(How = How.Id, Using = "to-field")]

        public IWebElement ToEmailtxt { get; set; }

        [FindsBy(How = How.Id, Using = "subject-field")]
        public IWebElement Subjecttxt { get; set; }

        [FindsBy(How = How.Id, Using = "rtetext")]
        public IWebElement Body { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Send this email')]")]
        public IWebElement SendEmailLink { get; set; }

        [FindsBy(How = How.XPath, Using = @"//span[contains(text(),'Sent')]")]
        public IWebElement SendListlink { get; set; }

        public ComposePage(IWebDriver rWebDriver) {
            this.oWebDriver = rWebDriver;
            PageFactory.InitElements(this.oWebDriver, this);
        }
        public void SendEmails(Email oEmail) {
            //ProfileButton.Click();
            System.Threading.Thread.Sleep(1000);
            
            ComposeLink.Click();
            System.Threading.Thread.Sleep(1000);

            ToEmailtxt.SendKeys(oEmail.ToEmail);
            System.Threading.Thread.Sleep(1000);
            Subjecttxt.SendKeys(oEmail.Subject);
            System.Threading.Thread.Sleep(1000);
            Body.SendKeys(oEmail.Body);
            System.Threading.Thread.Sleep(1000);
            SendEmailLink.Click();
            System.Threading.Thread.Sleep(1000);
            SendListlink.Click();
            System.Threading.Thread.Sleep(1000);
        }

        public void HomePage()  {
            System.Threading.Thread.Sleep(3000);
            ProfileButton.Click();
        }
    }
}
