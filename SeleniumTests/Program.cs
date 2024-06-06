using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class Program
    {
        static void Main(string[] args)
        {
            

            IWebDriver driver = null;
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--log-level=3"); 
            driver = new ChromeDriver(options);

            // URL of the running ASP.NET Core application
            string url = "http://localhost:5166";

            try
            {
                
                // Navigate to the web application
                Console.WriteLine($"Navigating to {url}");
                driver.Navigate().GoToUrl(url);

                // Run all tests
                TestPageLoad(driver);
                TestFormSubmission(driver, "Akshay Daberao", "akshay@example.com", "123-456-7890", true);
                TestFormSubmission(driver, "Paul Wright", "paul@example.com", "098-765-4321", false);
                TestFormSubmissionWithoutOptionalFields(driver, "Leo Messi", "messi@example.com");
                TestDelayedWelcomeMessage(driver, "Delayed User", "delayed.user@example.com", "111-222-3333");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Clean up
                driver?.Quit();
            }
        }

        static void TestPageLoad(IWebDriver driver)
        {
            try
            {
                Console.WriteLine("Test 1: Verifying that the web page loads successfully...");
                string expectedTitle = "SimpleWebApp"; 
                if (!driver.Title.Contains(expectedTitle))
                {
                    Console.WriteLine("Test 1 Failed: Web page did not load successfully.");
                    return;
                }
                Console.WriteLine("Test 1 Passed: Web page loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test 1 Failed: An error occurred - " + ex.Message);
            }
        }

        static void TestFormSubmission(IWebDriver driver, string name, string email, string phone, bool checkWelcomeMessage)
        {
            try
            {
                Console.WriteLine($"Test 2: Filling out the form with name: {name}, email: {email}, phone: {phone}...");
                driver.Navigate().GoToUrl("http://localhost:5166");
                driver.FindElement(By.Id("name")).SendKeys(name);
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.Id("phone")).SendKeys(phone);
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                if (checkWelcomeMessage)
                {
                    Console.WriteLine("Waiting for the welcome message...");
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    IWebElement welcomeMessage = wait.Until(drv => drv.FindElement(By.TagName("h2")));

                    Console.WriteLine("Test 3: Checking the welcome message...");
                    if (welcomeMessage.Text != $"Welcome, {name}!")
                    {
                        Console.WriteLine("Test 3 Failed: Welcome message is incorrect.");
                        return;
                    }
                    Console.WriteLine("Test 3 Passed: Welcome message is correct.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test 2 or Test 3 Failed: An error occurred - " + ex.Message);
            }
        }

        static void TestFormSubmissionWithoutOptionalFields(IWebDriver driver, string name, string email)
        {
            try
            {
                Console.WriteLine($"Test 4: Submitting the form without entering optional fields with name: {name}, email: {email}...");
                driver.Navigate().GoToUrl("http://localhost:5166");
                driver.FindElement(By.Id("name")).SendKeys(name);
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                // Wait for the welcome message to be displayed
                Console.WriteLine("Waiting for the welcome message...");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement welcomeMessage = wait.Until(drv => drv.FindElement(By.TagName("h2")));

                Console.WriteLine("Test 4 Passed: Welcome message is displayed without optional fields.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test 4 Failed: An error occurred - Incomplete fields" + ex.Message);
            }
        }

        static void TestDelayedWelcomeMessage(IWebDriver driver, string name, string email, string phone)
        {
            try
            {
                Console.WriteLine($"Test 5: Submitting form with a delay for name: {name}, email: {email}, phone: {phone}...");
                driver.Navigate().GoToUrl("http://localhost:5166");
                driver.FindElement(By.Id("name")).SendKeys(name);
                driver.FindElement(By.Id("email")).SendKeys(email);
                driver.FindElement(By.Id("phone")).SendKeys(phone);
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                // Simulate delay (if applicable) and wait for the welcome message
                Console.WriteLine("Simulating delay and waiting for the welcome message...");
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
                IWebElement welcomeMessage = wait.Until(drv => drv.FindElement(By.TagName("h2")));

                Console.WriteLine("Checking the delayed welcome message...");
                if (welcomeMessage.Text != $"Welcome, {name}!")
                {
                    Console.WriteLine("Test 5 Failed: Welcome message is incorrect.");
                    return;
                }
                Console.WriteLine("Test 5 Passed: Welcome message is correct after delay.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test 5 Failed: An error occurred - " + ex.Message);
            }
        }
    }
}
