using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp.Utilis;

namespace Login.Pages
{
    public class LoginPage
    {
        public void LoginActions(IWebDriver dr)
        {
            dr.Manage().Window.Maximize();
            dr.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(5000);
            Wait.WaitToExist(dr, "Id", "UserName", 8);
            IWebElement Username = dr.FindElement(By.Id("UserName"));
            Username.SendKeys("hari");
            IWebElement Password = dr.FindElement(By.Id("Password"));
            Password.SendKeys("123123");
            IWebElement Login = dr.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            IWebElement helloHari = dr.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
        }
    }
}
