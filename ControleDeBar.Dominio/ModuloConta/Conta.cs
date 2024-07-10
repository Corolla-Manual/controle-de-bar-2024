using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Dominio.ModuloPedido;

namespace ControleDeBar.Dominio.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public List<Pedido> Pedidos { get; set; }
        public Mesa Mesa { get; set; }
        public Garcom Garcom { get; set; }
        public double ValorTotal { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataConclusao { get; set; }
        public Conta()
        {

        }

        public Conta(Mesa mesa, Garcom garcom)
        {
            Mesa = mesa;
            Garcom = garcom;
            Pedidos = new List<Pedido>();
            ValorTotal = 0;
            Concluida = false;
            DataConclusao = DateTime.Parse("01/01/2000");
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
        public void CalcularValorTotal()
        {
            ValorTotal = 0;
            foreach (Pedido p in Pedidos)
            {
                ValorTotal += p.CalcularValor();
            }
        }
        public void Concluir()
        {
            Concluida = true;
            DataConclusao = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Id: {Id} - Garcom: {Garcom} - Mesa: {Mesa} - Valor Total: R$ {ValorTotal}";
        }
    }
}
