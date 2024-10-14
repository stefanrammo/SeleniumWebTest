using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace LearnSelenium
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        readonly String test_url = "https://stefanrammo23.thkit.ee/";

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestPage1()  // Navigates to the Blog page
        {
            driver.Navigate().GoToUrl(test_url);

            IWebElement sButton2 = driver.FindElement(By.XPath("//*[contains(@class, 'menu-item-1272')]"));
            sButton2.Click();

            Thread.Sleep(2500);

            IWebElement blogHeading = driver.FindElement(By.XPath("//h1[contains(text(), 'Blog')]"));

            Assert.IsTrue(blogHeading.Displayed, "TestPage1 failed: Blog page did not load successfully.");
        }

        [Test]
        public void TestPage2()  // Navigates to the About page
        {
            driver.Navigate().GoToUrl(test_url);

            IWebElement sButton2 = driver.FindElement(By.XPath("//*[@id=\"menu-item-12\"]"));
            sButton2.Click();

            Thread.Sleep(2500);

            IWebElement aboutHeading = driver.FindElement(By.XPath("//h1[contains(text(), 'Who We Are?')]"));

            Assert.IsTrue(aboutHeading.Displayed, "TestPage2 failed: About page did not load successfully.");
        }


        [Test]
        public void TestPage3() //Navigate to Contact and try to Submit a valid form
        {
            driver.Navigate().GoToUrl(test_url);

            IWebElement sButton2 = driver.FindElement(By.XPath("//*[contains(@class, 'menu-item-150')]"));
            sButton2.Click();
            Thread.Sleep(2500);

            var sText = driver.FindElement(By.XPath("//*[@id=\"wpforms-7-field_0\"]"));
            sText.Click();
            sText.SendKeys("Stefan Rammo");

            var sTextArea = driver.FindElement(By.XPath("//*[@id=\"wpforms-7-field_1\"]"));
            sTextArea.Click();
            sTextArea.SendKeys("stefanrammo@email.co.uk");

            var sTextArea1 = driver.FindElement(By.XPath("//*[@id=\"wpforms-7-field_2\"]"));
            sTextArea1.Click();
            sTextArea1.SendKeys("This is a Selenium test");

            Thread.Sleep(2500);
            IWebElement submitButton = driver.FindElement(By.XPath("//*[@id=\"wpforms-submit-7\"]"));
            submitButton.Click();

            Thread.Sleep(2500); 
            IWebElement confirmationMessage = driver.FindElement(By.XPath("//*[contains(text(), 'Thanks for contacting us! We will be in touch with you shortly.')]"));

            Assert.IsTrue(confirmationMessage.Displayed, "TestPage3 failed: Form submission did not complete successfully.");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
    }
}
