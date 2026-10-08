using CalculadoraDescontos.App;
using Xunit;

namespace CalculadoraDescontos.Tests;


public class DescontoServiceTests
{
    private readonly DescontoService _descontoService = new();

    [Theory]
    [InlineData(2, "BRONZE")]  
    [InlineData(7, "PRATA")]    
    [InlineData(15, "OURO")]    
    public void ObterCategoriaCliente_DeveRetornarCategoriaCorreta(int totalCompras, string categoriaEsperada)
    {
        var resultado = _descontoService.ObterCategoriaCliente(totalCompras);

        Assert.Equal(categoriaEsperada, resultado);
    }

    [Theory]
    [InlineData(100, 10, 90)]   
    [InlineData(200, 20, 160)]  
    [InlineData(50, 0, 50)]     
    public void CalcularDescontoPorPercentual_DeveAplicarDescontoCorretamente(int valorOriginal, int percentualDesconto, int valorFinalEsperado)
    {
        var resultado = _descontoService.CalcularDescontoPorPercentual(valorOriginal, percentualDesconto);

        Assert.Equal(valorFinalEsperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]   
    [InlineData(16, true, true)]    
    [InlineData(17, false, false)]  
    public void EValidoParaCupom_DeveValidarElegibilidadeCorretamente(int idade, bool primeiraCompra, bool resultadoEsperado)
    {
        var resultado = _descontoService.EValidoParaCupom(idade, primeiraCompra);

        Assert.Equal(resultadoEsperado, resultado);
    }
}
