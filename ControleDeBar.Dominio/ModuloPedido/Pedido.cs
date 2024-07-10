using ControleDeBar.Dominio.Compartilhado;
using ControleDeBar.Dominio.ModuloProduto;

namespace ControleDeBar.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public Pedido()
        {

        }
        public Pedido(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Produto == null)
                erros.Add("O campo \"Produto\" é obrigatório!");

            if (Quantidade <= 0)
                erros.Add("O campo \"Quantidade\" é obrigatório!");
            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Pedido pedido = (Pedido)novoRegistro;

            Produto = pedido.Produto;
            Quantidade = pedido.Quantidade;
        }

        public double CalcularValor()
        {
            return Produto.Preco * Quantidade;
        }
        public override string ToString()
        {
            return $"Produto: {Produto} | Quantidade: {Quantidade}";
        }
    }
}
