using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;

namespace Selenium1
{

    [TestClass]
    public class HomepageFeatures
    {
        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
            var outputDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var Login_button = By.Id("login-button");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(Login_button));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var userPasswordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(Login_button);
            userNameField.SendKeys("standard_user");
            userPasswordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));

        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
