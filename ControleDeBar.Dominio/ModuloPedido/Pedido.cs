using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public int NumeroPedido { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public Pedido()
        {

        }
        public Pedido(int numeroPedido, Produto produto, int quantidade)
        {
            NumeroPedido = numeroPedido;
            Produto = produto;
            Quantidade = quantidade;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produto == null)
                erros.Add("O campo \"Produto\" é obrigatório!");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido pedido = (Pedido)novoRegistro;

            NumeroPedido = pedido.NumeroPedido;
            Produto = pedido.Produto;
            Quantidade = pedido.Quantidade;
        }

        public double CalcularValor()
        {
            return Produto.Preco * Quantidade;
        }
        public override string ToString()
        {
            return $"Pedido Nº {NumeroPedido}";
        }
    }
}
