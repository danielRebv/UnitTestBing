using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace UnitTestBing
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class UnitTest1

    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;
        private string appURL2;

        public UnitTest1()
        {

        }


        [TestMethod]
        [TestCategory("Chrome")]
        public void TheBingSearchTest()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
            driver.FindElement(By.XPath("//label[@id='search_icon']//*[name()='svg']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'What is Azure Pipelines? - Azure Pipelines | Micro')]")).Click();
            Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        //[TestMethod]
        //[TestCategory("Chrome")]
        //public void SearchTestQA()
        //{
        //    driver.Manage().Window.Maximize();
        //    driver.Navigate().GoToUrl(appURL2 + "/");
        //    driver.FindElement(By.XPath("/html[1]/body[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]")).Click();
        //    driver.FindElement(By.XPath("(//li[@id='item-0'])[1]")).Click();
        //    driver.FindElement(By.XPath("//input[@id='userName']")).SendKeys("Daniel");
        //    driver.FindElement(By.XPath("//input[@id='userEmail']")).SendKeys("Test@Gmail.com");
        //    driver.FindElement(By.XPath("//textarea[@id='currentAddress']")).SendKeys("123 Springfield");
        //    driver.FindElement(By.XPath("//textarea[@id='permanentAddress']")).SendKeys("Fake Adress 123");
        //    driver.FindElement(By.XPath("//button[@id='submit']")).Click();
           
            
        //}

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.bing.com/";
            appURL2 = "https://demoqa.com";
            

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}