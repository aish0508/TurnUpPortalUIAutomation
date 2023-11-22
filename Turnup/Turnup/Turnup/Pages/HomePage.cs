using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp.Utilis;

namespace Login.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver dr)
        {
            Thread.Sleep(4000);
            IWebElement administration = dr.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administration.Click();
            Wait.WaitToBeClickable(dr, "XPath","//*/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);
            IWebElement TM = dr.FindElement(By.XPath("//*/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TM.Click();
        }
    }
}
