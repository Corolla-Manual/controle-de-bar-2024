using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        public bool Ocupada { get; set; }
        public int NumeroMesa { get; set; }

        public Mesa(int numeroMesa)
        {
            NumeroMesa = numeroMesa;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (NumeroMesa <= 0)
                erros.Add("O número da Mesa precisa ser maior que 0.");

            return erros;
        }

        public override void AtualizarRegistro(EntidadeBase novoRegistro)
        {
            Mesa mesa = (Mesa)novoRegistro;

            Ocupada = mesa.Ocupada;
            NumeroMesa = mesa.NumeroMesa;
        }
        public override string ToString()
        {
            return $"Mesa Nº {NumeroMesa}";
        }
    }
}
