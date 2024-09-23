using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfAppGlobalShoes
{
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            StartLoadingAnimation();
            //LoadingGif.LoadGif("/Images/Hourglass.gif");
        }

        private void StartLoadingAnimation()
        {
            // Create a rotate animation
            DoubleAnimation rotateAnimation = new DoubleAnimation
            {
                From = 0,
                To = 360,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                RepeatBehavior = RepeatBehavior.Forever
            };

            // Apply the animation to the rotation transform of the logo
            LogoRotation.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}
