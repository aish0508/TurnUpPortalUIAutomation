using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUp.Utilis;
using NUnit;
using NUnit.Framework;


namespace Login.Pages
{
   public class TMPage
    {
        public void CreateNewTime(IWebDriver dr)
        {

            Wait.WaitToBeClickable(dr, "XPath", "//*[@id=\"container\"]/p/a", 5);
            // Click on create new button
            IWebElement createNewButton = dr.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            // Select "Time" from typecode dropdown
            Thread.Sleep(1000);
            IWebElement typeCodeDropdown = dr.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            Thread.Sleep(1000);
            IWebElement timeOption = dr.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();
            IWebElement Code = dr.FindElement(By.Id("Code"));
            Code.SendKeys("123");
            IWebElement description = dr.FindElement(By.Id("Description"));
            description.SendKeys("Test");
            IWebElement priceperunit = dr.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceperunit.SendKeys("34");
            Thread.Sleep(1000);
            //Save time record
            IWebElement SaveButton = dr.FindElement(By.CssSelector("[Value='Save']"));
            SaveButton.Click();
            Thread.Sleep(8000);
            // Check if new record has been created successfully
            try
            {
                IWebElement goToLastPage = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Go to last page button hasn't been found.", ex.Message);
            }

         }

        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;
        }

        public void EditTMPage(IWebDriver dr, string code, string description , string price)
        {
            Thread.Sleep(8000);
            IWebElement Edit = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            Edit.Click();
            Thread.Sleep(1000);
            //edit code
            IWebElement editCodeTextbox = dr.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("Test");
            //Edit discription in discription text box
            IWebElement editDescriptionTextbox = dr.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Test Description");
            //Edit price per unit in price per unit textbox

            IWebElement editPriceTextbox = dr.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            //editPriceTextbox.Clear();
            editPriceTextbox.SendKeys(price);
            //save button
            IWebElement Button = dr.FindElement(By.Id("SaveButton"));
            Button.Click();
            
        }
        public void DeleteTMPage(IWebDriver dr)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButtonEdit = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButtonEdit.Click();
            Thread.Sleep(8000);
            IWebElement editedRecord = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (editedRecord.Text == "Test")
            {
                Thread.Sleep(3000);
                IWebElement deleteButton = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
               deleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted has not been found.");
            }
            Thread.Sleep(4000);
            
            dr.SwitchTo().Alert().Accept();

            Thread.Sleep(2000);

            IWebElement deletedCode = dr.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(deletedCode.Text != "Test", "Record has not been deleted.");


        }
    }
}
