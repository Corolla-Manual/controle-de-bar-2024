using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloMesa;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    [HttpGet, ActionName("listar")]
    public ViewResult ListarMesas()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        ViewBag.Mesa = mesas;

        return View("listar-mesas");
    }

    [HttpGet, ActionName("inserir")]
    public Task ExibirFormularioInserirMesa()
    {
        // HTML
        string form = System.IO.File.ReadAllText("Html/inserir-mesa-form.html");

        return HttpContext.Response.WriteAsync(form);
    }

    [HttpPost, ActionName("inserir")]
    public Task InserirMesa(Mesa novaMesa) // data bindind
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        repositorioMesa.Cadastrar(novaMesa);

        HttpContext.Response.StatusCode = 201;

        string html = System.IO.File.ReadAllText("Html/mensagens-mesa.html");

        html = html.Replace("#mensagem#", $"A mesa \"{novaMesa.Id}\" foi cadastrada com sucesso!");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpGet, ActionName("editar")]
    public Task ExibirFormularioEditarMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/editar-mesa-form.html");

        html = html.Replace("#id#", mesa.Id.ToString());

        html = html.Replace("numero", mesa.NumeroMesa.ToString());

        if (mesa.Ocupada)
            html = html.Replace("<input name=\"ocupada\" type=\"checkbox\" />", "<input name=\"ocupada\"> ");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpPost, ActionName("editar")]
    public Task EditarMesa(int id, Mesa mesaAtualizada)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

        mesaAtualizada.Ocupada = HttpContext.Request.Form["ocupada"] == "on";

        repositorioMesa.Editar(mesaOriginal.Id, mesaOriginal);

        string html = System.IO.File.ReadAllText("html/mensagens-mesa.html");

        html = html.Replace("#mensagem#", $"A mesa id \"{mesaOriginal.Id}\" foi editada com sucesso!");

        return HttpContext.Response.WriteAsync(html);
    }

    [HttpGet, ActionName("excluir")]
    public Task ExibirFormularioExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/excluir-mesa-form.html");

        StringBuilder sb = new StringBuilder(html);

        sb.Replace("#numeromesa#", mesa.NumeroMesa.ToString());

        sb.Replace("#id#", mesa.Id.ToString());

        return HttpContext.Response.WriteAsync(sb.ToString());
    }

    [HttpPost, ActionName("excluir")]
    public Task ExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        repositorioMesa.Excluir(mesa.Id);

        HttpContext.Response.StatusCode = 200;

        string html = System.IO.File.ReadAllText("Html/mensagens-mesa.html");

        StringBuilder sb = new StringBuilder();

        sb.Replace("#mensagem#", $"A mesa id \"{mesa.Id}\" foi excluida com sucesso!");

        return HttpContext.Response.WriteAsync(sb.ToString());
    }

    [HttpGet, ActionName("detalhes")]
    public Task ExibirPaginasDetalhesMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        string html = System.IO.File.ReadAllText("Html/detalhes-mesa.html");

        StringBuilder detalhes = new StringBuilder();

        detalhes.AppendLine("#id#" + mesa.Id.ToString());
        detalhes.AppendLine("#numero#" + mesa.ToString());
        detalhes.AppendLine("#status#" + (mesa.Ocupada ? "Ocupada" : "Livre"));

        detalhes.AppendLine();

        if (mesa.Contas.Count > 0)
        {
            foreach (Conta c in mesa.Contas)
                detalhes.Replace("#conta#", $"<li>{c.ToString()}</li> #conta#");

            detalhes.Replace("#conta", "");
        }

        return HttpContext.Response.WriteAsync(detalhes.ToString());
    }


}
