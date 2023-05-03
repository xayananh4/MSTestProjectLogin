using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testProjectLogin;

[TestClass]
public class UnitTest1
{
    static IWebDriver driver = null;

    [TestMethod]
    public void test1()
    {
        Console.WriteLine("TestExcution Start");
        driver.Navigate().GoToUrl("https://www.tutorialspoint.com/selenium/selenium_automation_practice.htm");
        Console.WriteLine("Url is opened");
        String txt_title = driver.Title.ToString();
        bool titleIsEqual = txt_title.Equals("Selenium - Automation Practice Form");
        Assert.IsTrue(titleIsEqual);
        Console.WriteLine("Test has finished. Website is Up.");
    }

    //public void test1()
    //{
    //    Console.WriteLine("testExcution Start");
    //    driver.Navigate().GoToUrl("https://demosite.executeautomation.com");
    //    Console.WriteLine("url is opened");
    //    String txt_title = driver.Title.ToString();
    //    bool titleIsEqual = txt_title.Equals("Execute Automation");
    //    Assert.IsTrue(titleIsEqual);
    //    Console.WriteLine("test has finished.  Website is up.");
    //}

    //[TestMethod]
    //public void test2()
    //{
    //    Console.WriteLine("login test started");
    //    By userName = By.CssSelector("#userName > p:nth-child(1) > input[type=text]");
    //    By passWord = By.CssSelector("#userName > p:nth-child(2) > input[type=text]");


    //    var username = driver.FindElement(userName);


    //    if (username != null)
    //    {
    //        Console.WriteLine("the field username exist");
    //        username.SendKeys("helloworld");
    //        Console.WriteLine("keys sent - username: helloworld");
    //    }
    //    else
    //    {
    //        Console.WriteLine("login element not found");

    //    }
    //    var password = driver.FindElement(passWord);
    //    if (password != null)
    //    {
    //        Console.WriteLine("the field passwors exist");
    //        password.SendKeys("helloworld");
    //        Console.WriteLine("keys sent - password: helloworld");
    //    }
    //    else
    //    {
    //        Console.WriteLine("password element not found");

    //    }
    //    By btnLogin = By.CssSelector("#user9Name > p:nth-child(3) > input[type=submit]");
    //    var btn_login = driver.FindElement(btnLogin);
    //    if (btn_login != null)
    //    {
    //        Console.WriteLine("the login button exist");
    //        btn_login.Click();
    //    }
    //    else
    //    {
    //        Console.WriteLine("login button element not found");

    //    }
    //    By formTitle = By.CssSelector("#details > h2");
    //    var form_title = driver.FindElement(formTitle);
    //    if (form_title != null)
    //    {
    //        Console.WriteLine("the form title button exist");

    //    }
    //    else
    //    {
    //        Console.WriteLine("form title element not found");

    //    }
    //    Console.WriteLine("test is finished");
    //}

    //[TestMethod]
    //public void test2()
    //{
    //    Console.WriteLine("Login test started");

    //    //var username = driver.FindElement(userName);
    //    sendKeys("#userName > p:nth-child(1) > input[type=text]", "helloworld");
    //    sendKeys("#userName > p:nth-child(2) > input[type=text]", "helloworld");
    //    clickElement("#userName > p:nth-child(3) > input[type=submit]");

    //    By formTitle = By.CssSelector("#details > h2");

    //    var form_title = driver.FindElement(formTitle);
    //    if (form_title != null)
    //    {
    //        Console.WriteLine("The form title element exist");

    //    }
    //    else
    //    {
    //        Console.WriteLine("Form title element not found");

    //    }
    //    Console.WriteLine("Test is finished");
    //}

    public static IWebElement clickElement(string selector)
    {
        By elementSelector = By.CssSelector(selector);
        var element = driver.FindElement(elementSelector);
        if (element != null)
        {
            Console.WriteLine("element exist");
            element.Click();
            return element;
        }
        else
        {
            Console.WriteLine("element not found");
            throw new InvalidOperationException("element is not exist");

        }
    }

    public static IWebElement sendKeys(string selector, string keys)
    {
        By elementSelector = By.CssSelector(selector);
        var element = driver.FindElement(elementSelector);
        if (element != null)
        {
            Console.WriteLine("Element exist");
            element.Clear();

            element.SendKeys(keys);
            return element;
        }
        else
        {
            Console.WriteLine("Element not found");
            throw new InvalidOperationException("element is not exist");
        }
    }

    // Means initialize once; Entry point where test is ran, only happens once
    [ClassInitialize]
    public static void ClassInitialize(TestContext testContext)
    {
        driver = new ChromeDriver();
        if(driver != null) {
            Console.WriteLine("WebDriver is not null");

        }
        else
        {
            Console.WriteLine("WebDriver is not initialize");
            throw new InvalidOperationException("webDriver is not initialize");
        }
        Console.WriteLine("driverInitialize");
    }

    [ClassCleanup]
    public static void ClassCleanup()
    {
        driver.Quit();
        driver.Close();
        Console.WriteLine("classCleanUp");
    }
}

