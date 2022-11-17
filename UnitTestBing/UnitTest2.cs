using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace UnitTestBing
{
    [TestClass]
    public class UnitTest2
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public UnitTest2()
        {

        }


        [TestMethod]
        [TestCategory("Chrome")]
        public void SearchTestQA()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.XPath("(//a[@class='elementor-item'][normalize-space()='CONTACTO'])[1]")).Click();
            Assert.IsTrue(driver.Title.Contains("CONTACTO"), "Verified title of the page");

        }
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
            appURL = "https://www.tsoftglobal.com";
            
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
