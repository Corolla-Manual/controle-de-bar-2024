namespace ControleDeBar.WinApp
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
            ConfigurarPlayer();
        }

        private void ConfigurarPlayer()
        {
            wmVideo.uiMode = "none";
            wmVideo.Ctlenabled = false;
            string[] test = Directory.GetCurrentDirectory().Split("bin");
            wmVideo.URL = test[0] + "\\Resources\\Logo.mp4";

        }
        private void wmVideo_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 8)
            {
                Form telaPrincipal = new TelaPrincipalForm();
                telaPrincipal.Show();
                this.Hide();
            }
        }
    }
}
