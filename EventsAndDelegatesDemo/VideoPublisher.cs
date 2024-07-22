using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsAndDelegatesDemo
{

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoPublisher
    {

        //public delegate void VideoPublisherEventHandler(object source, EventArgs args);

        public event EventHandler<VideoEventArgs> VideoPublished;

        public void Publish(Video video)
        {
            Console.WriteLine("Publishing video....");
            Thread.Sleep(3000);

            VideoPublished?.Invoke(this, new VideoEventArgs() { Video = video });
        }
    }
}
