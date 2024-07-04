
using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        public String Nome { get; set; }
        public Double Preco { get; set; }

        public Produto()
        {

        }
        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Produto prod = (Produto)novoRegistro;

            Nome = prod.Nome;
            Preco = prod.Preco;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"Produto\" deve ser preenchido!");

            else if (Preco <= 0)
                erros.Add("O campo \"Valor\" deve ser preenchido!");

            return erros;
        }
    }
}
