using ControleDeBar.Dominio.ModuloProduto;
using ControleDeBar.WinApp.Compartilhado;

namespace ControleDeBar.WinApp.ModuloProduto
{
    public partial class TelaProdutoForm : Form
    {
        private Produto produto;
        public Produto Produto
        {
            get { return produto; }
            set
            {
                txtNome.Text = value.Nome;
                numPreco.Value = (decimal)value.Preco;
            }
        }
        private List<Produto> produtosCadastrados;

        public TelaProdutoForm(List<Produto> produtosCadastrados)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.produtosCadastrados = produtosCadastrados;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            double preco = (double)numPreco.Value;

            produto = new Produto(nome, preco);

            List<string> erros = produto.Validar();

            if (ProdutoTemNomeDuplicado())
                erros.Add("Já existe um produto com este nome cadastrada, tente utilizar outro!");

            if (erros.Count > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
        private bool ProdutoTemNomeDuplicado()
        {
            return produtosCadastrados.Any(d => d.Nome == produto.Nome);
        }
    }
}
