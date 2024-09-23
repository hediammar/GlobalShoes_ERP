using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfAppGlobalShoes
{
    public class GifImage : Image
    {
        private BitmapDecoder decoder;
        private int currentFrame;
        private readonly DispatcherTimer timer;

        public GifImage()
        {
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
        }

        public void LoadGif(string path)
        {
            decoder = BitmapDecoder.Create(new Uri(path, UriKind.RelativeOrAbsolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            currentFrame = 0;
            timer.Interval = TimeSpan.FromMilliseconds(100); // Set the interval according to your GIF frame rate
            timer.Start();
            Source = decoder.Frames[0]; // Display the first frame initially
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            currentFrame++;
            if (currentFrame >= decoder.Frames.Count)
                currentFrame = 0;
            Source = decoder.Frames[currentFrame];
        }

        public void StopAnimation()
        {
            timer.Stop();
        }
    }
}
