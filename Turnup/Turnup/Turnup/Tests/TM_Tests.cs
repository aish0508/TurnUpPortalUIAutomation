using Login.Pages;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnup.Utilis;
using NUnit.Framework;

namespace Turnup.Tests
{
    //[Parallelizable]
    [TestFixture]
    public class TM_Tests : CommonDriver
    {

        LoginPage loginPageObj = new LoginPage();
        HomePage HomePageObj = new HomePage();
        TMPage TMPageObj = new TMPage();
        [SetUp]
        public void TimeSetup()
        {

            IWebDriver dr = new ChromeDriver();
            //Login page object initialization and deifinition
            loginPageObj.LoginActions(dr);

            // Home page object initialization and deifinition

            HomePageObj.GoToTMPage(dr);
        }

            [Test, Order(1), Description("This test is creating a new Time record")]
            public void CreateTime_Test()
            {
                // TM Page object initialization and definition

                TMPageObj.CreateNewTime(dr);

            }
            [Test, Order(2), Description("This test is creating a new Time record")]
            public void EditTime_Test()
            {
                TMPageObj.EditTMPage(dr);
            }
            [Test, Order(3), Description("This test is deleting an existing Time record")]
            public void DeleteTime_Test()
            {
                TMPageObj.DeleteTMPage(dr);
            }

            [TearDown]
            public void CloseTestRun()
            {
                dr.Quit();
            }

        }
    }

