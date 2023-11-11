using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Chrome;

IWebDriver dr = new FirefoxDriver();

dr.Manage().Window.Maximize();
dr.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
 IWebElement Username=dr.FindElement(By.Id("UserName"));
Username.SendKeys("hari");
IWebElement Password = dr.FindElement(By.Id("Password"));
Password.SendKeys("123123");
IWebElement Login = dr.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
IWebElement helloHari = dr.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if(helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User is logged in successfully");
}
else
{
    Console.WriteLine("User is not logged in");
}
