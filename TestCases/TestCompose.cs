using Automation_Test.Model;
using Automation_Test.PageObjects;
using Automation_Test.Repository;
using Automation_Test.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MongoDB.Bson;
using System.Collections;
using MongoDB.Bson.Serialization.Attributes;

namespace Automation_Test.TestCases {

    [TestClass]
    public class TestCompose {
       // [TestMethod]
        public void SendEmailTestMssqlDb() {
            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], ConfigurationManager.AppSettings["YahooUserPassword"]);

            ComposePage oComposePage = new ComposePage(oDriver);
            oComposePage.HomePage();
            List<Email> oEmailRepository = EmailRepository.Get(3);
            foreach (var oEmail in oEmailRepository) {
                oComposePage.SendEmails(oEmail);
            }
            oDriver.Close();
        }

       // [TestMethod]
        public void SendEmailTestMongoDb() {

            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], ConfigurationManager.AppSettings["YahooUserPassword"]);

            ComposePage oComposePage = new ComposePage(oDriver);
            oComposePage.HomePage();

            //0: xls , 1: mysql , 2: mongodb , 3: Mssql
            List<Email> oEmailRepository = EmailRepository.Get(2);
            foreach (var oEmail in oEmailRepository) {
                oComposePage.SendEmails(oEmail);
            }
            oDriver.Close();

        }

       // [TestMethod]
        public void SendEmailTestMysqlDb() {

            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], ConfigurationManager.AppSettings["YahooUserPassword"]);

            ComposePage oComposePage = new ComposePage(oDriver);
            oComposePage.HomePage();


            //0: xls , 1: mysql , 2: mongodb , 3: Mssql
            List<Email> oEmailRepository = EmailRepository.Get(1);
            foreach (var oEmail in oEmailRepository) {
                oComposePage.SendEmails(oEmail);
            }
            oDriver.Close();

        }


        [TestMethod]
        public void SendEmailTestXLS() {

            IWebDriver oDriver = UWebDriver.GetDriver();
            LoginPage oLoginPage = new LoginPage(oDriver);
            oLoginPage.Login(ConfigurationManager.AppSettings["YahooUserName"], ConfigurationManager.AppSettings["YahooUserPassword"]);

            ComposePage oComposePage = new ComposePage(oDriver);
            oComposePage.HomePage();


            //0: xls , 1: mysql , 2: mongodb , 3: Mssql
            List<Email> oEmailRepository = EmailRepository.Get(0);
            foreach (var oEmail in oEmailRepository) {
                oComposePage.SendEmails(oEmail);
            }
            oDriver.Close();

        }
    }


}
