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

        public void Cadastrar(Garcom novoGarcom)
        {
            dbContext.Garcoms.Add(novoGarcom);
            dbContext.SaveChanges();
        }

        public bool Editar(int id, Garcom garcomEditado)
        {
            Garcom garcom = dbContext.Garcoms.Find(id)!;

            if (garcom == null)
                return false;

            garcom.AtualizarRegistro(garcomEditado);
            dbContext.SaveChanges();

            return true;
        }

        public bool Excluir(int id)
        {
            Garcom garcom = dbContext.Garcoms.Find(id)!;

            if (garcom == null)
                return false;

            dbContext.Garcoms.Remove(garcom);
            dbContext.SaveChanges();

            return true;
        }

        public Garcom SelecionarPorId(int idSelecionado)
        {
            return dbContext.Garcoms.Find(idSelecionado)!;
        }

        public List<Garcom> SelecionarTodos()
        {
            return dbContext.Garcoms.ToList();
        }
    }
}
