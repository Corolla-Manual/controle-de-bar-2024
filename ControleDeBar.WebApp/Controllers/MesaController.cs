using ControleDeBar.Dominio.ModuloConta;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infra.Orm.Compartilhada;
using ControleDeBar.Infra.Orm.ModuloMesa;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControleDeBar.WebApp.Controllers;

public class MesaController : Controller
{
    public ViewResult Listar()
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        List<Mesa> mesas = repositorioMesa.SelecionarTodos();

        ViewBag.Mesa = mesas;

        return View();
    }

    public ViewResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public ViewResult Inserir(Mesa novaMesa) // data bindind
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        repositorioMesa.Cadastrar(novaMesa);

        HttpContext.Response.StatusCode = 201;

        ViewBag.Mensagem = $"O registro com o ID {novaMesa.Id} foi cadastrado com sucesso!";

        return View("mensagens");
    }

    public ViewResult Editar(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        ViewBag.Mesa = mesa;

        return View();
    }

    [HttpPost]
    public ViewResult Editar(int id, Mesa mesaAtualizada)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesaOriginal = repositorioMesa.SelecionarPorId(id);

        mesaAtualizada.Ocupada = HttpContext.Request.Form["ocupada"] == "on";

        repositorioMesa.Editar(mesaOriginal.Id, mesaOriginal);

        ViewBag.Mensagem = $"O registro com o ID {mesaOriginal.Id} foi editado com sucesso!";

        return View("mensagens");
    }

    public ViewResult Excluir(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        ViewBag.Mesa = mesa;

        return View();
    }

    [HttpPost, ActionName("excluir")]
    public ViewResult ExcluirMesa(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        repositorioMesa.Excluir(mesa.Id);

        HttpContext.Response.StatusCode = 200;

        ViewBag.Mensagem = $"O registro com o ID {mesa.Id} foi excluido com sucesso!";

        return View("mensagens");
    }

    public ViewResult Detalhes(int id)
    {
        ControleDeBarDbContext db = new ControleDeBarDbContext();
        IRepositorioMesa repositorioMesa = new RepositorioMesaEmOrm(db);

        Mesa mesa = repositorioMesa.SelecionarPorId(id);

        ViewBag.Mesa = mesa;

        return View();
    }
}
