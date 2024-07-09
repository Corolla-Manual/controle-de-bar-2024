using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloPedido;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloGarcom;
using System.Drawing;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public List<Pedido> Pedidos {get; set;}
        public Mesa Mesa { get; set; }
        public Garcom Garcom { get; set; }
        public double ValorTotal { get; set; }
        public bool Concluida { get; set; }

        public Conta()
        {
            
        }

        public Conta(List<Pedido> pedidos, Mesa mesa, Garcom garcom, double valorTotal, bool concluida)
        {
            Pedidos = pedidos;
            Mesa = mesa;
            Garcom = garcom;
            ValorTotal = valorTotal;
            Concluida = concluida;
        }
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Mesa == null)
                erros.Add("O campo \"mesa\" é obrigatório");

            if (Garcom == null)
                erros.Add("O campo \"garcom\" é obrigatório");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Conta conta = (Conta)novoRegistro;

            Pedidos = conta.Pedidos;
            Mesa = conta.Mesa;
            Garcom = conta.Garcom;
            ValorTotal = conta.ValorTotal;
            Concluida = conta.Concluida;
        }

    }
}
