using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");

            if (string.IsNullOrEmpty(Cpf.Trim()))
                erros.Add("O campo \"cpf\" é obrigatório");

            if (Cpf.Trim().Length < 14)
                erros.Add("O campo \"cpf\" não foi preenchido corretamente");
            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Garcom garcom = (Garcom)novoRegistro;

            Nome = garcom.Nome;
            Cpf = garcom.Cpf;
        }
        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}
