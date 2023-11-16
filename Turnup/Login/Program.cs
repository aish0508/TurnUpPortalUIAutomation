using Login.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Chrome;

IWebDriver dr = new ChromeDriver();

LoginPage loginPageObj = new LoginPage();
loginPageObj.LoginActions(dr);
HomePage HomePageObj= new HomePage();
HomePageObj.GoToTMPage(dr);
TMPage TMPageObj = new TMPage();
TMPageObj.CreateNewTime(dr);
TMPageObj.EditTMPage(dr);
TMPageObj.DeleteTMPage(dr);








