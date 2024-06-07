# Automated Web Testing with Selenium and .NET

It is a simple web application and  test scripts to automate testing of its functionalities.

## Installation


```bash
cd SeleniumTests
dotnet add package Selenium.WebDriver
dotnet add package Selenium.WebDriver.ChromeDriver
```

## Run

Open two different terminals

In one terminal -

```
cd SimpleWebApp
dotnet run
```

In other terminal -

```
cd SeleniumTests
dotnet run
```

## Tests
 
1. Verify that the web page loads successfully. 
2. Enter the name, email and phone in the input fields and submit the form. 
3. Do not enter the optional fields and submit the form. 
4. Verify that the welcome message is displayed correctly with the entered name. 
5. In some cases, the welcome message could be displayed after some background 
processing (simulate a delay of 3 seconds). The test script should wait for the welcome 
message to be displayed and then verify it.

## Output

```
Navigating to http://localhost:5166
Test 1: Verifying that the web page loads successfully...
Test 1 Passed: Web page loaded successfully.
Test 2: Filling out the form with name: Akshay Daberao, email: akshay@example.com, phone: 123-456-7890...
Waiting for the welcome message...
Test 3: Checking the welcome message...
Test 3 Passed: Welcome message is correct.
Test 2: Filling out the form with name: Paul Wright, email: paul@example.com, phone: 098-765-4321...
Test 4: Submitting the form without entering optional fields with name: Leo 
Messi, email: messi@example.com...
Waiting for the welcome message...
Test 4 Failed: An error occurred - Incomplete fieldsTimed out after 3 seconds
Test 5: Submitting form with a delay for name: Delayed User, email: delayed.user@example.com, phone: 111-222-3333...
Simulating delay and waiting for the welcome message...
Checking the delayed welcome message...
Test 5 Passed: Welcome message is correct after delay.
```

## Screenshots

![- SimpleWebApp and 1 more page - Personal - Microsoft​ Edge 06-06-2024 15_38_02](https://github.com/agdgithub/Automated-Web-Testing-with-Selenium-and-.NET/assets/98071875/cab71b5b-bab8-4240-8bce-6dd1ac46ba8a)

![skepsi - Visual Studio Code 06-06-2024 15_42_17](https://github.com/agdgithub/Automated-Web-Testing-with-Selenium-and-.NET/assets/98071875/0c180846-fbbf-47c5-8c95-1dad460d5fbd)

