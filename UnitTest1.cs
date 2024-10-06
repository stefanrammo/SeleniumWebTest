using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using System.Threading;

namespace SeleniumCSharp
{
    [TestFixture]
    public class Tests
    {
        OpenQA.Selenium.Chrome.ChromeDriver driver;
        readonly String test_url = "https://stefanrammo23.thkit.ee/";

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestPage1()
        {
            driver.Url = test_url;
            driver.Navigate().GoToUrl("https://stefanrammo23.thkit.ee/");

            try { IWebElement sButton2 = driver.FindElement(By.XPath("//*[@class=\"menu-item-1272\"]")); sButton2.Click(); } catch (Exception) { }
            Thread.Sleep(2500);
        }

        [Test]
        public void TestPage2()
        {
            driver.Url = test_url;
            driver.Navigate().GoToUrl("https://stefanrammo23.thkit.ee/");

            try { IWebElement sButton2 = driver.FindElement(By.XPath("//*[@class=\"menu-item-12\"]")); sButton2.Click(); } catch (Exception) { }
            Thread.Sleep(2500);
        }

        [Test]
        public void TestPage3()
        {
            driver.Url = test_url;
            driver.Navigate().GoToUrl("https://stefanrammo23.thkit.ee/");

            try { IWebElement sButton2 = driver.FindElement(By.XPath("//*[@class=\"menu-item-150\"]")); sButton2.Click(); } catch (Exception) { }
            Thread.Sleep(2500);

            var sText = driver.FindElements(By.XPath("//*[@id=\"wpforms-7-field_0\"]"));
            for (int i = 0; i < sText.Count; i++)
            {
                try { sText[i].Click(); sText[i].SendKeys("Stefan Rammo"); } catch (Exception) { }
            }
            Thread.Sleep(2500);
            var sTextArea = driver.FindElements(By.XPath("//*[@id=\"wpforms-7-field_1\"]"));
            for (int i = 0; i < sTextArea.Count; i++)
            {
                try { sTextArea[i].Click(); sTextArea[i].SendKeys("stefanrammo@email.co.uk"); } catch (Exception) { }
            }
            Thread.Sleep(2500);
            var sTextArea1 = driver.FindElements(By.XPath("//*[@id=\"wpforms-7-field_2\"]"));
            for (int i = 0; i < sTextArea1.Count; i++)
            {
                try { sTextArea1[i].Click(); sTextArea1[i].SendKeys("This is a Selenium test"); } catch (Exception) { }
            }
            Thread.Sleep(2500);
            try { IWebElement sButton2 = driver.FindElement(By.XPath("//*[@id=\"wpforms-submit-7\"]")); sButton2.Click(); } catch (Exception) { }
            Thread.Sleep(2500);
        }

        [TearDownAttribute]
        public void TearDownAttribute()
        {
            driver.Dispose();
        }
    }
}
