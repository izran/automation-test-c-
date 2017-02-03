using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation_Test.PageObjects;
using Automation_Test.Utility;
using OpenQA.Selenium;
using System.Configuration;
//https://www.screencast.com/t/sbGJq8jPs
namespace Automation_Test {
   [TestClass]
    public class TestLogin {
       // [TestMethod]
        public void testLoginIncorrectCredentials() {
            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login("incorrectUserName@yahoo.com", "incorrectPassword");
            oDriver.Close();
        }

        //[TestMethod]
        public void testLoginBlankPassword() {
            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], "");
            oDriver.Close();
        }

       [TestMethod]
        public void loginTest() {
            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], ConfigurationManager.AppSettings["YahooUserPassword"]);
            oDriver.Close();
        }
       
    }
}
