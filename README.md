# Console Selenium 41

Atividade da disciplina Gestão e Qualidade de Software, desenvolvida com C#, .NET 10, MSTest e Selenium WebDriver.

O projeto automatiza o formulário oficial de demonstração do Selenium:

https://www.selenium.dev/selenium/web/web-form.html

## Estrutura da solução

```text
ConsoleSelenium41.sln
├── ConsoleSelenium
│   ├── Program.cs
│   └── WebFormTestData.cs
└── ConsoleSelenium.Tests
    ├── Infrastructure
    │   └── ChromeDriverFactory.cs
    ├── Pages
    │   └── WebFormPage.cs
    └── WebFormularioDesafioTest.cs
```

## Cenários automatizados

1. Cadastro completo
   - Preenchimento de nome, senha e textarea.
   - Validação do campo somente leitura.
   - Envio do formulário e validação da mensagem `Received!`.

2. Dropdown e datalist
   - Seleção da opção `Two` com `SelectElement`.
   - Validação do valor `2`.
   - Preenchimento do datalist com `Seattle`.
   - Envio e validação do formulário.

3. Checkbox, radio e seletor de cor
   - Validação do primeiro checkbox marcado por padrão.
   - Marcação do segundo checkbox.
   - Seleção do segundo radio.
   - Alteração do color picker.
   - Envio e validação da mensagem de sucesso.

## Tecnologias utilizadas

- .NET 10
- C#
- MSTest 4
- Selenium WebDriver 4
- Selenium Support 4
- Google Chrome

## Como executar

Na pasta raiz do repositório, execute:

```powershell
dotnet restore
dotnet build --configuration Release
dotnet test --configuration Release
```

Os testes utilizam o Google Chrome em modo headless. O Selenium Manager localiza ou instala automaticamente o driver compatível com a versão do navegador.

## Resultado da validação

```text
Total de testes: 3
Aprovados: 3
Falhas: 0
```

Desenvolvido por Gustavo Alves.
