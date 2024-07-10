namespace ControleDeBar.WinApp.Compartilhado
{
    public interface IControladorEmAberto
    {
        string ToolTipVisualizarEmAberto { get; }
        void VisualizarEmAberto(ToolStripButton btn);
    }
}
