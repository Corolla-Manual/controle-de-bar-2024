using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloMesa;
using System.Text;

namespace ControleDeBar.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        #region Processo de configura��o de servi�os e depend�ncia da aplica��o
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        #endregion

        WebApplication app = builder.Build();

        // Rota Coringa
        app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id:int?}");

        app.Run();
    }
}
