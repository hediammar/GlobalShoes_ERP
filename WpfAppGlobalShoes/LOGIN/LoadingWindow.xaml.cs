using System.Windows;

namespace WpfAppGlobalShoes
{
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;

            // Load the GIF for the loading animation
            LoadingGif.LoadGif("pack://application:,,,/Images/ballLoading.gif");
            LoadingGif.FrameDelay = 20;
        }
    }
}
