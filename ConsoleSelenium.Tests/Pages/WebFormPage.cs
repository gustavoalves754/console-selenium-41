using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ConsoleSelenium.Tests.Pages;

internal sealed class WebFormPage(IWebDriver driver)
{
    private readonly WebDriverWait _wait = new(driver, TimeSpan.FromSeconds(10));

    private IWebElement TextInput => driver.FindElement(By.Name("my-text"));
    private IWebElement PasswordInput => driver.FindElement(By.Name("my-password"));
    private IWebElement Textarea => driver.FindElement(By.Name("my-textarea"));
    private IWebElement ReadonlyInput => driver.FindElement(By.Name("my-readonly"));
    private IWebElement SelectInput => driver.FindElement(By.Name("my-select"));
    private IWebElement DatalistInput => driver.FindElement(By.Name("my-datalist"));
    private IWebElement CheckboxUm => driver.FindElement(By.Id("my-check-1"));
    private IWebElement CheckboxDois => driver.FindElement(By.Id("my-check-2"));
    private IWebElement RadioDois => driver.FindElement(By.Id("my-radio-2"));
    private IWebElement ColorPicker => driver.FindElement(By.Name("my-colors"));
    private IWebElement SubmitButton => driver.FindElement(By.CssSelector("button[type='submit']"));

    public void Open(string url)
    {
        driver.Navigate().GoToUrl(url);
        _wait.Until(currentDriver =>
            currentDriver.FindElement(By.TagName("h1")).Text == "Web form");
    }

    public void FillRegistration(string name, string password, string experience)
    {
        TextInput.SendKeys(name);
        PasswordInput.SendKeys(password);
        Textarea.SendKeys(experience);
    }

    public string GetReadonlyValue() => ReadonlyInput.GetAttribute("value") ?? string.Empty;

    public void SelectDropdownByText(string text)
    {
        SelectElement select = new(SelectInput);
        select.SelectByText(text);
    }

    public string GetSelectedDropdownValue()
    {
        SelectElement select = new(SelectInput);
        return select.SelectedOption.GetAttribute("value") ?? string.Empty;
    }

    public void FillDatalist(string city) => DatalistInput.SendKeys(city);

    public bool IsFirstCheckboxSelected() => CheckboxUm.Selected;

    public void SelectSecondCheckbox()
    {
        if (!CheckboxDois.Selected)
        {
            CheckboxDois.Click();
        }
    }

    public bool IsSecondCheckboxSelected() => CheckboxDois.Selected;

    public void SelectSecondRadio()
    {
        if (!RadioDois.Selected)
        {
            RadioDois.Click();
        }
    }

    public bool IsSecondRadioSelected() => RadioDois.Selected;

    public void SetColor(string hexadecimalColor)
    {
        IJavaScriptExecutor javaScript = (IJavaScriptExecutor)driver;
        javaScript.ExecuteScript(
            "arguments[0].value = arguments[1]; arguments[0].dispatchEvent(new Event('change', { bubbles: true }));",
            ColorPicker,
            hexadecimalColor);
    }

    public string GetColorValue() => ColorPicker.GetAttribute("value") ?? string.Empty;

    public void Submit() => SubmitButton.Click();

    public string GetSuccessMessage()
    {
        IWebElement message = _wait.Until(currentDriver =>
            currentDriver.FindElement(By.Id("message")));
        return message.Text;
    }
}

