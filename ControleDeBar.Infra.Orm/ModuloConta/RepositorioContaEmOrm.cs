using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Infra.Orm.Compartilhada;

namespace ControleDeBar.Infra.Orm.ModuloConta
{
    public class RepositorioContaEmOrm : IRepositorioConta
    {
        ControleDeBarDbContext dbContext;

        public RepositorioContaEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Cadastrar(Conta novaConta)
        {
            dbContext.Contas.Add(novaConta);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Conta contaEditada)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null)
                return false;

            conta.AtualizarRegistro(contaEditada);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Conta conta = dbContext.Contas.Find(id)!;

            if (conta == null)
                return false;

            dbContext.Contas.Remove(conta);
            dbContext.SaveChanges();

            return true;
        }

        public Conta SelecionarPorId(int idSelecionado)
        {
            return dbContext.Contas.Find(idSelecionado);
        }

        public List<Conta> SelecionarTodos()
        {
            return dbContext.Contas.ToList();
        }
    }
}
