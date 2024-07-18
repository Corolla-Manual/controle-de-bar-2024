using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloMesa;

namespace ControleDeBar.Testes.Integracao
{
    [TestClass]
    [TestCategory("Testes de Integração de Mesa")]
    public class RepositorioMesaEmOrmTestes
    {
        RepositorioMesaEmOrm repositorioMesa = null;
        ControleDeBarDbContext dbContext = null;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new ControleDeBarDbContext();
            dbContext.Mesas.RemoveRange(dbContext.Mesas);

            repositorioMesa = new RepositorioMesaEmOrm(dbContext);
        }

        [TestMethod]
        public void Deve_Cadastrar_Mesa_Corretamente()
        {
            // Arrage
            Mesa novaMesa = new Mesa(01);

            dbContext = new ControleDeBarDbContext();
            repositorioMesa = new RepositorioMesaEmOrm(dbContext);

            // Act
            repositorioMesa.Cadastrar(novaMesa);

            // Assert
            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(novaMesa.Id);

            Assert.AreEqual(novaMesa, mesaSelecionada);
        }

        [TestMethod]
        public void Deve_Editar_Mesa_Corretamente()
        {
            // Arrage
            Mesa mesaOriginal = new Mesa(02);

            repositorioMesa.Cadastrar(mesaOriginal);

            Mesa mesaParaAtualizacao = repositorioMesa.SelecionarPorId(mesaOriginal.Id);

            // Act
            repositorioMesa.Editar(mesaOriginal.Id, mesaOriginal);

            // Assert

            Assert.AreEqual(mesaOriginal, mesaParaAtualizacao);

        }

        [TestMethod]
        public void Deve_Excluir_Mesa_Corretamente()
        {
            // Arrange
            Mesa mesa = new Mesa(01);

            repositorioMesa.Cadastrar(mesa);

            // Act
            repositorioMesa.Excluir(mesa.Id);

            // Assert
            Mesa mesaSelecionada = repositorioMesa.SelecionarPorId(mesa.Id);

            Assert.IsNull(mesaSelecionada);
        }

        [TestMethod]
        public void Deve_Selecionar_Mesa_Corretamente()
        {
            // Arrange
            List<Mesa> mesasParaCadastro =
            [
                new Mesa(01),
                new Mesa(02),
                new Mesa(03)
            ];

            foreach (Mesa mesa in mesasParaCadastro)
                repositorioMesa.Cadastrar(mesa);

            // Act
            List<Mesa> mesasSelecionadas = repositorioMesa.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(mesasParaCadastro, mesasSelecionadas);
        }
    }
}