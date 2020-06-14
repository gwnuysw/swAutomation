using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace csharpStudy
{
    class Program
    {
        private IWebDriver driver;
        IWebElement ele = null;
        IReadOnlyList<IWebElement> eles;
        static void Main(string[] args)
        {
            Program csharpPath = new Program();
            //csharpPath.acmeLogin();
            csharpPath.naverDataScrap();
        }
        
        void naverDataScrap()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.naver.com/");
            driver.Manage().Window.Maximize();
            
            ele = driver.FindElement(By.LinkText("증권"));
            ele.Click();

            ele = driver.FindElement(By.LinkText("시장지표"));
            ele.Click();

            ele = driver.FindElement(By.Id("frame_ex1"));
            driver.SwitchTo().Frame(ele);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            eles = wait.Until(e => e.FindElements(By.CssSelector("td.tit")));

            foreach(IWebElement item in eles)
            {
                Console.WriteLine(item.Text);
            }            
        }
        void acmeLogin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://acme-test.uipath.com/account/login");
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            ele = driver.FindElement(By.CssSelector("h1.page-header"));

            ele.SendKeys("swlee1014@gmail.com");
            ele = driver.FindElement(By.CssSelector("input#password.form-control"));
            ele.SendKeys("1q2w3e!23");
            ele = driver.FindElement(By.Id("buttonLogin"));

            ele.Click();
        }
    }
}
