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
            IWebElement administration = dr.FindElement(By.XPath("//*/div[3]/div/div/ul/li[5]/a/text()"));
            administration.Click();
            Wait.WaitForElement(dr, "//*/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);
            IWebElement TM = dr.FindElement(By.XPath("//*/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            TM.Click();
        }
    }
}
