using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infra.Orm.Compartilhada;

namespace ControleDeBar.Infra.Orm.ModuloGarcom
{
    public class RepositorioGarcomEmOrm : IRepositorioGarcom
    {
        ControleDeBarDbContext dbContext;

        public RepositorioGarcomEmOrm(ControleDeBarDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Cadastrar(Garcom novoGarçom)
        {
            dbContext.Garçoms.Add(novoGarçom);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Garcom garçomEditado)
        {
            Garcom garçom = dbContext.Garçoms.Find(id)!;

            if (garçom == null)
                return false;

            garçom.AtualizarRegistro(garçomEditado);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Garcom garçom = dbContext.Garçoms.Find(id)!;

            if (garçom == null)
                return false;

            dbContext.Garçoms.Remove(garçom);
            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int idSelecionado)
        {
            return dbContext.Garçoms.Find(idSelecionado)!;
        }

        public List<Garcom> SelecionarTodos()
        {
            return dbContext.Garçoms.ToList();
        }
    }
}
