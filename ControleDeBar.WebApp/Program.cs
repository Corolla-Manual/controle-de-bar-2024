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
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();

        // Rota Coringa
        app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id:int?}");

        app.Run();
    }
}
