using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

public class FluxoCompletoTests : SeleniumTestBase, IDisposable
{
    private string email;
    private string senha;

    public FluxoCompletoTests()
    {
        email = $"usuario{Guid.NewGuid()}@example.com";
        senha = "senhaSegura123";
    }

    [Fact]
    public void DeveSimularFluxoCompleto()
    {
        try
        {
            DeveRealizarCadastroCompleto();
            DeveRealizarLogin();
            DeveEditarPerfil();
            DeveValidarDadosPerfil();
        }
        finally
        {
            EncerrarTeste();
        }
    }

    public void DeveRealizarCadastroCompleto()
    {
        Driver.Navigate().GoToUrl("http://localhost:5173/registration");

        Driver.FindElement(By.Id("nomeCompleto")).SendKeys("João da Silva");
        Driver.FindElement(By.Id("cpf")).SendKeys("12345678901");
        Driver.FindElement(By.Id("apelido")).SendKeys("João");
        new SelectElement(Driver.FindElement(By.Id("genero"))).SelectByText("Masculino");
        Driver.FindElement(By.Id("email")).SendKeys(email);
        Driver.FindElement(By.Id("senha")).SendKeys(senha);
        Driver.FindElement(By.Id("data")).SendKeys("01/01/2000");
        Driver.FindElement(By.Id("telefone")).SendKeys("11999999999");

        Driver.FindElement(By.Id("btnNext")).Click();

        Driver.FindElement(By.Name("rua")).SendKeys("Rua Exemplo");
        Driver.FindElement(By.Name("bairro")).SendKeys("Centro");
        Driver.FindElement(By.Name("complemento")).SendKeys("Apartamento 101");
        Driver.FindElement(By.Name("cidade")).SendKeys("São Paulo");
        Driver.FindElement(By.Name("cep")).SendKeys("01001000");
        Driver.FindElement(By.Name("numeroResidencia")).SendKeys("123");

        Driver.FindElement(By.Id("btnSalvar")).Click();

        Thread.Sleep(2000);
    }

    public void DeveRealizarLogin()
    {
        Driver.Navigate().GoToUrl("http://localhost:5173/login");

        Driver.FindElement(By.Id("userEmail")).SendKeys(email);
        Driver.FindElement(By.Id("userSenha")).SendKeys(senha);
        Driver.FindElement(By.Id("btnLogin")).Click();

        Thread.Sleep(5000);
    }

    public void DeveEditarPerfil()
    {
        Driver.FindElement(By.Id("btnPerfil")).Click();

        Thread.Sleep(2000);

        Driver.FindElement(By.Id("btnEditarPerfil")).Click();

        Thread.Sleep(1000);

        IWebElement campoNome = Driver.FindElement(By.Id("nomeCompletoEditar"));
        campoNome.Clear();
        campoNome.SendKeys("João Silva Editado");

        IWebElement campoEmail = Driver.FindElement(By.Id("emailEditar"));
        campoEmail.Clear();
        campoEmail.SendKeys("joãozito@gmail.com");

        Driver.FindElement(By.Id("btnSalvarPerfil")).Click();

        Thread.Sleep(2000);
    }

    public void DeveValidarDadosPerfil()
    {
        IWebElement nomeAtualizado = Driver.FindElement(By.Id("nomeCompleto"));
        IWebElement emailAtualizado = Driver.FindElement(By.Id("dadoEmail"));

        Assert.Equal("João Silva Editado", nomeAtualizado.Text);
        Assert.Equal("joãozito@gmail.com", emailAtualizado.Text);
    }

    public void EncerrarTeste()
    {
        if (Driver != null)
        {
            Driver.Quit();
        }
    }

    public void Dispose()
    {
        EncerrarTeste();
    }
}
