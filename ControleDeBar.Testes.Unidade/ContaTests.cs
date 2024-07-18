using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Testes.Unidade
{
    // unidade
    [TestClass] // atributos
    public class ContaTests
    {
        [TestMethod]
        public void Deve_Validar_Conta_Corretamente()
        {
            // AAA - Triple A

            // Arrange (preparação do teste)
            Conta contaInvalida = new Conta(null, null);

            List<string> errosEsperados =
            [
                "O campo \"mesa\" é obrigatório",
                "O campo \"garcom\" é obrigatório"
            ];

            // Act (ação do teste)
            List<string> erros = contaInvalida.Validar();

            // Assert (asserção do teste)
            CollectionAssert.AreEqual(errosEsperados, erros);

        }

        [TestMethod]
        public void Conta_Foi_Concluida_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa(01); 
            Garcom garcom = new Garcom("Pedrinho Testes", "111.111.111-05");

            // Act
            Conta contaAberta = new Conta(mesa, garcom);

            // Assert
            Assert.IsFalse(contaAberta.Concluida);
            Assert.IsFalse(contaAberta.Mesa.Ocupada);
        }

        [TestMethod]
        public void Deve_Calcular_Total_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa(01);
            Garcom garcom = new Garcom("Junin Testes", "111.222.333-04");

            Conta novaConta = new Conta(mesa, garcom);

            Produto produto = new Produto("água", 2.50);
            Produto produto2 = new Produto("coca", 3.50);

            // Act

            novaConta.CalcularValorTotal();
            double total = novaConta.ValorTotal;

            // Assert
            double totalEsperado = 6;

            Assert.AreEqual(totalEsperado, total);

        }
    }
}