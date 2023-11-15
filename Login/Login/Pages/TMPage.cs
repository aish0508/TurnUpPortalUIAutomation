using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp.Utilis;

namespace Login.Pages
{
   public class TMPage
    {
        public void CreateNewTime(IWebDriver dr)
        {
            Wait.WaitToBeClickable(dr, "XPath", "//*[@id=\"container\"]/p/a", 5);
            IWebElement createNewButton = dr.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            IWebElement TypeCode = dr.FindElement(By.Id("TypeCode"));
            TypeCode.Click();
            IWebElement TypeCodeTextBox = dr.FindElement(By.Id("TypeCode_option_selected"));
            TypeCodeTextBox.Click();
            IWebElement Code = dr.FindElement(By.Id("Code"));
            Code.SendKeys("123");
            IWebElement description = dr.FindElement(By.Id("Description"));
            description.SendKeys("Test");
            IWebElement priceperunit = dr.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceperunit.SendKeys("34");
            IWebElement SaveButton = dr.FindElement(By.Id("SaveButton"));
            Thread.Sleep(4000);
            IWebElement arrow = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            arrow.Click();
            IWebElement newCode = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newCode.Text == "123")
            {
                Console.WriteLine("New record is created");
            }
            else
            {
                Console.WriteLine("New recored is not created");
            }
        }
        public void EditTMPage(IWebDriver dr)
        {
            Thread.Sleep(4000);
            IWebElement Edit = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[8]/td[5]/a[1]"));
            Edit.Click();
            IWebElement EditCode = dr.FindElement(By.Id("Code"));
            EditCode.SendKeys("Test");
            IWebElement D = dr.FindElement(By.Id("Description"));
            D.SendKeys("Test Description");
            IWebElement Button = dr.FindElement(By.Id("SaveButton"));
            Button.Click();
            Thread.Sleep(4000);
        }
        public void DeleteTMPage(IWebDriver dr)
        {
            IWebElement Delete = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[3]/td[5]/a[2]"));
            Delete.Click();
            // Switch the control of 'driver' to the Alert from main Window
            IAlert simpleAlert = dr.SwitchTo().Alert();

            // '.Text' is used to get the text from the Alert
            String alertText = simpleAlert.Text;
            Console.WriteLine("Alert text is " + alertText);

            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            simpleAlert.Accept();


        }
    }
}
