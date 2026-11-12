using ConsoleSelenium.Tests.Infrastructure;
using ConsoleSelenium.Tests.Pages;
using OpenQA.Selenium;

namespace ConsoleSelenium.Tests;

[TestClass]
public sealed class WebFormularioDesafioTest
{
    private IWebDriver _driver = null!;
    private WebFormPage _form = null!;

    [TestInitialize]
    public void Initialize()
    {
        _driver = ChromeDriverFactory.Create();
        _form = new WebFormPage(_driver);
        _form.Open(WebFormTestData.Url);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    [TestMethod]
    public void CadastroCompleto_DevePreencherCamposEExibirMensagemDeSucesso()
    {
        _form.FillRegistration(
            WebFormTestData.NomeCompleto,
            WebFormTestData.SenhaDeTeste,
            WebFormTestData.ExperienciaAutomacao);

        Assert.AreEqual(
            WebFormTestData.ValorCampoSomenteLeitura,
            _form.GetReadonlyValue());

        _form.Submit();

        Assert.AreEqual(
            WebFormTestData.MensagemDeSucesso,
            _form.GetSuccessMessage());
    }

    [TestMethod]
    public void DropdownEDatalist_DevemSelecionarOpcaoEEnviarFormulario()
    {
        _form.SelectDropdownByText("Two");

        Assert.AreEqual("2", _form.GetSelectedDropdownValue());

        _form.FillDatalist(WebFormTestData.CidadeDatalist);
        _form.Submit();

        Assert.AreEqual(
            WebFormTestData.MensagemDeSucesso,
            _form.GetSuccessMessage());
    }

    [TestMethod]
    public void ElementosDeEscolhaECor_DevemAlterarEstadoEEnviarFormulario()
    {
        Assert.IsTrue(
            _form.IsFirstCheckboxSelected(),
            "O primeiro checkbox deveria estar marcado por padrão.");

        _form.SelectSecondCheckbox();
        Assert.IsTrue(_form.IsSecondCheckboxSelected());

        _form.SelectSecondRadio();
        Assert.IsTrue(_form.IsSecondRadioSelected());

        _form.SetColor(WebFormTestData.CorSelecionada);
        Assert.AreEqual(WebFormTestData.CorSelecionada, _form.GetColorValue());

        _form.Submit();

        Assert.AreEqual(
            WebFormTestData.MensagemDeSucesso,
            _form.GetSuccessMessage());
    }
}
