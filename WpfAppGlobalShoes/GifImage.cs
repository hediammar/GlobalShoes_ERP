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

        // Property to control the speed of the GIF
        public int FrameDelay { get; set; } = 20; // Default frame delay (in milliseconds)

        public GifImage()
        {
            timer = new DispatcherTimer();
            timer.Tick += OnTimerTick;
        }

        // Method to load the GIF and start the animation
        public void LoadGif(string path)
        {
            decoder = BitmapDecoder.Create(new Uri(path, UriKind.RelativeOrAbsolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            currentFrame = 0;

            // Set the interval based on the FrameDelay property
            timer.Interval = TimeSpan.FromMilliseconds(FrameDelay);
            timer.Start();

            // Display the first frame initially
            Source = decoder.Frames[0];
        }

        // Method triggered on every timer tick to update the frame
        private void OnTimerTick(object sender, EventArgs e)
        {
            if (decoder == null || decoder.Frames.Count == 0) return;

            currentFrame++;
            if (currentFrame >= decoder.Frames.Count)
                currentFrame = 0;

            // Update the source of the image with the current frame
            Source = decoder.Frames[currentFrame];
        }

        // Method to stop the GIF animation
        public void StopAnimation()
        {
            timer.Stop();
        }
    }
}
